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
            if (Directory.Exists("testDir"))
            {
                Directory.Delete("testDir", true); // remove test-directory (can throw exceptions! annoying!)
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (Directory.Exists("testDir"))
            {
                Directory.Delete("testDir", true); // remove test-directory (can throw exceptions! annoying!)
            }
        }

        [TestMethod]
        public void TestCreateAndDeleteDirectory()
        {
            DirectoryInfo dir = Directory.CreateDirectory("testDir");

            Assert.IsTrue(dir.Exists, "Directory should exist");

            dir.Delete();
            dir.Refresh(); // only here we actually delete, otherwise use Directory.Delete("testDir");

            Assert.IsFalse(dir.Exists, "Directory should be deleted");
        }        
    }
}
