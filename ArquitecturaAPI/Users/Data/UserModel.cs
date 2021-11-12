using Arquitectura.Core;
using Arquitectura.Core.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArquitecturaAPI.Users.Data
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastnames { get; set; }
        public string Email { get; set; }
    }

    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator  ()
        {
            RuleSet("FieldsRequired", () =>
            {
                RuleFor(x => x.Name).NotNull().WithMessage("Nombre es requerido");
                RuleFor(x => x.Lastnames).NotNull().WithMessage("Apellidos es requerido");
                RuleFor(x => x.Email).NotNull().WithMessage("Email es requerido");
            });

            RuleFor(x => x.Email).EmailAddress().WithMessage("El email es incorrecto");
        }
    }
}
