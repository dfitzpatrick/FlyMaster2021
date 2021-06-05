using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Dynamic;
using System.Globalization;

namespace FlyMaster2021.business
{
    public class FlyImporter
    {
        
        
        /// <summary>
        /// Main constructor for the importer. 
        /// </summary>
        /// <param name="flyDirectory">The directory to read .CSV files</param>
        public FlyImporter()
        {

        }
        private List<FlyWing> _objects = new List<FlyWing>();
        public List<FlyWing> Objects {
            get { 
                return this._objects; 
            } 
        }
        public FlyImporter(List<FlyWing> objects)
        {
            this._objects = objects;
        }
        public static FlyImporter importFromDirectory(string flyDirectory)
        {
            DirectoryInfo d = new DirectoryInfo(flyDirectory);
            FileInfo[] files = d.GetFiles("*.csv");
            List<FlyWing> container = new List<FlyWing>();
            foreach (FileInfo f in files)
            {
                using (StreamReader sr = new StreamReader(f.FullName))
                //using (var csv = new CsvReader(sr, System.Globalization.CultureInfo.InvariantCulture))
                {
                    // skip the header row
                    sr.ReadLine();

                    // only one record of data per file (for now)
                    var data = sr.ReadLine().Split(',');
                    
                   List<Tuple<double, double>> points = FlyImporter.getCoordinates(data);
                    container.Add(new FlyWing(points));
                }

            }
            return new FlyImporter(container);
        }
        private static List<Tuple<double, double>> getCoordinates(string[] csv)
        {
            List<Tuple<double, double>> container = new List<Tuple<double, double>>();
            for (int i = 0; i < csv.Length; i += 2)
            {
                try
                {
                    double v1 = Double.Parse(csv[i], CultureInfo.InvariantCulture);
                    double v2 = Double.Parse(csv[i + 1], CultureInfo.InvariantCulture);
                    container.Add(Tuple.Create(v1, v2));

                }
                catch (FormatException ex)
                {
                    throw new FormatException($"{csv[i]} / {csv[i + 1]} Cannot be converted to int");
                }
                catch (IndexOutOfRangeException ex)
                {
                    throw new IndexOutOfRangeException("No matching pairs");
                }
            }
            return container;
        }

        public void saveToDatabase()
        {
            return;
        }
        public void saveToCSV(string path)
        {
            return;
        }

        
        
    }
}