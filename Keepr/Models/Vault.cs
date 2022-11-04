namespace Keepr.Models;

using System;
using Keepr.Interfaces;


public class Vault : IHasCreator
{
  public int Id { get; set; }

  public string Name { get; set; }
  public string Description { get; set; }
  public string coverImg { get; set; }
  public bool IsPrivate { get; set; } = false;






  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}
