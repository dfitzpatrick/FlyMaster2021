using System;
using System.Collections.Generic;
using System.Text;

namespace FlyMaster2021.business
{
    public class FlyWing
    {
        private List<Tuple<int, int>> points;
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public double Length { get; set; }
        public FlyWing(List<Tuple<int, int>> points)
        {
            this.points = points;
        }
    }

}
