
namespace gregSharp.Repositories;

public class HousesRepository
{

  private readonly IDbConnection _db;

  public HousesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<House> Get()
  {
    string sql = @"
    SELECT
    *
    FROM houses
    ";
    List<House> houses = _db.Query<House>(sql).ToList();
    return houses;
  }
  internal House Get(int id)
  {
    string sql = @"
    SELECT
    *
    FROM houses
    WHERE id = @id;
    ";
    House house = _db.Query<House>(sql, new { id }).FirstOrDefault();
    return house;
  }

  internal House Create(House houseData)
  {
    string sql = @"
    INSERT INTO houses
    (description, bathroom, bedroom, sqFt, price, imgUrl)
    VALUES
    (@description, @bathroom, @bedroom, @sqFt, @price, @imgUrl);

    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, houseData);
    houseData.Id = id;
    return houseData;
  }

  internal bool Update(House houseData)
  {
    string sql = @"
    UPDATE houses
        SET
        description = @description,
        bathroom = @bathroom,
        bedroom = @bedroom,
        sqft = @sqft,
        price = @price,
        imgUrl = @imgUrl
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, houseData);
    return rows > 0;

  }

  internal bool Remove(int id)
  {
    string sql = @"
    DELETE fROM houses
    Where id = @id;
    ";
    int rows = _db.Execute(sql, new { id });
    return rows > 0;
  }
}
