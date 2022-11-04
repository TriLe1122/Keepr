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


  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData)
  {
    try
    {
      var userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      keepData.CreatorId = userInfo.Id;
      Keep createdKeep = _ks.CreateKeep(keepData);
      createdKeep.Creator = userInfo;
      return Ok(createdKeep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }




}
