﻿using ChatRoom.Infrastructure;
using ChatRoom.Users.Commands;
using ChatRoom.Users.Queries;
using FluentValidation;


namespace FoodApp.Api.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        private readonly IBus _bus;

        public RegisterValidator(IBus bus)
        {
            _bus = bus;

            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage("User Name is required with length between 3-50")
                .Must(BeUniqueUserName)
                .WithMessage("User Name is already taken");

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();

            When(x => !x.IsGuest, () =>
            {
                RuleFor(x => x.Password)
                    .NotEmpty()
                    .MinimumLength(4);
            });
        }

        private bool BeUniqueUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return false;

            var result = _bus.Handle(new CheckUserNameUniquenessQuery { UserName = userName });
            return result.Unique;
        }
    }
}
