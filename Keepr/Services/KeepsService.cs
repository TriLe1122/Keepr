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
}