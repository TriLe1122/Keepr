namespace Keepr.Services;

public class KeepsService
{
  private readonly KeepsService _keepsRepo;

  public KeepsService(KeepsService keepsRepo)
  {
    _keepsRepo = keepsRepo;
  }
}