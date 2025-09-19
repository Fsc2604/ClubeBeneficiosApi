using ClubeBeneficiosApi.Application.DTOs;
using ClubeBeneficiosApi.Application.Interfaces;
using ClubeBeneficiosApi.Application.ValidationDtos;
using ClubeBeneficiosAPi.Domain.Authentication;
using ClubeBeneficiosAPi.Domain.Entities;
using ClubeBeneficiosAPi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace ClubeBeneficiosApi.Application.Services
{
    public class UserPermissionService : IUserPermissionService
    {

        private readonly IUserPermissionRepository _userPermissionRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UserPermissionService(IUserPermissionRepository userPermissionRepository, ITokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
            _userPermissionRepository = userPermissionRepository;
        }

        public async Task<ReturnFrontService<dynamic>> GenerateTokenAsync(UserPermissionDto userPermissionDto)
        {
            if (userPermissionDto == null)
                return ReturnFrontService.Fail<dynamic>("Objeto deve ser informado");

            var validator = new UserPermissionDtoValidator().Validate(userPermissionDto);
            if (!validator.IsValid)
                return ReturnFrontService.RequestError<dynamic>("Problemas com a validação", validator);

         
            var user = await _userPermissionRepository.GetUserByEmailAsync(userPermissionDto.Email);
            if (user == null)
                return ReturnFrontService.Fail<dynamic>("Usuário ou Senha não encontrado!");

         
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(userPermissionDto.Password, user.PasswordHash);
            if (!isPasswordValid)
                return ReturnFrontService.Fail<dynamic>("Usuário ou Senha não encontrado!");

            if (user.Client == null)
                return ReturnFrontService.Fail<dynamic>("Cliente associado não encontrado!");

          
            return ReturnFrontService.Ok(_tokenGenerator.Generator(user.Client));
        }

    }
}
