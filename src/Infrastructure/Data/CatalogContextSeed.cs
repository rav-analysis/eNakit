using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // catalogContext.Database.Migrate();
                if (!await catalogContext.CatalogBrands.AnyAsync())
                {
                    await catalogContext.CatalogBrands.AddRangeAsync(
                        GetPreconfiguredCatalogBrands());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogTypes.AnyAsync())
                {
                    await catalogContext.CatalogTypes.AddRangeAsync(
                        GetPreconfiguredCatalogTypes());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogItems.AnyAsync())
                {
                    await catalogContext.CatalogItems.AddRangeAsync(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CatalogContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand("Swarovski"),
                new CatalogBrand("Pandora"),
                new CatalogBrand("Bvlgari"),
                new CatalogBrand("Cartier"),
                new CatalogBrand("Chanel")
            };
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
               new CatalogType("Prstenje"),
                new CatalogType("Naušnice"),
                new CatalogType("Lančići"),
                new CatalogType("Narukvice"),
                new CatalogType("Ogrlice"),
                new CatalogType("Privjesci"),
                new CatalogType("Satovi")
            };
        }

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem(1,2, "Zlatni prsten #1", "Zlatni prsten #1", 195M,  "http://catalogbaseurltobereplaced/images/products/1.png"),
                new CatalogItem(4,1, "Zlatna narukvica", "Zlatna narukvica", 300M, "http://catalogbaseurltobereplaced/images/products/2.png"),
                new CatalogItem(6,5, "Zlatni privjesak", "Zlatni privjesak", 100,  "http://catalogbaseurltobereplaced/images/products/3.png"),
                new CatalogItem(1,4, "Srebrena burma", "Srebrena burma", 70, "http://catalogbaseurltobereplaced/images/products/4.png"),
                new CatalogItem(6,3, "Srebreni privjesak planina", "Srebreni privjesak planina", 30M, "http://catalogbaseurltobereplaced/images/products/5.png"),
                new CatalogItem(4,4, "Srebrena narukvica ", "Srebrena narukvica", 40, "http://catalogbaseurltobereplaced/images/products/6.png"),
                new CatalogItem(2,3, "Srebrene naušnice", "Srebrene naušnice",  25, "http://catalogbaseurltobereplaced/images/products/7.png"),
                new CatalogItem(2,1, "Zlatne naušnice", "Zlatne naušnice", 85M, "http://catalogbaseurltobereplaced/images/products/8.png"),
                new CatalogItem(7,2, "Zlatni sat", "Zlatni sat", 120, "http://catalogbaseurltobereplaced/images/products/9.png"),
                new CatalogItem(6,4, "Srebreni privjesak srce", "Srebreni privjesak srce", 50, "http://catalogbaseurltobereplaced/images/products/10.png"),
                new CatalogItem(1,3, "Zlatni prsten #2", "Zlatni prsten #2", 135M, "http://catalogbaseurltobereplaced/images/products/11.png"),
                new CatalogItem(2,2, "Zlatne naušnice", "Zlatne naušnice", 110, "http://catalogbaseurltobereplaced/images/products/12.png")
            };
        }
    }
}
