using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _keepsRepository;

    public KeepsService(KeepsRepository keepsRepository)
    {
      _keepsRepository = keepsRepository;
    }

    public List<Keep> GetAll()
    {
      return _keepsRepository.GetAll();
    }

    public Keep GetById(int keepId)
    {
      var keep = _keepsRepository.GetById(keepId);
      if(keep == null)
      {
        throw new Exception("invalid id");
      }
      keep.Views++;
      return keep;
    }

    public Keep Create(Keep data)
    {
      return _keepsRepository.Create(data);
    }

    public Keep Edit(Keep data)
    {
      var keep = GetById(data.Id);
      if(keep.CreatorId != data.CreatorId)
      {
        throw new Exception("You're Not Authorized");
      }
      keep.Name = data.Name ?? keep.Name;
      keep.Description = data.Description ?? keep.Description;
      keep.Img = data.Img ?? keep.Img;
      var updatedKeep = _keepsRepository.Edit(data);
      return updatedKeep;
    }

    public Keep Delete(int keepId, string userId)
    {
      var keep = GetById(keepId);
      if(keep.CreatorId != userId)
      {
        throw new Exception("You're Not Authorized");
      }
      _keepsRepository.Delete(keepId);
      return keep;
    }
  }
}