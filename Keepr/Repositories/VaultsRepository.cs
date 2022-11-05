namespace Keepr.Repositories;



public class VaultsRepository : BaseRepository
{
  public VaultsRepository(IDbConnection db) : base(db)
  {
  }

  internal Vault CreateVault(Vault vaultData)
  {
    var sql = @"
              INSERT INTO
              vaults (name, description, img, creatorId)
              VALUES (@Name, @Description, @Img, @CreatorId);
              SELECT LAST_INSERT_ID()
                  ; ";
    vaultData.CreatedAt = DateTime.Now;
    vaultData.UpdatedAt = DateTime.Now;
    vaultData.Id = _db.ExecuteScalar<int>(sql, vaultData);
    return vaultData;
  }

  internal Vault GetVaultById(int id)
  {
    string sql = @"
                SELECT 
                v.*,
                a.*
                FROM vaults v
                JOIN accounts a ON a.id = v.creatorId
                WHERE v.id = @id
                     ;";
    return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
    {
      vault.Creator = profile;
      return vault;
    }, new { id }).FirstOrDefault();
  }

  internal Vault EditVault(Vault data)
  {
    string sql = @"
                  UPDATE vaults SET
                  name = @Name,
                  description = @Description,
                  img = @Img,
                  isPrivate = @IsPrivate
                  WHERE id = @Id LIMIT 1
                       ;";
    var rows = _db.Execute(sql, data);
    if (rows != 1)
    {
      throw new Exception("Unable to update");
    }

    return data;
  }

  internal void DeleteVault(int id)
  {
    var sql = @"
              DELETE FROM vaults WHERE id = @id
                  ; ";

    var rows = _db.Execute(sql, new { id });
    if (rows != 1) { throw new Exception("Data is bad or Id is Bad"); }
    return;
  }
}