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
    private readonly KeepsRepository _kr;
    private readonly VaultsService _vs;

    private readonly KeepsService _ks;
    public VaultKeepsService(VaultKeepsRepository vkr, VaultsRepository vr, KeepsRepository kr, VaultsService vs, KeepsService ks)
    {
      _vkr = vkr;
      _vr = vr;
      _kr = kr;
      _vs = vs;
      _ks = ks;
    }

    public List<VaultKeepIdModel> GetKeepsByVaultId(int vaultId, string userId)
   {
    var foundVault = _vs.GetById(vaultId, userId);
    return _vkr.GetKeepsByVaultId(vaultId);
  }

    public VaultKeep CreateVaultKeeps(VaultKeep data, string userId)
    {
      var vault = _vs.GetById(data.VaultId, userId);
      if(vault.CreatorId != data.CreatorId)
      {
        throw new Exception("You're Not Authorized");
      }
        return _vkr.CreateVaultKeeps(data, data.KeepId);
    }

    public void DeleteVaultKeeps(int vaultKeepId, string userId)
    {
      var vaultKeep = GetVaultKeep(vaultKeepId);
      if(vaultKeep.CreatorId != userId)
      {
        throw new Exception("You are not authorized!");
      }
      _vkr.Delete(vaultKeepId, vaultKeep.KeepId);
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