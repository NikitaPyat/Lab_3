using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Lab_2.Models
{
    public struct DataItem 
    {
        public Vector2 coord { get; set; }
        public Vector2 val { get; set; }

        public DataItem(Vector2 c, Vector2 v)
        {
            coord = c;
            val = v;
        }

        public override string ToString()
        {
            return coord.ToString() + " " + val.ToString();
        }

        public string ToString(string format)
        {
            return coord.ToString(format) + " " + val.ToString(format);
        }

        public string ToLongString(string format)
        {
            return coord.ToString(format) + " " + val.ToString(format) + " " + val.Length().ToString(format);
        }
    }
}
