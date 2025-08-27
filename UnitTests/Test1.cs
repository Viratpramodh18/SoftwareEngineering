using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileSystemTests
{
    using composite_file_system;

    [TestClass]
    public class FileSystemComponentTests
    {
        [TestMethod]
        public void File_ShowDetails_PrintsFileName()
        {
            // Arrange
            var file = new composite_file_system.File("test.txt");
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var originalOut = Console.Out;
            Console.SetOut(writer);

            // Act
            file.ShowDetails();
            Console.SetOut(originalOut);

            // Assert
            Assert.IsTrue(output.ToString().Contains("File: test.txt"));
        }
    }
}
