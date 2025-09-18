using System.Net;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.User;
using Shop.Application.Users.ChangePassword;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.EditProfile;
using Shop.Presentation.Facade.Users;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.DTOs.Filter;

namespace Shop.Api.Controllers
{
    public class UserController(IUserFacade userFacade) : ApiController
    {
        [HttpGet]
        public async Task<ApiResult<UserFilterResult?>> GetByFilter([FromQuery] UserFilterParams filters)
        {
            var result = await userFacade.GetByFilter(filters);
            return QueryResult(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ApiResult<UserDto?>> GetById(Guid id)
        {
            var result = await userFacade.GetById(id);
            return QueryResult(result);
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<ApiResult<UserDto?>> GetCurrent()
        {
            var result = await userFacade.GetById(User.GetUserId());
            return QueryResult(result);
        }

        [HttpPut("me")]
        [Authorize]
        public async Task<ApiResult> EditProfile(EditUserProfileViewModel vm)
        {
            var result = await userFacade.EditProfile(new EditUserProfileCommand(User.GetUserId(), vm.Name, vm.Family, vm.Gender));
            return CommandResult(result);
        }

        [HttpPut("me/change-password")]
        [Authorize]
        public async Task<ApiResult> ChangePassword(ChangeUserPasswordViewModel vm)
        {
            var result = await userFacade.ChangePassword(new ChangeUserPasswordCommand(User.GetUserId(), vm.CurrentPassword, vm.ConfirmPassword));
            return CommandResult(result);
        }

        [HttpPost]
        public async Task<ApiResult<Guid>> Create(CreateUserCommand command)
        {
            var result = await userFacade.Create(command);
            var url = Url.Action("GetById", "User", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, statusCode: HttpStatusCode.Created, locationUrl: url);
        }

        [HttpPut("{id:guid}")]
        public async Task<ApiResult> Edit(Guid id, EditUserViewModel vm)
        {
            var result = await userFacade.Edit(new EditUserCommand(id, vm.Name, vm.Family, vm.PhoneNumber, vm.Email, vm.Gender));
            return CommandResult(result);
        }
    }
}
