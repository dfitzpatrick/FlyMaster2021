using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlyMaster2021.business;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace FlyMaster2021.business.Tests
{
    [TestClass()]
    public class FlyImporterTests
    {
        private string path = Directory.GetCurrentDirectory();

        private void writeCSV(string path, string data)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(data);
            }
        }
        private void createCSVFiles()
        {
            string d1 = "43.5, 22.1, 8.9, 66.4, 75.3, 99.2"; // valid
            string d2 = "43.5, 22.1, 8.9, 66.4, 75.3"; // missing pair
            string d3 = "a, 22.1, 8.9, 66.4, 75.3, 99.2"; // non-number
        }


        [TestMethod()]
        public void FlyImporterTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void saveToDatabaseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void saveToCSVTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void importFromDirectoryTest()
        {
            Assert.Fail();
        }
    }
}