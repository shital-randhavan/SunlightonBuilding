using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;

namespace Building
{
    class SunlightOnBuilding
    {
        public class point
        {
            public float x;
            public float y;

            public point (float x,float y)
            {
                this.x = x;
                this.y = y;
            }
        };

        static double pointsLength (point p1,point p2)
        {
           return Math.Sqrt(Math.Pow(p2.x - p1.x,2) + Math.Pow(p2.y - p1.y,2));
        }
        static float lengthbil(point[] buiding,point sunpoint)
        {
            int size = buiding.Length;
            point[] buil = new point[size];
            double lengthb=0;
            double value = pointsLength(sunpoint, buiding[0]);
            for (int i=0; i< buiding.Length-1; i++)
            {
               double value1= pointsLength(sunpoint, buiding[i+1]);
                if (value < value1)
                {
                     buil[i] =new point ( buiding[i].x, buiding[i].y) ;
                     value = value1;
                }
                else
                {
                    buil[i] = new point(buiding[i+1].x, buiding[i+1].y);
                    value = value1;
                }
            }
            for (int i = 0; i < buil.Length-2; i++)
            {
                double value2 = pointsLength(buil[0], buil[i + 1]);
                lengthb = lengthb + value2;
            }
            //Console.WriteLine((float)lengthb);
            return (float)lengthb;
        }

        static void Main(string[] args)
        {
            point[] building = {new point(4, 0), new point(4, -5), new point(7, -5), new point(7, 0) };
            point p = new point(1, 1);
            float value= lengthbil(building,p);
            Console.WriteLine("the length of building is {0}",value);


            //point[,] building1 = { {new point(4, 0), new point(4, -5), new point(7, -5), new point(7, 0) },
            //                       { new point((float)0.4, -2), new point((float)0.4, -5), new point((float)2.5, -5),
            //                       new point((float)2.5,-2) } };

            //point p1 = new point((float)-3.5,1);
            //float value1 = 0;
            //for (int i=0; i < building1.Length; i++)
            //{
            //     value1 = lengthbil(building1[i], p);
            //}
            //Console.WriteLine("the length of building is {0}", value1);
        }
    }
}
