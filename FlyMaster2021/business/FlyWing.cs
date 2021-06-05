using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FlyMaster2021.business
{
    public class FlyWing
    {
        /// <summary>
        /// 37 points.
        /// 
        /// </summary>
        private List<Tuple<double, double>> points;
        private double[] xs;
        private double[] ys;
  
        public double Area {
            get
            {
                //TODO: How is final point calculated? Need formula from David.
                float wa = 0;
                float midX = Convert.ToSingle((xs[16] - xs[0]) / 2.0);
                float midY = Convert.ToSingle((ys[16] - ys[0]) / 2.0);
                int p;
                for (p = 0; p < 36; p++)
                {
                    float outLen = Convert.ToSingle(Math.Sqrt(Math.Pow(xs[p + 1] - xs[p], 2) + Math.Pow(ys[p + 1] - ys[p], 2)));
                    float base1 = Convert.ToSingle(Math.Sqrt(Math.Pow(xs[p] - midX, 2) + Math.Pow(ys[p] - midY, 2)));
                    float base2 = Convert.ToSingle(Math.Sqrt(Math.Pow(xs[p + 1] - midX, 2) + Math.Pow(ys[p + 1] - midY, 2)));
                    float heron = Convert.ToSingle((outLen + base1 + base2) / 2.0);
                    wa = wa + Convert.ToSingle(Math.Sqrt(heron * (heron - outLen) * (heron - base1) * (heron - base2)));
                }
                return wa;
            }
        }
        public double Perimeter { 
            get 
            {
                float wp = 0;
                //xs[37] = xs[0];
                //ys[37] = ys[0];
                int p;
                for (p = 0; p < 36; p++)
                {
                    float tempDist = 0;
                    tempDist = Convert.ToSingle(Math.Sqrt(Math.Pow(xs[p + 1] - xs[p], 2) + Math.Pow(ys[p + 1] - ys[p], 2)));
                    wp += tempDist;
                }
                return wp;
            }
        } 
        
        public double Length { 
            get
            {
                float wl = 0;
                wl = Convert.ToSingle(Math.Sqrt(Math.Pow(xs[16] - xs[0], 2) + Math.Pow(ys[16] - ys[0], 2)));
                return wl;
            }
        
        }
        public FlyWing(List<Tuple<double, double>> points)    
        {
            this.points = points;
            this.xs = this.points.Select(x => x.Item1).ToArray();
            this.ys = this.points.Select(y => y.Item2).ToArray();
        }
      
    }

}
