using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DirectoriesAndFileIO
{
    [TestClass]
    public class TestDirectories
    {
        [TestInitialize]
        public void Initialize()
        {
            // Make sure testDir is gone after possible previously failed tests
            if (Directory.Exists("testDir"))
            {
                Directory.Delete("testDir", true);
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            // Make sure testDir is gone after succesfully running tests
            if (Directory.Exists("testDir"))
            {
                Directory.Delete("testDir", true); 
            }
        }

        [TestMethod]
        public void TestCreateAndDeleteDirectory()
        {
            DirectoryInfo dir = Directory.CreateDirectory("testDir"); // Using a DirectoryInfo-object ...

            Assert.IsTrue(dir.Exists, "Directory should exist");

            dir.Delete();
            dir.Refresh(); // ... we only **actually** delete here.

            Assert.IsFalse(dir.Exists, "Directory should be deleted");
        }

        [TestMethod]
        public void TestCreateAndDeleteDirectoryDirectly()
        {
            // In stead of using a DirectoryInfo-object,
            // we can use the static methods of the Directory-class directly.
            string dirName = "testDir";
            Directory.CreateDirectory(dirName); // we don't care about the return value here

            Assert.IsTrue(Directory.Exists(dirName), "Directory should exist");

            Directory.Delete(dirName);

            Assert.IsFalse(Directory.Exists(dirName), "Directory should be deleted");
        }
    }
}
