using Keepr.Interfaces;

namespace Keepr.Models;

public class VaultKeep : IDbItem<int>
{
  public int Id { get; set; }

  public int VaultId { get; set; }

  public  int KeepId { get; set; }

  public string CreatorId { get; set; }

  public DateTime CreatedAt { get ; set ; }
  public DateTime UpdatedAt { get ; set ; }
}

