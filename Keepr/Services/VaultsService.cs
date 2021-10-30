using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
  private readonly VaultsRepository _vaultsRepository;

    public VaultsService(VaultsRepository vaultsRepository)
    {
      _vaultsRepository = vaultsRepository;
    }

    public List<Vault> GetAll()
    {
      return _vaultsRepository.GetAll();
    }
   public Vault GetById(int vaultId, string userId)
    {
      var vault = _vaultsRepository.GetById(vaultId);
      if(vault == null)
      {
        throw new Exception("Invalid Id");
      }
      if(vault.IsPrivate == true && vault.CreatorId != userId)
      {
        throw new Exception("This is private");
      }

      return vault;
    }

   public Vault Create(Vault data)
    {
      return _vaultsRepository.Create(data);
    }

    public Vault Edit(Vault data)
    {
      var vault = GetById(data.Id, data.CreatorId);
      if(data.CreatorId != vault.CreatorId)
      {
        throw new Exception("You're Not Authorized");
      }
      vault.Name = data.Name ?? vault.Name;
      vault.Description = data.Description ?? data.Description;
      vault.IsPrivate = data.IsPrivate;
      _vaultsRepository.Edit(data);
      return vault;
    }

    public Vault Delete(int vaultId, string userId)
    {
      var vault = GetById(vaultId, userId);
      if(vault.CreatorId != userId)
      {
        throw new Exception("You're Not Authorized!");
      }
      _vaultsRepository.Delete(vaultId);
      return vault;
    }
  }
}