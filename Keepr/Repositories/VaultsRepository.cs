using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<Vault> GetAll()
    {
      string sql = @"
      SELECT * 
      FROM vaults v
      JOIN accounts a on v.creatorId = a.id;";
      return _db.Query<Vault, Account, Vault>(sql, (v, a) =>
      {
        v.Creator = a;
        return v;
      }).ToList();
    }
    public Vault GetById(int vaultId)
    {
      string sql = @"
      SELECT *
      FROM vaults v
      JOIN accounts a on v.creatorId = a.id
      WHERE v.id = @vaultId;";
      return _db.Query<Vault, Account, Vault>(sql, (v, a) =>
      {
        v.Creator = a;
        return v;
      }, new{vaultId}).FirstOrDefault();
    }

      public Vault Create(Vault data)
    {
        var sql = @"
        INSERT INTO vaults(
          creatorId,
          name,
          description,
          isPrivate
        )
        VALUES (
          @CreatorId,
          @Name,
          @Description,
          @IsPrivate
        );
        SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    public void Delete(int vaultId)
    {
      string sql = "DELETE FROM vaults WHERE id = @vaultId LIMIT 1;";
      var affectedRows = _db.Execute(sql, new {vaultId});
      if(affectedRows == 0)
      {
        throw new System.Exception("Unable to Delete");
      }
    }

    public Vault Edit(Vault data)
    {
      string sql = @"
      UPDATE vaults
        SET
          name = @Name,
          description = @Description,
          creatorId = @CreatorId,
          isPrivate = @IsPrivate
        WHERE id = @Id
        LIMIT 1";

    var rowsAffected = _db.Execute(sql, data);
    if(rowsAffected == 0)
    {
      throw new System.Exception("unable to edit");
    }
    return data;
    }
  }
}