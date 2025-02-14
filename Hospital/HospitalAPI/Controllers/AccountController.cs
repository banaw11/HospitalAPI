﻿using HospitalAPI.DTOs;
using HospitalAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<ActionResult<CreatedUserAccountDTO>> Register([FromBody] RegisterUserDTO dto)
        {
            var newUserAccount = await _accountService.RegisterUser(dto);

            return Ok(newUserAccount);
        }

        [HttpPost("signIn")]
        public async Task<ActionResult<UserDTO>> SignIn([FromBody] LoginUserDTO dto)
        {
            var userDTO = await _accountService.SignInUser(dto);

            return Ok(userDTO);
        }

        [HttpPut("password")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordDTO dto)
        {
            var isAdministrator = User.IsInRole("ADMINISTRATOR");
            var userLogin = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await _accountService.ResetPassword(dto, isAdministrator, userLogin);

            return NoContent();
        }

        [HttpPut]
        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<ActionResult> Update([FromBody] EmployeeDetailsDTO dto)
        {
            await _accountService.UpdateAccount(dto);

            return NoContent();
        }

        [HttpDelete]
        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<ActionResult> Delete([FromQuery] string login)
        {
            await _accountService.DeleteAccount(login);

            return NoContent();
        }
    }
}
