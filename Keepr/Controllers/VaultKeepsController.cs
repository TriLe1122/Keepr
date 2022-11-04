namespace Keepr.Controllers;


[Authorize]
[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;
  private readonly VaultKeepsService _vks;

  public VaultKeepsController(Auth0Provider auth0provider, VaultKeepsService vks)
  {
    _auth0provider = auth0provider;
    _vks = vks;
  }
}
