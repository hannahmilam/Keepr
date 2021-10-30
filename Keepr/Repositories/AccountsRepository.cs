using System.Data;
using Keepr.Models;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace Keepr.Repositories
{
    public class AccountsRepository
    {
        private readonly IDbConnection _db;

        public AccountsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Account GetByEmail(string userEmail)
        {
            string sql = "SELECT * FROM accounts WHERE email = @userEmail";
            return _db.QueryFirstOrDefault<Account>(sql, new { userEmail });
        }

        internal Account GetById(string profileId)
        {
            string sql = "SELECT * FROM accounts WHERE id = @profileId";
            return _db.QueryFirstOrDefault<Account>(sql, new { profileId });
        }

        internal Account Create(Account newAccount)
        {
            string sql = @"
            INSERT INTO accounts
              (name, picture, email, id)
            VALUES
              (@Name, @Picture, @Email, @Id)";
            _db.Execute(sql, newAccount);
            return newAccount;
        }

        internal Account Edit(Account update)
        {
            string sql = @"
            UPDATE accounts
            SET 
              name = @Name,
              picture = @Picture
            WHERE id = @Id;";
            _db.Execute(sql, update);
            return update;
        }

        public List<Keep> GetUsersKeeps(string profileId)
        {
        string sql =@"
        SELECT *
        FROM keeps k
        WHERE k.creatorId = @profileId";
        return _db.Query<Keep>(sql, new {profileId}).ToList();
        }

    public List<Vault> GetUsersVaults(string profileId)
    {
      string sql = @"
      SELECT *
      FROM vaults v
      WHERE v.creatorId = @profileId";
      return _db.Query<Vault>(sql, new{profileId}).ToList();
    }
    }
}
