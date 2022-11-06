namespace Keepr.Repositories;



public class VaultKeepsRepository : BaseRepository
{
  public VaultKeepsRepository(IDbConnection db) : base(db)
  {
  }

  internal List<VaultKeep> GetAllVaultKeeps()
  {
    string sql = @"
    SELECT *
    FROM vaultKeeps
    ;";

    return _db.Query<VaultKeep>(sql).ToList();
  }


  internal VaultKeep GetVaultKeepById(int vaultKeepId)
  {
    string sql = @"
    SELECT *
    FROM vaultKeeps
    WHERE id = @vaultKeepId
    ;";

    return _db.Query<VaultKeep>(sql, new { vaultKeepId }).FirstOrDefault();
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
      var sql = @"
              INSERT INTO
              vaultKeeps (creatorId, keepId, vaultId)
              VALUES (@CreatorId, @KeepId, @VaultId);
              SELECT LAST_INSERT_ID()
                  ;";

    vaultKeepData.Id = _db.ExecuteScalar<int>(sql, vaultKeepData);
    return GetVaultKeepById(vaultKeepData.Id);
  }

  internal void DeleteVaultKeep(int id)
  {
    var sql = @"
              DELETE FROM vaultKeeps WHERE id = @id
                  ; ";

    var rows = _db.Execute(sql, new { id });
    if (rows != 1) { throw new Exception("Data is bad or Id is Bad"); }
    return;
  }

  internal List<KeepInVault> GetKeepsByVaultId(int vaultId)
  {
    var sql = @"
          SELECT 
            vk.*,
            vk.id AS VaultKeepId,
            k.*,
            a.*
          FROM vaultKeeps vk
          JOIN accounts a ON a.id = vk.creatorId
          Join keeps k On k.id = vk.keepId
          WHERE vk.vaultId = @vaultId
          GROUP BY vk.id
          ;";
        return _db.Query<KeepInVault, Profile, KeepInVault>(sql, (keep, profile) =>
        {
          keep.Creator= profile;
          return keep;
        }, new { vaultId}).ToList();
  }
}