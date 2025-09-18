using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.User;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Presentation.Facade.Users;

namespace Shop.Api.Controllers
{
    public class UserController(IUserFacade userFacade) : ApiController
    {
        [HttpPost]
        public async Task<ApiResult<Guid>> Create(CreateUserCommand command)
        {
            var result = await userFacade.Create(command);
            return CommandResult(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ApiResult> Edit(Guid id, EditUserViewModel vm)
        {
            var result = await userFacade.Edit(new EditUserCommand(id, vm.Name, vm.Family, vm.PhoneNumber, vm.Email, vm.Gender));
            return CommandResult(result);
        }
    }
}
