using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoriesAndFileIO
{
    [TestClass]
    public class TestWriteFiles
    {

        string testDir = "";
        string fileA = "";
        string fileAContents = "";
        string fileB = "";
        string fileBContents = "";
        string subDir = "";
        string subDirFile = "";
        string subDirFileContents = "";

        [TestInitialize]
        public void Initialize()
        {
            testDir = "writeTestDir";
            fileA = Path.Combine(testDir, "a.txt");
            fileB = Path.Combine(testDir, "b.txt");
            subDir = Path.Combine(testDir, "subDir");
            subDirFile = Path.Combine(subDir, subDirFile);
            fileAContents = "This is a.txt.";
            fileBContents = "This is b.txt.\nDit is een newline.\nEn nog een newline.";
            subDirFileContents = "This is a file in a sub-directory.";

            Directory.CreateDirectory(testDir);
            Directory.CreateDirectory(subDir);
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (Directory.Exists(testDir))
            {
                Directory.Delete(testDir, true);
            }
        }

        [TestMethod]
        public void WriteAllText()
        {
            File.WriteAllText(fileA, fileAContents);

            StreamReader sr;
            sr = File.OpenText(fileA);
            string result = sr.ReadToEnd();

            Assert.AreEqual(result, fileAContents);

            sr.Close();
        }

        [TestMethod]
        public void WriteAllLines()
        {
            char[] chars = { '\n' };
            string[] lines = fileBContents.Split(chars);

            File.WriteAllLines(fileB, lines);
            
            StreamReader sr;
            sr = File.OpenText(fileB);
            string result = sr.ReadToEnd();

            Assert.AreEqual(result, "This is b.txt.\r\nDit is een newline.\r\nEn nog een newline.\r\n");

            sr.Close();
        }

        [TestMethod]
        public void StreamWriter()
        {
            StreamWriter sw = new StreamWriter(fileA);

            char[] chars = { '\n' };
            string[] lines = fileBContents.Split(chars);

            foreach (var line in lines)
            {
                sw.WriteLine(line);
            }

            StreamReader sr;
            sr = File.OpenText(fileA);
            string result = sr.ReadToEnd();

            Assert.AreEqual(result, "This is b.txt.\r\nDit is een newline.\r\nEn nog een newline.\r\n");

            sw.Close();
            sr.Close();
        }
    }
}
