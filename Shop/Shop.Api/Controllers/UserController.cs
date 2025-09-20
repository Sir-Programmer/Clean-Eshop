using System.Net;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.User;
using Shop.Api.ViewModels.User.Addresses;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.ChangePassword;
using Shop.Application.Users.Create;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.Edit;
using Shop.Application.Users.EditAddress;
using Shop.Application.Users.EditProfile;
using Shop.Application.Users.SetActiveAddress;
using Shop.Presentation.Facade.Users;
using Shop.Presentation.Facade.Users.Addresses;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.DTOs.Filter;

namespace Shop.Api.Controllers
{
    public class UserController(IUserFacade userFacade, IUserAddressFacade addressFacade) : ApiController
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

        // Addresses

        [HttpGet("me/addresses")]
        public async Task<ApiResult<List<UserAddressDto>>> GetAddressList()
        {
            var result = await addressFacade.GetList(User.GetUserId());
            return QueryResult(result);
        }

        [HttpGet("me/addresses/{addressId:guid}")]
        public async Task<ApiResult<UserAddressDto?>> GetAddressById(Guid addressId)
        {
            var result = await addressFacade.GetById(User.GetUserId(), addressId);
            return QueryResult(result);
        }

        [HttpPost("me/addresses")]
        public async Task<ApiResult> AddAddress(AddUserAddressViewModel vm)
        {
            var result = await addressFacade.Add(new AddUserAddressCommand(User.GetUserId(), vm.Province, vm.City,
                vm.PostalCode, vm.FullName, vm.PostalAddress, vm.PhoneNumber, vm.NationalId));
            return CommandResult(result);
        }

        [HttpPut("me/addresses/{addressId:guid}")]
        public async Task<ApiResult> EditAddress(Guid addressId, EditUserAddressViewModel vm)
        {
            var result = await addressFacade.Edit(new EditUserAddressCommand(User.GetUserId(), addressId, vm.Province, vm.City,
                vm.PostalCode, vm.FullName, vm.PostalAddress, vm.PhoneNumber, vm.NationalId));
            return CommandResult(result);
        }

        [HttpPut("me/addresses/{addressId:guid}/active")]
        public async Task<ApiResult> ActiveAddress(Guid addressId)
        {
            var result = await addressFacade.SetActive(new SetUserActiveAddressCommand(User.GetUserId(), addressId));
            return CommandResult(result);
        }

        [HttpDelete("me/addresses/{addressId:guid}")]
        public async Task<ApiResult> DeleteAddress(Guid addressId)
        {
            var result = await addressFacade.Delete(new DeleteUserAddressCommand(User.GetUserId(), addressId));
            return CommandResult(result);
        }
    }
}
