﻿using Domain.Features.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstudoWebService.Exceptions
{
    public class ExceptionPayload
    {
        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        /// <summary>
        /// Método para criar um novo ExceptionPayload de uma exceção de negócio.
        ///          
        /// As exceções de negócio, que são providas no Prova1.Domain
        /// são identificadas pelos códigos no enum ErrorCodes. 
        /// 
        /// Assim, esse método monta o ExceptionPayload, que será o código retornado o cliente, 
        /// com base na exceção lançada.
        /// 
        ///</summary>
        /// <param name="exception">É a exceção lançada</param>
        /// <returns>ExceptionPayload contendo o código do erro e a mensagem da da exceção que foi lançada </returns>
        public static ExceptionPayload New<T>(T exception) where T : Exception
        {
            int errorCode;
            if (exception is BusinessException)
                errorCode = (exception as BusinessException).ErrorCode.GetHashCode();
            else
                errorCode = ErrorCodes.Unhandled.GetHashCode();
            return new ExceptionPayload
            {
                ErrorCode = errorCode,
                ErrorMessage = exception.Message,
            };
        }
    }
}