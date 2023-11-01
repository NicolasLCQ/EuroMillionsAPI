using EuroMillionsAPI.Entities;
using EuroMillionsAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace EuroMillionsAPI.Services;

public class DrawService : SharedService
{
    public DrawService(EuromillionDbContext dbContext) : base(dbContext)
    {
    }

    public List<Draw> GetAll()
    {
        return Repository.Draws.ToList();
    }

    public void Add(List<Draw> draws)
    {
        Repository.Draws.AddRange(draws);
        Repository.SaveChanges();
    }

    public void Clear()
    {
        Repository.Draws.ExecuteDelete();
        Repository.SaveChanges();
    }

}
