using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<Keep> GetAll()
    {
      string sql = @"
      SELECT *
      FROM keeps k
      JOIN accounts a on k.creatorId = a.id;";
      return _db.Query<Keep, Profile, Keep>(sql, (k, a) =>
      {
        k.Creator = a;
        return k;
      }).ToList();
    }

    public Keep GetById(int keepId)
    {
      string sql = @"
      UPDATE keeps
        SET 
          views = views + 1
        WHERE id = @keepId
        LIMIT 1;
      SELECT *
      FROM keeps k
      JOIN accounts a on k.creatorId = a.id
      WHERE k.id = @keepId;
       ";
      return _db.Query<Keep, Profile, Keep>(sql, (k, a) =>
      {
        k.Creator = a;
        return k;
      }, new{keepId}).FirstOrDefault();
    }
    public Keep Create(Keep data)
    {
      string sql = @"
      INSERT INTO keeps(
        creatorId,
        name,
        description,
        views,
        img,
        shares,
        keeps
        )
      VALUES(
        @CreatorId,
        @Name,
        @Description,
        @Views,
        @img,
        @Shares,
        @Keeps
        );
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    public Keep Edit(Keep data)
    {
      string sql = @"
      UPDATE keeps
        SET
          name = @Name,
          description = @Description,
          creatorId = @CreatorId,
          img = @Img
        WHERE id = @Id
        LIMIT 1";

        var rowsAffected = _db.Execute(sql, data);
        if(rowsAffected == 0)
        {
          throw new System.Exception("unable to edit");
        }
        return data;
    }

    public void Delete(int keepId)
    {
      string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1;";
      var affectedRows = _db.Execute(sql, new {keepId});
      if(affectedRows == 0)
      {
        throw new Exception("unable to delete");
      }
    }
  }
}