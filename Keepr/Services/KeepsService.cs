namespace Keepr.Services;

public class KeepsService
{
  private readonly KeepsRepository _keepsRepo;

  public KeepsService(KeepsRepository keepsRepo)
  {
    _keepsRepo = keepsRepo;
  }

  internal Keep CreateKeep(Keep keepData)
  {
    return _keepsRepo.CreateKeep(keepData);
  }

  internal List<Keep> GetAllKeeps()
  {
    return _keepsRepo.GetAllKeeps();
  }

  internal Keep GetKeepById(int keepId, string userId)
  {
    var keep = _keepsRepo.GetKeepById(keepId);
    if (keep == null)
    {
      throw new Exception("Bad Keep Id");
    }
    if (keep.CreatorId != userId)
    {
      keep.Views++;
      UpdateKeep(keep);
    }
    return keep;
  }

  public void UpdateKeep(Keep k)
  {
    _keepsRepo.EditKeep(k);
  }


  internal Keep EditKeep(Keep keep, string accountId)
  {
    var original = GetKeepById(keep.Id, accountId);
    if (original.CreatorId != accountId)
    {
      throw new Exception("Unauthorized To Edit This Keep");
    }

    original.Name = keep.Name ?? original.Name;
    original.Img = keep.Img ?? original.Img;
    original.Description = keep.Description ?? original.Description;
    // original.Views = keep.Views;

    var updated = _keepsRepo.EditKeep(original);
    return updated;
  }

  internal void DeleteKeep(int keepId, string userId)
  {
    var keep = GetKeepById(keepId, userId);

    if (keep.CreatorId != userId)
    {
      throw new Exception("Unauthorized to Delete Keep");
    }
    _keepsRepo.DeleteKeep(keepId);
  }
}