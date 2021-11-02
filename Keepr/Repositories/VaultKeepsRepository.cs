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

    public void Delete(int id)
    {
      string sql = @"DELETE FROM vaultKeep WHERE id = @id LIMIT 1;
      UPDATE keeps
        SET 
          keeps = @Keeps - 1
        WHERE id = @Id
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

    public VaultKeep CreateVaultKeeps(VaultKeep data)
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
      UPDATE keeps
        SET 
          keeps = @Keeps + 1
        WHERE id = @Id
        LIMIT 1
      SELECT LAST_INSERT_ID();";
      data.Id = _db.ExecuteScalar<int>(sql, data);
      return data;
    }
  }
}