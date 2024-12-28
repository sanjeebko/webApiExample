using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data;

public class NZWalksDbContext:DbContext
{
    public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : base(options)
    {

    }

    public DbSet<Walk> Walks { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Difficulty> Difficulties { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Difficulty>().HasData(
            [
                new Difficulty { Id = Guid.Parse("94e8d315-fecb-4f5a-9635-dc67bfaf0171"), Name = "Easy" },
                new Difficulty { Id = Guid.Parse("fc18cd37-a3d9-4035-8eed-ab32928e7c53"), Name = "Moderate" },
                new Difficulty { Id = Guid.Parse("0d21bba8-67a5-407f-8f7a-91d27d96eb49"), Name = "Hard" },
            ]);
        modelBuilder.Entity<Region>().HasData(
            [
             new Region{ Code="AUK", Id=Guid.Parse("9d8ac206-4b02-45ca-85ad-7642142bcda5"), Name="Auckland", RegionImageUrl="https://www.doc.govt.nz/globalassets/images/conservation/nz-walks/north-island/auckland/auckland-region.jpg"},
                new Region{ Code="WKO", Id=Guid.Parse("e743e16b-1035-49ad-a055-a5221f1a569e"), Name="Waikato", RegionImageUrl="https://www.doc.govt.nz/globalassets/images/conservation/nz-walks/north-island/waikato/waikato-region.jpg"},
                new Region{ Code="BOP", Id=Guid.Parse("815c05bd-8302-4f41-a714-0e1bb524dfbf"), Name="Bay of Plenty", RegionImageUrl="https://www.doc.govt.nz/globalassets/images/conservation/nz-walks/north-island/bay-of-plenty/bay-of-plenty-region.jpg"},
                new Region{ Code="GIS", Id=Guid.Parse("5006f660-2478-4fab-aa2c-10168ed81f0c"), Name="Gisborne", RegionImageUrl="https://www.doc.govt.nz/globalassets/images/conservation/nz-walks/north-island/gisborne/gisborne-region.jpg"},
                new Region{ Code="HKB", Id=Guid.Parse("04dbbc3e-26c3-4762-9b83-505596273903"), Name="Hawke's Bay", RegionImageUrl="https://www.doc.govt.nz/globalassets/images/conservation/nz-walks/north-island/hawkes-bay/hawkes-bay-region.jpg"},
            ]
           );
     
    }

}
