namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;
  private readonly VaultsService _vs;

  public VaultsController(Auth0Provider auth0provider, VaultsService vs)
  {
    _auth0provider = auth0provider;
    _vs = vs;
  }
}
