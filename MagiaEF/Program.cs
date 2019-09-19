using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MagiaEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new MagicContext())
            {
                var sport1 = ctx.Sport.Where(s => s.Id == 1);

                var sport2 = from c in ctx.Sport
                             where c.Id == 1
                             select c;

                var sport3 = ctx.Sport.FromSql("select * from sport where id=1");


                var sport = ctx.Sport.ToList();
                Console.WriteLine("Elenco sport memorizzati nel db");
                foreach (var s in sport)
                {
                    Console.WriteLine(s.Nome);
                }

                Console.WriteLine();

                var studenti = ctx.Studenti.ToList();
                Console.WriteLine("Elenco studenti con relativo sport praticato");
                foreach (var s in studenti)
                {
                    Console.WriteLine(s.Nome + " pratica " + (s.SportPraticato?.Nome ?? " nessuno sport") );
                }

            }
        }
    }
}
