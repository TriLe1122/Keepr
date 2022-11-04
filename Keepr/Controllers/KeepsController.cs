namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;
  private readonly KeepsService _ks;

  public KeepsController(Auth0Provider auth0provider, KeepsService ks)
  {
    _auth0provider = auth0provider;
    _ks = ks;
  }
}
