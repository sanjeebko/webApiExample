using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDifficultyandRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0d21bba8-67a5-407f-8f7a-91d27d96eb49"), "Hard" },
                    { new Guid("94e8d315-fecb-4f5a-9635-dc67bfaf0171"), "Easy" },
                    { new Guid("fc18cd37-a3d9-4035-8eed-ab32928e7c53"), "Moderate" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("04dbbc3e-26c3-4762-9b83-505596273903"), "HKB", "Hawke's Bay", "https://www.doc.govt.nz/globalassets/images/conservation/nz-walks/north-island/hawkes-bay/hawkes-bay-region.jpg" },
                    { new Guid("5006f660-2478-4fab-aa2c-10168ed81f0c"), "GIS", "Gisborne", "https://www.doc.govt.nz/globalassets/images/conservation/nz-walks/north-island/gisborne/gisborne-region.jpg" },
                    { new Guid("815c05bd-8302-4f41-a714-0e1bb524dfbf"), "BOP", "Bay of Plenty", "https://www.doc.govt.nz/globalassets/images/conservation/nz-walks/north-island/bay-of-plenty/bay-of-plenty-region.jpg" },
                    { new Guid("9d8ac206-4b02-45ca-85ad-7642142bcda5"), "AUK", "Auckland", "https://www.doc.govt.nz/globalassets/images/conservation/nz-walks/north-island/auckland/auckland-region.jpg" },
                    { new Guid("e743e16b-1035-49ad-a055-a5221f1a569e"), "WKO", "Waikato", "https://www.doc.govt.nz/globalassets/images/conservation/nz-walks/north-island/waikato/waikato-region.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0d21bba8-67a5-407f-8f7a-91d27d96eb49"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("94e8d315-fecb-4f5a-9635-dc67bfaf0171"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("fc18cd37-a3d9-4035-8eed-ab32928e7c53"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("04dbbc3e-26c3-4762-9b83-505596273903"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5006f660-2478-4fab-aa2c-10168ed81f0c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("815c05bd-8302-4f41-a714-0e1bb524dfbf"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9d8ac206-4b02-45ca-85ad-7642142bcda5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e743e16b-1035-49ad-a055-a5221f1a569e"));
        }
    }
}
