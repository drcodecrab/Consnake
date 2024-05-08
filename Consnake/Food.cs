using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consnake
{
    class Food
    {
        public Point point { get; set; }
        public Boolean gegessen { get; set; }

        /// <summary>
        /// die koordinaten wo das essen spawnen soll
        /// </summary>
        /// <param name="_x">in welcher zeile</param>
        /// <param name="_y">in welcher spalte</param>
        public Food(int _x, int _y) 
        {
            point = new Point(0,0);
            gegessen = new bool();
            point.x = _x;
            point.y = _y;

            gegessen = false;
        }   
    }
}
