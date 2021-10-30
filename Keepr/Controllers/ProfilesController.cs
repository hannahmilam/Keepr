using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly AccountService _accountService;

    public ProfilesController(AccountService accountService)
    {
      _accountService = accountService;
    }

    [HttpGet("{profileId}")]
    public ActionResult<Profile> GetProfileById(string profileId)
    {
      try
      {
           var profile = _accountService.GetProfileById(profileId);
           return Ok(profile);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{profileId}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetVaultsByProfileId(string profileId)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
           var vaults = _accountService.GetUsersVaults(profileId, userInfo.Id);
           return Ok(vaults);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{profileId}/keeps")]
    public ActionResult <List<Keep>> GetKeepsByProfileId(string profileId)
    {
      try
      { 
           var keeps = _accountService.GetUsersKeeps(profileId);
           return Ok(keeps);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }

  }
}