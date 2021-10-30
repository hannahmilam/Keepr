using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
[ApiController]
[Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;

    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<VaultKeep>> CreateVaultKeeps([FromBody] VaultKeep data)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          data.CreatorId = userInfo.Id;
          var createdVault = _vks.CreateVaultKeeps(data);
          return Ok(createdVault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{vaultKeepId}")]
    public async Task<ActionResult<String>> DeleteVaultKeeps(int vaultKeepId)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          _vks.DeleteVaultKeeps(vaultKeepId, userInfo.Id);
          return Ok("Keep Removed");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{vaultKeepId}")]
    public ActionResult<VaultKeep> GetVaultKeep(int vaultKeepId)
    {
      var vaultKeep = _vks.GetVaultKeep(vaultKeepId);
      return Ok(vaultKeep);
    }
  }
}