namespace Keepr.Models;
using System;
using Keepr.Interfaces;


public class Profile : IDbItem<string>
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Picture { get; set; }
  public string CoverImg { get; set; } = "https://images.unsplash.com/photo-1445998559126-132150395033?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTYwfHx0cmVlc3xlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60";
  public DateTime CreatedAt { get ; set ; }
  public DateTime UpdatedAt { get ; set ; }
}

public class Account : Profile
{
  public string Email { get; set; }
}
