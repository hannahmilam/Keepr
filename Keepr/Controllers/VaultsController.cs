using System.Collections.Generic;
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
  public class VaultsController : ControllerBase
{
    private readonly VaultsService _vaultsService;
    private readonly VaultKeepsService _vks;
    public VaultsController(VaultsService vaultsService, VaultKeepsService vks)
    {
      _vaultsService = vaultsService;
      _vks = vks;
    }

    [HttpGet]
    public ActionResult <List<Vault>> GetAll()
    {
      try
      {
          return _vaultsService.GetAll(); 
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{vaultId}")]
    public async Task<ActionResult<Vault>> GetById(int vaultId)
    {
      try
      {
         Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          return _vaultsService.GetById(vaultId, userInfo?.Id); 
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{vaultId}/keeps")]
    public async Task<ActionResult<List<VaultKeepIdModel>>> GetKeepsByVaultIdAsync(int vaultId)
    {
      try
      {
         Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          return _vks.GetKeepsByVaultId(vaultId, userInfo?.Id);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault data)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          data.CreatorId = userInfo.Id;
          var createdVault = _vaultsService.Create(data);
          createdVault.Creator = userInfo;
          return Ok(createdVault);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    

    [Authorize]
    [HttpPut("{vaultId}")]
    public async Task<ActionResult<Vault>> EditVault(int vaultId, [FromBody] Vault data)
    {
      try
      {
          data.Id = vaultId;
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          data.CreatorId = userInfo.Id;
          var updatedVault = _vaultsService.Edit(data);
          return Ok(updatedVault);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{vaultId}")]
    public async Task<ActionResult<Vault>> DeleteVault(int vaultId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        var vault = _vaultsService.Delete(vaultId, userInfo.Id);
        return Ok(vault);

      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

}
}