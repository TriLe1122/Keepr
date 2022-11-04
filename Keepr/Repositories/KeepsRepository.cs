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

    keepData.CreatedAt = DateTime.Now;
    keepData.UpdatedAt = DateTime.Now;
      int keepId = _db.ExecuteScalar<int>(sql, keepData);
    keepData.Id = keepId;
    return keepData;
  }
}