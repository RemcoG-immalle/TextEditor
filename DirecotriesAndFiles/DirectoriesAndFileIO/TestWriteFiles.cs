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
            string[] lines = fileBContents.Split('\n');

            File.WriteAllLines(fileB, lines);

            StreamReader sr;
            sr = File.OpenText(fileB);
            string result = sr.ReadToEnd();

            Assert.AreEqual(result, fileBContents);

            sr.Close();
        }

    }
}
