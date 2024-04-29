using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levesek
{
    internal class Program
    {
        static Adatbazis db = new Adatbazis();
        static List<Levesek> levesek;

        static void Main(string[] args)
        {
            levesek = db.getAllLevesek();

            feladat01();
            feladat02();

            Console.WriteLine("Program vége");
            Console.ReadLine();
        }


        private static void feladat02()
        {
            Console.WriteLine("2. feladat:");
            double maxkaloria = levesek.Max(a => a.kaloria);
            Levesek leveseks = levesek.Find(a => a.kaloria == maxkaloria);
            Console.WriteLine($"\tA legmagasabb kalóriájú leves neve: {leveseks.megnevezes}");
        }

        private static void feladat01()
        {
            Console.WriteLine("1. feladat:");
            Console.WriteLine($"\tA levesek száma: {levesek.Count} db");
        }
    }
}
