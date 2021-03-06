CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS keeps(
  id int NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId varchar(255) COMMENT 'FK: Creator Id',
  name varchar(255) NOT NULL COMMENT 'Keep Name',
  description varchar(255) NOT NULL COMMENT 'Keep Description',
  img varchar(255) COMMENT 'Keep Picture',
  views int COMMENT 'Keep Views',
  shares int COMMENT 'Keep Shares',
  keeps int COMMENT 'Keeps Count',
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS vaults(
  id int NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId varchar(255) COMMENT 'FK: Creator Id',
  name varchar(255) NOT NULL COMMENT 'Vault Name',
  description varchar(255) NOT NULL COMMENT 'VAult Description',
  isPrivate TINYINT NOT NULL DEFAULT 0,
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS vaultKeep(
  id int NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId varchar(255) COMMENT 'FK: Creator Id',
  vaultId int NOT NULL COMMENT 'FK: Vault Id',
  keepId int NOT NULL COMMENT 'FK: Keep Id',
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY(vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY(keepId) REFERENCES keeps(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

SELECT * FROM keeps;
SELECT * FROM keeps WHERE creatorId = '617320aa2611f06ab4856363';
SELECT * FROM keeps WHERE creatorId = '6144d914509d05dc1e375612';
SELECT * FROM vaults;
SELECT * FROM vaults WHERE creatorId = '617320aa2611f06ab4856363';
SELECT * FROM vaults WHERE creatorId = '6144d914509d05dc1e375612';
SELECT * FROM vaultKeep;
UPDATE keeps
        SET
          name = 'Test',
          description = 'Testing 123',
          img = "https://images.unsplash.com/photo-1599134842279-fe807d23316e?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1932&q=80"
        WHERE id = 2
        LIMIT 1;

        INSERT INTO vaultKeep(
        vaultId,
        keepId
        )
      VALUES (
        2,
        2
          );
    
      SELECT * FROM vaultKeep;
      SELECT * FROM keeps WHERE id = 597;

      SELECT *
      FROM vaults v
      JOIN accounts a ON v.creatorId = a.id;
      WHERE v.creatorId = @profileId;

      UPDATE keeps
        SET 
          keeps = 1 + 1
        WHERE id = 641
        LIMIT 1;

        UPDATE keeps
        SET
          views = 0 + 1
        WHERE id = 641
        LIMIT 1;

      SELECT * FROM keeps WHERE id = 641;