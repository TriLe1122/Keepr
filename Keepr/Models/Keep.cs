namespace Keepr.Models;

using System;
using Keepr.Interfaces;


public class Keep : IHasCreator
{
  public int Id { get; set; }

  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; } = "https://images.unsplash.com/photo-1667517879903-7bf7371e73e0?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=774&q=80";
  public int Views { get; set; } = 0;


  
  public int Kept { get; set; }

//  extra
  public string CreatorId { get ; set ; }
  public Profile Creator { get ; set ; }
  public DateTime CreatedAt { get ; set ; }
  public DateTime UpdatedAt { get ; set ; }
}
