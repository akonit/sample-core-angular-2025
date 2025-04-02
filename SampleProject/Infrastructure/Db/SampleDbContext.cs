using Application.Dal.Weather;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Db
{
    public class SampleDbContext : DbContext
    {
        public DbSet<WeatherSettings> WeatherSettings { get; set; }

        public string? DbPath { get; private set; }

        public SampleDbContext(DbContextOptions<SampleDbContext> options)
        : base(options)
        {
            Init();
        }

        public SampleDbContext()
        {
            Init();
        }

        private void Init()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "sample.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}