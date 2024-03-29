﻿using System;

namespace MagiaEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new MagicContext())
            {
                var sport = ctx.Sport;
                Console.WriteLine("Elenco sport memorizzati nel db");
                foreach (var s in sport)
                {
                    Console.WriteLine(s.Nome);
                }

                Console.WriteLine();

                var studenti = ctx.Studenti;
                Console.WriteLine("Elenco studenti con relativo sport praticato");
                foreach (var s in studenti)
                {
                    Console.WriteLine(s.Nome + " pratica " + (s.SportPraticato?.Nome ?? " nessuno sport") );
                }

            }
        }
    }
}
