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

        [TestMethod]
        public void Folder_ShowDetails_PrintsFolderAndChildren()
        {
            // Arrange
            var folder = new Folder("root");
            folder.Add(new composite_file_system.File("a.txt"));
            folder.Add(new composite_file_system.File("b.txt"));
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var originalOut = Console.Out;
            Console.SetOut(writer);

            // Act
            folder.ShowDetails();
            Console.SetOut(originalOut);

            // Assert
            var result = output.ToString();
            Assert.IsTrue(result.Contains("Folder: root"));
            Assert.IsTrue(result.Contains("File: a.txt"));
            Assert.IsTrue(result.Contains("File: b.txt"));
        }

        [TestMethod]
        public void Folder_AddAndRemove_UpdatesChildren()
        {
            // Arrange
            var folder = new Folder("docs");
            var file = new composite_file_system.File("readme.md");
            folder.Add(file);
            folder.Remove(file);
            var output = new StringBuilder();
            using var writer = new StringWriter(output);
            var originalOut = Console.Out;
            Console.SetOut(writer);

            // Act
            folder.ShowDetails();
            Console.SetOut(originalOut);

            // Assert
            var result = output.ToString();
            Assert.IsTrue(result.Contains("Folder: docs"));
            Assert.IsFalse(result.Contains("readme.md"));
        }
    }
}
