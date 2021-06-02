using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


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
        private List<FlyWing> objects = new List<FlyWing>();
        public FlyImporter(List<FlyWing> objects)
        {
            this.objects = objects;
        }
        public static FlyImporter importFromDirectory(string flyDirectory)
        {
            DirectoryInfo d = new DirectoryInfo(flyDirectory);
            FileInfo[] files = d.GetFiles("*.csv");
            List<FlyWing> container = new List<FlyWing>();
            foreach (FileInfo f in files)
            {
                using (StreamReader sr = new StreamReader(f.FullName))
                {
                    string values = sr.ReadToEnd();
                    string[] data = values.Split(",");
                    List<Tuple<int, int>> points = getCoordinates(data);
                    container.Add(new FlyWing(points));
                }

            }
            return new FlyImporter(container);
        }
        private static List<Tuple<int, int>> getCoordinates(string[] csv)
        {
            List<Tuple<int, int>> container = new List<Tuple<int, int>>();
            for (int i = 0; i < csv.Length; i += 2)
            {
                try
                {
                    int v1 = Int32.Parse(csv[i]);
                    int v2 = Int32.Parse(csv[i + 1]);
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