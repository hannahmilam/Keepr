using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkr;

    public VaultKeepsService(VaultKeepsRepository vkr)
    {
      _vkr = vkr;
    }

    public List<VaultKeep> GetKeepsByVaultId(int vaultId)
   {
    return _vkr.GetKeepsByVaultId(vaultId);
  }

    public VaultKeep CreateVaultKeeps(VaultKeep data)
    {
      return _vkr.CreateVaultKeeps(data);
    }

    public VaultKeep DeleteVaultKeeps(int vaultKeepId)
    {
      VaultKeep vaultKeep = GetVaultKeep(vaultKeepId);
     _vkr.Delete(vaultKeepId);
     return vaultKeep;
    }
    public VaultKeep GetVaultKeep(int vaultKeepId)
    {
      VaultKeep vaultKeep = _vkr.GetVaultKeepById(vaultKeepId);
      if(vaultKeep == null)
      {
        throw new Exception("Invalid Id");
      }
      return vaultKeep;
    }
  }

}