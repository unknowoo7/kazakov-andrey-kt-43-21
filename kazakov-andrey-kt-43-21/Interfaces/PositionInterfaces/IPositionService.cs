using kazakov_andrey_kt_43_21.Database;
using kazakov_andrey_kt_43_21.Models;

namespace kazakov_andrey_kt_43_21.Interfaces.PositionInterfaces
{

  public interface IPositionService
  {
    public Position GetPositionById(int id);
  }

  public class PositionService : IPositionService
  {
    private readonly TeacherDbContext _dbContext;

    public PositionService(TeacherDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public Position GetPositionById(int positionId)
    {
      return _dbContext.Positions.Where(d => d.PositionId == positionId).FirstOrDefault();
    }
  }
}
