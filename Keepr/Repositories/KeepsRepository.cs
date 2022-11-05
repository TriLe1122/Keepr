namespace Keepr.Repositories;

public class KeepsRepository : BaseRepository
{
  public KeepsRepository(IDbConnection db) : base(db)
  {
  }

  internal Keep CreateKeep(Keep keepData)
  {
    var sql = @"
             INSERT INTO
             keeps (name, description, img, creatorId)
             VALUES (@Name, @Description, @Img , @CreatorId);
             SELECT LAST_INSERT_ID()
                 ; ";

    // keepData.CreatedAt = DateTime.Now;
    // keepData.UpdatedAt = DateTime.Now;
    int keepId = _db.ExecuteScalar<int>(sql, keepData);
    // keepData.Id = keepId;
    return GetKeepById(keepId);
  }
  internal List<Keep> GetAllKeeps()
  {
    var sql = @"
    SELECT
    k.*,
    COUNT(vk.id) AS Kept,
    a.*
    FROM keeps k
    JOIN accounts a ON a.id = k.creatorId
    LEFT JOIN vaultKeeps vk ON vk.keepId = k.id
    GROUP BY k.id
    ;";
    return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
     {
       keep.Creator = profile;
       return keep;
     }).ToList();
  }

  internal Keep EditKeep(Keep data)
  {
    string sql = @"
                  UPDATE keeps SET
                  name = @name,
                  img = @img,
                  description = @description,
                  views = @views
                  WHERE id = @Id LIMIT 1
                       ;";
    var rows = _db.Execute(sql, data);
    if (rows != 1)
    {
      throw new Exception("Unable to update");
    }

    return data;
  }

  internal void DeleteKeep(int id)
  {
    var sql = @"
              DELETE FROM keeps WHERE id = @id
                  ; ";

    var rows = _db.Execute(sql, new { id });
    if (rows != 1) { throw new Exception("Data is bad or Id is Bad"); }
    return;

  }

  internal Keep GetKeepById(int keepId)
  {
    var sql = @"
    SELECT
    k.*,
    COUNT(vk.id) AS Kept,
    a.*
    FROM keeps k
    JOIN accounts a ON a.id = k.creatorId
    LEFT JOIN vaultKeeps vk ON vk.keepId = k.id
    WHERE k.id = @keepId
    GROUP BY k.id
    ;";
    return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
     {
       keep.Creator = profile;
       return keep;
     }, new { keepId }).FirstOrDefault();
  }
}