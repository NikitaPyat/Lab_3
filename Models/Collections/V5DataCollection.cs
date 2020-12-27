using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace Lab_2.Models.Collections
{
    public class V5DataCollection : V5Data, IEnumerable<DataItem>
    {
        public List<DataItem> Ditems { get; set; }
        public Dictionary<System.Numerics.Vector2, System.Numerics.Vector2> dic { get; set; }

        public V5DataCollection(string s, DateTime t) : base(s, t)
        {
            dic = new Dictionary<Vector2, Vector2>();
        }

        public V5DataCollection(string name)
        {
            try
            {
                DataItem tmp;
                using StreamReader str = new StreamReader(name);
                dic = new Dictionary<Vector2, Vector2>();
                Ditems = new List<DataItem>();

                Vector2 one, two;
                string l2;
                float x, y, x_1, y_1;
                info = str.ReadLine();
                date = DateTime.Parse(str.ReadLine());
                string l;
                while ((l = str.ReadLine()) != null){
                    l2 = l;
                    string[] mass = l2.Split(new char[] { ' ' });

                    x = float.Parse(mass[0]);
                    y = float.Parse(mass[1]);
                    x_1 = float.Parse(mass[2]);
                    y_1 = float.Parse(mass[3]);

                    one = new Vector2(x, y);
                    two = new Vector2(x_1, y_1);
                    dic.Add(one, two);
                    tmp = new DataItem(one, two);
                    Ditems.Add(tmp);
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Name is empty");
            }
            catch (FormatException)
            {
                Console.WriteLine("Misunderstanding string ");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found");
            }
            catch (IOException)
            {
                Console.WriteLine("Unacceptable name");
            }
        }

        public void InitRandom(int nItems, float xmax, float ymax, float minValue, float maxValue)
        {
            Random r = new Random(123);
            float x, y, data_x, data_y;
            Vector2 point, value;
            for (int i = 0; i < nItems; i++)
            {

                x = (float)r.NextDouble();
                y = (float)r.NextDouble();
                data_x = (float)r.NextDouble();
                data_y = (float)r.NextDouble();
                data_x = minValue + (maxValue - minValue) * data_x;
                data_y = minValue + (maxValue - minValue) * data_y;
                x = xmax * x;
                y = ymax * y;
                point = new Vector2(x, y);
                value = new Vector2(data_x, data_y);
                dic.Add(point, value);
            }
        }

        public override Vector2[] NearEqual(float eps)
        {
            List<Vector2> vec = new List<Vector2>();
            foreach (KeyValuePair<Vector2, Vector2> keys in dic)
            {
                Vector2 zn = keys.Value;
                if (Math.Abs(zn.X - zn.Y) <= eps)
                    vec.Add(zn);
            }
            Vector2[] res = vec.ToArray();
            return res;
        }

        public override string ToString()

        {
            string str = "V5DataCollection(s): " + info + " " + date.ToString() + "\nNumber of elements: " + dic.Count + "\n";
            return str;
        }

        public override string ToLongString()
        {
            string str = "V5DataCollection\n";
            str += info + " " + date.ToString() + "\nNumber of elements: " + dic.Count + "\n";
            foreach (KeyValuePair<Vector2, Vector2> key in dic)
            {
                str += key.Key + " " + key.Value + "\n";
            }
            return str;
        }

        public string ToLongString(string format)
        {
            string str = "V5DataCollection(ls):" + info + " " + date.ToString(format) + "\nNumber of elements: " + dic.Count + "\n";
            foreach (KeyValuePair<Vector2, Vector2> pair in dic)
            {
                str += pair.Key + " " + pair.Value.ToString(format) + "\n";
            }
            return str;
        }

        public IEnumerator<DataItem> GetEnumerator()
        {
            List<DataItem> list = new List<DataItem>();
            Vector2 val, coord;
            DataItem addition;

            foreach (KeyValuePair<Vector2, Vector2> pair in dic)
            {
                val = pair.Value;
                coord = pair.Key;
                addition = new DataItem(coord, val);
                list.Add(addition);
            }
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            List<DataItem> list = new List<DataItem>();
            Vector2 value, coordinate;
            DataItem tmp;

            foreach (KeyValuePair<Vector2, Vector2> pair in dic)
            {
                coordinate = pair.Key;
                value = pair.Value;
                tmp = new DataItem(coordinate, value);
                list.Add(tmp);
            }
            return list.GetEnumerator();
        }

    }
}
