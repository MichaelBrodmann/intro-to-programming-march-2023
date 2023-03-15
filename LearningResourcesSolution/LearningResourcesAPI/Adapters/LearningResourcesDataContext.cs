using LearningResourcesAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace LearningResourcesAPI.Adapters;

public class LearningResourcesDataContext : DbContext
{
    public LearningResourcesDataContext(DbContextOptions<LearningResourcesDataContext> options): base(options)
    {
        
    }
    public DbSet<LearningResourcesEntity> LearningResources { get; set; }
}
