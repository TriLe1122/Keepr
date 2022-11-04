namespace Keepr.Models;
using System;
using Keepr.Interfaces;


public class Profile : IDbItem<string>
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Picture { get; set; }
  public string CoverImg { get; set; }
  public DateTime CreatedAt { get ; set ; }
  public DateTime UpdatedAt { get ; set ; }
}

public class Account : Profile
{
  public string Email { get; set; }
}
