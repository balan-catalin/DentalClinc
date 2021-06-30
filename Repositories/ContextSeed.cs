using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Repositories.SeedEntity;

namespace Repositories
{
    public class ContextSeed
    {
        public static async Task SeedAsync(DbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!EnumerableExtensions.Any(context.County))
                {
                    var countyData = File.ReadAllText("../Repositories/SeedData/judete.json");
                    var counties = JsonSerializer.Deserialize<List<CountySeedJson>>(countyData);

                    foreach (var county in counties)
                    {
                        await context.County.AddAsync(new County(county.judet));
                    }

                    await context.SaveChangesAsync();
                }

                if (!EnumerableExtensions.Any(context.Locality))
                {
                    var localityData = File.ReadAllText("../Repositories/SeedData/localitati.json");
                    var localities = JsonSerializer.Deserialize<List<LocalitySeedJson>>(localityData);
                    List<County> counties = await context.County.ToListAsync();

                    foreach (var locality in localities)
                    { 
                        var entity = counties.FirstOrDefault(
                            x => String.Compare(
                                x.Name, locality.judet,
                                CultureInfo.CurrentCulture, 
                                CompareOptions.IgnoreNonSpace) == 0);

                        if (entity != null)
                        {
                            int countyId = entity.Id;
                            await context.Locality.AddAsync(new Locality(locality.diacritice, countyId));
                        }
                        else
                        {
                            Console.WriteLine(locality + "=> Is not Found");
                        }
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ContextSeed>();
                logger.LogError(e.Message);
            }
        }
    }
}
