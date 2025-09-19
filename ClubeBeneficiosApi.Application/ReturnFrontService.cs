using FluentValidation.Results;

namespace ClubeBeneficiosApi.Application
{
    public class ReturnFrontService
    {
        //<summary> Classe Exclusiva para tratar retornos para o Front da aplicação </summary>
        public bool IsSucess { get; set; }
        public string Message { get; set; }

        public ICollection<ErrorValidation> Errors { get; set; }


        public static ReturnFrontService RequestError(string message, ValidationResult validationResult)
        {

            return new ReturnFrontService
            {
                IsSucess = false,
                Message = message,
                Errors = validationResult.Errors.Select(e => new ErrorValidation { Field = e.PropertyName, Message = e.ErrorMessage }).ToList()
            };
        }

        public static ReturnFrontService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ReturnFrontService<T>
            {
                IsSucess = true,
                Message = message,
                Errors = validationResult.Errors.Select(e => new ErrorValidation { Field = e.PropertyName, Message = e.ErrorMessage }).ToList()
            };
        }


        public static ReturnFrontService Fail(string message) => new ReturnFrontService { IsSucess = false, Message = message };
        public static ReturnFrontService Ok(string message) => new ReturnFrontService { IsSucess = true, Message = message };

        public static ReturnFrontService<T> Fail<T>(string message) => new ReturnFrontService<T> { IsSucess = false, Message = message };

        public static ReturnFrontService<T> Ok<T>(T data) => new ReturnFrontService<T> { IsSucess = true, Data = data };
    };


    public class ReturnFrontService<T> : ReturnFrontService
    {
        /// <summary>Tipo genérico para passar vários tipos de retorno </summary>
        public T Data { get; set; }
    }

}
