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
   public Vault GetById(int vaultId)
    {
      Vault vault = _vaultsRepository.GetById(vaultId);
      if(vault == null)
      {
        throw new Exception("Invalid Id");
      }
      return vault;
    }

   public Vault Create(Vault data)
    {
      return _vaultsRepository.Create(data);
    }

    public Vault Edit(Vault data)
    {
      Vault vault = GetById(data.Id);
      vault.Name = data.Name ?? vault.Name;
      vault.Description = data.Description ?? data.Description;
      vault.IsPrivate = data.IsPrivate;
      _vaultsRepository.Edit(data);
      return vault;
    }

    public Vault Delete(int vaultId)
    {
      Vault vault = GetById(vaultId);
      _vaultsRepository.Delete(vaultId);
      return vault;
    }
  }
}