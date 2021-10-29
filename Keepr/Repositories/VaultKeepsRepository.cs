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

    public List<VaultKeep> GetKeepsByVaultId(int vaultId)
    {
      string sql = @"
      SELECT * 
      FROM vaultKeeps vk
      JOIN accounts a on vk.creatorId = a.id
      JOIN vaults v on vk.vaultId = v.id
      WHERE vk.vaultId = @vaultId;
      ";
      return _db.Query<VaultKeep, Account, Vault, VaultKeep>(sql, (vk, a, v) =>
      {
        vk.CreatorId = a.Id;
        vk.VaultId = v.Id;
        return vk;
      }, new {vaultId}).ToList();
    }

    public VaultKeep CreateVaultKeeps(VaultKeep data)
    {
      string sql = @"
      INSERT INTO vaultKeeps(
        creatorId,
        vaultId,
        keepId
        )
      VALUES(
        @CreatorId,
        @VaultId,
        @KeepId
          );
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }
  }
}