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


  [HttpGet]
  public ActionResult<List<Keep>> GetAllKeeps()
  {
    try
    {
      List<Keep> keeps = _ks.GetAllKeeps();
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("{keepId}")]

  public ActionResult<Keep> GetKeepById(int keepId)
  {
    try
    {
      var keep = _ks.GetKeepById(keepId);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


 [HttpPut("{keepId}")]
    [Authorize]
    public async Task<ActionResult<Keep>> EditKeep([FromBody] Keep keepData, int keepId)
    {
      try
      {
        Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      keepData.Creator = userInfo;
      keepData.CreatorId = userInfo.Id;
      keepData.Id = keepId;
      Keep keep = _ks.EditKeep(keepData, userInfo?.Id);
        return Ok(keep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



  [HttpDelete("{keepId}")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteKeep(int keepId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _ks.DeleteKeep(keepId, userInfo?.Id);
      return Ok("Keep deleted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
