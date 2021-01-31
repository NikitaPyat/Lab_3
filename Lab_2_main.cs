using Lab_2.Models;
using Lab_2.Models.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Lab_2
{
    public class Lab_1_main
    {
        static void Main(string[] args)
        {
            V5DataCollection a = new V5DataCollection("file.txt");
            Console.WriteLine(a.ToLongString("f5"));
            V5MainCollection b = new V5MainCollection();
            b.AddDefaults();
            Console.WriteLine(b.ToString());

            Vector2 coord;
            coord.X = 1;
            coord.Y = 2;

            Console.WriteLine("\nMaxDistance");
            Console.WriteLine(b.MaxDistance(coord));
            Console.WriteLine("MaxDistanceItem");
            foreach (DataItem s1 in b.MaxDistanceItems(coord))
                Console.WriteLine(s1.ToLongString("f5"));
            Console.WriteLine("DataItems");
            foreach (DataItem s2 in b.Ditems)
                Console.WriteLine(s2.ToLongString("f5"));


            V5MainCollection c = new V5MainCollection();
            c.DataChanged += Cout;
            c.AddDefaults();
            c[1] = new V5DataCollection("MainCollection", new DateTime()){info = "Rename"};
            c.Remove("Rename", c[1].dateD);

        }
        static void Cout(object source, DataChangedEventArgs args)
        {
            Console.WriteLine(args);
        }
    }
}

