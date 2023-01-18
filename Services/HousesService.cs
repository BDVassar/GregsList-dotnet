
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
  internal House Get(int id)
  {
    House house = _repo.Get(id);
    if (house == null)
    {
      throw new Exception("no house by that id");
    }
    return house;
  }
  internal House Create(House houseData)
  {
    House house = _repo.Create(houseData);
    return house;
  }

  internal House Update(House houseData, int Id)
  {
    House Original = Get(Id);
    Original.Description = houseData.Description ?? Original.Description;
    Original.Bathroom = houseData.Bathroom ?? Original.Bathroom;
    Original.Bedroom = houseData.Bedroom ?? Original.Bedroom;
    Original.SqFt = houseData.SqFt ?? Original.SqFt;
    Original.Price = houseData.Price ?? Original.Price;
    Original.ImgUrl = houseData.ImgUrl ?? Original.ImgUrl;

    bool edited = _repo.Update(Original);
    if (edited == false)
    {
      throw new Exception("House was not deleted");
    }
    return Original;
  }

  internal string Remove(int id)
  {
    House house = Get(id);

    bool deleted = _repo.Remove(id);
    if (deleted == false)
    {
      throw new Exception("No House was Deleted");
    }
    return "The House has been Deleted";
  }
}
