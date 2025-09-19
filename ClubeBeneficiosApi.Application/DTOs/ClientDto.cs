using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Application.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
