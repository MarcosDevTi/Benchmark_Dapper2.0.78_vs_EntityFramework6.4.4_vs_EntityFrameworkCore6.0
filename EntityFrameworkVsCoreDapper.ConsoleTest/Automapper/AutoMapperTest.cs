using AutoMapper;
using EntityFrameworkVsCoreDapper.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Automapper
{
    public class AutoMapperTest
    {
        public AutoMapperTest(int take)
        {
            var context = new TesteContext();
            var customers = context.Customers.Take(take).ToList();
            var count = customers.Count();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, CustomerViewModel>()
                .ForMember(d => d.StreetAA, o => o.MapFrom(s => s.Street));
            });
            config.CompileMappings();


            var mapper = new Mapper(config);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var viewModels = mapper.Map<IEnumerable<CustomerViewModel>>(customers);
            stopwatch.Stop();
            Montrer($"Count: " + count);
            var result = string.Format("Temps écoulé Automaper: {0}", stopwatch.Elapsed);
            Montrer(result);

            context.Dispose();
        }

        public void Montrer(string numero)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(numero);
            Console.ResetColor();
        }
    }
}
