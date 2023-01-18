
namespace gregSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{

  private readonly HousesService _housesService;

  public HousesController(HousesService housesService)
  {
    _housesService = housesService;
  }

  [HttpGet]
  public ActionResult<List<House>> Get()
  {
    try
    {
      List<House> houses = _housesService.Get();
      return Ok(houses);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{Id}")]
  public ActionResult<House> Get(int Id)
  {
    try
    {
      House house = _housesService.Get(Id);
      return house;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPost]
  public ActionResult<House> Create([FromBody] House houseData)
  {
    try
    {
      House house = _housesService.Create(houseData);
      return Ok(house);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPut("{Id}")]
  public ActionResult<House> Update([FromBody] House houseData, int Id)
  {
    try
    {
      House house = _housesService.Update(houseData, Id);
      return Ok(house);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{Id}")]
  public ActionResult<string> Remove(int Id)
  {
    try
    {
        string message = _housesService.Remove(Id);
        return message;
    }
    catch (Exception e)
    {
        return BadRequest(e.Message);
    }
  }
}
