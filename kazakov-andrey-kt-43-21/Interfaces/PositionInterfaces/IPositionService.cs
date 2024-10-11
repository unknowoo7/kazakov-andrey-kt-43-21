using kazakov_andrey_kt_43_21.Database;
using kazakov_andrey_kt_43_21.Models;
using Microsoft.EntityFrameworkCore;

namespace kazakov_andrey_kt_43_21.Interfaces.PositionInterfaces
{

  public interface IPositionService
  {
    public Position GetPositionById(int id);
  }

  public class PositionService
  {
    private readonly TeacherDbContext _dbContext;

    public PositionService(TeacherDbContext dbContext)
    {
      this._dbContext = dbContext;
    }

    public Position GetPosition(int id)
    {
      return _dbContext.Positions.Where(d => d.PositionId == id).FirstOrDefault();
    }
  }
}
