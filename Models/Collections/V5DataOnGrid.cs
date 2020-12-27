using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab_2.Models.Collections
{
    class V5DataOnGrid : V5Data, IEnumerable<DataItem>
    {
        public Grid2D net { get; set; }
        public Vector2[,] mas { get; set; }

        public V5DataOnGrid(string s, DateTime d, Grid2D gr) : base(s, d)
        {
            net = gr;
            mas = new Vector2[net.x_kol, net.y_kol];
        }

        public void InitRandom(float minValue, float maxValue)
        {
            Random rand = new Random(123);
            float rand1, rand2, minv, maxv;
            Vector2 coordinate, value;

            for (int i = 0; i < net.x_kol; i++)
            {
                for (int j = 0; j < net.y_kol; j++)
                {
                    rand1 = (float)rand.NextDouble();
                    rand2 = (float)rand.NextDouble();
                    minv = minValue * rand1 + maxValue * (1 - rand1);
                    maxv = minValue * rand2 + maxValue * (1 - rand2);
                    mas[i, j] = new Vector2(minv, maxv);

                    coordinate.X = i;
                    coordinate.Y = j;
                    value.X = minv;
                    value.Y = maxv;
                }
            }
        }


        public override Vector2[] NearEqual(float eps)
        {
            List<Vector2> list = new List<Vector2>();
            for (int i = 0; i < net.x_kol; i++)
                for (int j = 0; j < net.y_kol; j++)
                    if (Math.Abs(mas[i, j].X - mas[i, j].Y) <= eps)
                        list.Add(mas[i, j]);
            Vector2[] array = list.ToArray();
            return array;
        }

        public override string ToString()
        {
            return "V5DataOnGrid\n" + info + " " + date.ToString() + " " + net.ToString() + "\n";
        }

        public override string ToLongString()
        {
            string str = "V5DataOnGrid\n";
            str += info + " " + date.ToString() + " " + net.ToString() + "\n";
            for (int i = 0; i < net.x_kol; i++)
                for (int j = 0; j < net.x_kol; j++)
                {
                    str += "[" + i + ", " + j + "] " + "(" + mas[i, j].X + ", " + mas[i, j].Y + ")\n";
                }
            str += "\n";
            return str;
        }

        public string ToLongString(string format)
        {
            string str = "V5DataOnGrid(ls):\n" + info + " " + date.ToString(format) + " " + net.ToString(format) + "\n";
            for (int i = 0; i < net.x_kol; i++)
                for (int j = 0; j < net.y_kol; j++)
                {
                    str += "Score for node " + "[" + i + "," + j + "] " + " is " + "(" + mas[i, j].X + "," + mas[i, j].Y + ")\n";
                }

            return str;
        }

        public static explicit operator V5DataCollection(V5DataOnGrid d)
        {
            V5DataCollection Out;
            Vector2 x, x_1;
            Out = new V5DataCollection(d.info, d.date);

            for (int i = 0; i < d.net.x_kol; i++)
                for (int j = 0; j < d.net.y_kol; j++)
                {
                    x = new Vector2(i, j);
                    x_1 = new Vector2(d.mas[i, j].X, d.mas[i, j].Y);
                    Out.dic.Add(x, x_1);
                }
            return Out;
        }

        public IEnumerator<DataItem> GetEnumerator()
        {
            List<DataItem> list = new List<DataItem>();
            DataItem tmp;
            Vector2 coordinate, value;
            for (int i = 0; i < net.x_kol; i++)
                for (int j = 0; j < net.y_kol; j++)
                {
                    coordinate.X = i;
                    coordinate.Y = j;
                    value.X = mas[i, j].X;
                    value.Y = mas[i, j].Y;
                    tmp = new DataItem(coordinate, value);
                    list.Add(tmp);
                }
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            List<DataItem> list = new List<DataItem>();
            DataItem tmp;
            Vector2 coordinate, value;
            for (int i = 0; i < net.x_kol; i++)
                for (int j = 0; j < net.y_kol; j++)
                {
                    coordinate.X = i;
                    coordinate.Y = j;
                    value.X = mas[i, j].X;
                    value.Y = mas[i, j].Y;
                    tmp = new DataItem(coordinate, value);
                    list.Add(tmp);
                }
            return list.GetEnumerator();
        }
    }
}
