using processDataShare.Models;

namespace processDataShare.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.OpelArmrestDatas.Any())
                {
                    context.OpelArmrestDatas.AddRange(new List<OpelArmrestData>()
                    {
                        new OpelArmrestData()
                        {

                            heatingSetPointMax = 15,
                            foldingTime = 12,
                            foldingSetPointMax = 55,
                            cycleTime = 25,
                            mouldNumber = 222,
                            recipe = 1,
                            pyroIndicatorOnOff = false,

                         },
                        new OpelArmrestData()
                        {

                            heatingSetPointMax = 14,
                            foldingTime = 12,
                            foldingSetPointMax = 55,
                            cycleTime = 25,
                            mouldNumber = 222,
                            recipe = 1,
                            pyroIndicatorOnOff = false,

                         },
                       new OpelArmrestData()
                        {

                            heatingSetPointMax = 13,
                            foldingTime = 12,
                            foldingSetPointMax = 55,
                            cycleTime = 25,
                            mouldNumber = 222,
                            recipe = 1,
                            pyroIndicatorOnOff = false,

                         },
                        new OpelArmrestData()
                        {

                            heatingSetPointMax = 12,
                            foldingTime = 12,
                            foldingSetPointMax = 55,
                            cycleTime = 25,
                            mouldNumber = 222,
                            recipe = 1,
                            pyroIndicatorOnOff = false,

                         },
                    });
                    context.SaveChanges();
                }

            }
        }


    }
}
