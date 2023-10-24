using EuroMillionsAPI.Entities;
using EuroMillionsAPI.Repository;

namespace EuroMillionsAPI.Services;

public class DrawService : SharedService
{
    public DrawService(EuromillionDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<Draw> getAll()
    {
        return Repository.Draws.ToList();
    }

    public void add(List<Draw> draws)
    {
        Repository.Draws.AddRange(draws);
        Repository.SaveChanges();
    }

}
