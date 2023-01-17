
namespace gregSharp.Services;

public class HousesService
{

  private readonly HousesRepository _repo;

  public HousesService(HousesRepository repo)
  {
    _repo = repo;
  }


  internal List<House> Get()
  {
    List<House> house = _repo.Get();
    return house;
  }
  internal House Create(House houseData)
  {
    House house = _repo.Create(houseData);
    return house;
  }
}
