using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkr;
    private readonly VaultsRepository _vr;

    public VaultKeepsService(VaultKeepsRepository vkr, VaultsRepository vr)
    {
      _vkr = vkr;
      _vr = vr;
    }

    public List<VaultKeepIdModel> GetKeepsByVaultId(int vaultId)
   {
    var foundVault = _vr.GetById(vaultId);
    if(foundVault.IsPrivate == true)
    {
      throw new Exception("Vault Is Private");
    }
    return _vkr.GetKeepsByVaultId(vaultId);
  }

    public VaultKeep CreateVaultKeeps(VaultKeep data)
    {
      return _vkr.CreateVaultKeeps(data);
    }

    public void DeleteVaultKeeps(int vaultKeepId, string userId)
    {
      var vaultKeep = GetVaultKeep(vaultKeepId);
      if(vaultKeep.CreatorId != userId)
      {
        throw new Exception("You are not authorized!");
      }
      _vkr.Delete(vaultKeepId);
    }
    public VaultKeep GetVaultKeep(int vaultKeepId)
    {
      var vaultKeep = _vkr.GetVaultKeepById(vaultKeepId);
      if(vaultKeep == null)
      {
        throw new Exception("Invalid Id");
      }
      return vaultKeep;
    }
  }

}