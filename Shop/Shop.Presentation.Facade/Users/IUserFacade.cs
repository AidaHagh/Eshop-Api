using Common.Application;
using MediatR;
using Shop.Application.Users.ChargeWallet;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Register;
using Shop.Domain.UserAgg;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.GetByFilter;
using Shop.Query.Users.GetById;
using Shop.Query.Users.GetByPhoneNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Presentation.Facade.Users
{
    public interface IUserFacade
    {
        Task<OperationResult> CreateUser(CreateUserCommand command);
        Task<OperationResult> EditUser(EditUserCommand command);
        Task<OperationResult> RegisterUser(RegisterUserCommand command);


        Task<UserDto?> GetUserById(long userId); 
        Task<UserDto?> GetUserByPhoneNumber(string phoneNumber); 
        Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams); 

    }
    internal class UserFacade : IUserFacade
    {
        private readonly IMediator _mediator;

        public UserFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> CreateUser(CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditUser(EditUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams)
        {
            return await _mediator.Send(new GetUserByFilterQuery(filterParams));
        }

        public async Task<UserDto?> GetUserById(long userId)
        {
            return await _mediator.Send(new GetUserByIdQuery(userId));
        }

        public async Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
        }

        public async Task<OperationResult> RegisterUser(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
