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
  }
}