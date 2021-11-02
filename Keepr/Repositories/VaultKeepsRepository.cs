using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<VaultKeepIdModel> GetKeepsByVaultId(int vaultId)
    {
      string sql = @"
      SELECT
      a.*,
      k.*,
      vk.id AS vaultKeepId
      FROM vaultKeep vk
      JOIN keeps k on vk.keepId = k.id
      JOIN accounts a on k.creatorId = a.id
      WHERE vk.vaultId = @vaultId;
      ";
      return _db.Query<Profile, VaultKeepIdModel, VaultKeepIdModel>(sql, (a, vk) =>
      {
        vk.Creator = a;
        return vk;
      }, new {vaultId}).ToList();
    }

    public void Delete(int id, int keepId)
    {
      string sql = @"DELETE FROM vaultKeep WHERE id = @id LIMIT 1;
      UPDATE keeps
        SET 
          keeps = keeps - 1
        WHERE id = @keepId
        LIMIT 1;";
      var affectedRows = _db.Execute(sql, new {id});
      if(affectedRows == 0)
      {
        throw new Exception("unable to delete");
      }
    }

   public VaultKeep GetVaultKeepById(int vaultKeepId)
    {
      string sql = @"
      SELECT *
      FROM vaultKeep vk
      JOIN accounts a on vk.creatorId = a.id
      JOIN keeps k on vk.keepId = k.id
      WHERE vk.id = @vaultKeepId;
     ";
      return _db.Query<VaultKeep, Profile, Keep, VaultKeep>(sql, (vk, a, k) => 
      {
        vk.CreatorId = a.Id;
        vk.KeepId = k.Id;
        return vk;
      }, new {vaultKeepId}).FirstOrDefault();
    }

    public VaultKeep CreateVaultKeeps(VaultKeep data, int keepId)
    {
      string sql = @"
      INSERT INTO vaultKeep(
        creatorId,
        vaultId,
        keepId
        )
      VALUES (
        @CreatorId,
        @VaultId,
        @KeepId
          );
      SELECT LAST_INSERT_ID();
      UPDATE keeps k
        SET 
          keeps = keeps + 1
        WHERE id = @keepId
        LIMIT 1;";
      data.Id = _db.ExecuteScalar<int>(sql, data);
      return data;
    }
  }
}