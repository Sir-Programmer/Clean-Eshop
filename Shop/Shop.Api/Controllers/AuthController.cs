using System.Net;
using Common.Application.OperationResults;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Shop.Api.Infrastructure.JwtUtils;
using Shop.Api.ViewModels.Auth;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.Register;
using Shop.Presentation.Facade.Users;
using Shop.Query.Users.DTOs;
using UAParser;

namespace Shop.Api.Controllers;

public class AuthController(IUserFacade userFacade, IConfiguration configuration) : ApiController
{
    [HttpPost("Login")]
    public async Task<ApiResult<LoginResultDto?>> Login(LoginViewModel model)
    {
        var user = await userFacade.GetByPhoneNumber(model.PhoneNumber);
        if (user == null || user.Password != model.Password.ToSha256() || user.PhoneNumber != model.PhoneNumber)
        {
            var result = OperationResult<LoginResultDto>.Error("کاربری با این مشخصات یافت نشد!");
            return CommandResult(result, HttpStatusCode.NotFound);
        }
        return CommandResult(await GenerateLoginResult(user));
    }

    [HttpPost("Register")]
    public async Task<ApiResult> Register(RegisterViewModel model)
    {
        var result = await userFacade.Register(new RegisterUserCommand(model.PhoneNumber, model.Password));
        return CommandResult(result);
    }

    private async Task<OperationResult<LoginResultDto?>> GenerateLoginResult(UserDto user)
    {
        var userAgent = HttpContext.Request.Headers.UserAgent.ToString();
        var ua = Parser.GetDefault().Parse(userAgent);
        var device = $"{ua.Device.Family} | {ua.OS.Family} {ua.OS.Major}.{ua.OS.Minor} | {ua.UA.Family}";

        var token = JwtTokenBuilder.BuildToken(user, configuration);

        var tokenHash = token.ToSha256();
        var refreshTokenHash = Guid.NewGuid().ToString().ToSha256();

        await userFacade.AddToken(new AddUserTokenCommand(user.Id, tokenHash, refreshTokenHash, DateTime.Now.AddDays(30), DateTime.Now.AddDays(35), device));
        var loginResult =  new LoginResultDto()
        {
            Token = token,
            RefreshToken = refreshTokenHash,
        };
        return OperationResult<LoginResultDto?>.Success(loginResult);
    }
}