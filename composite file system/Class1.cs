using System;
using System.Collections.Generic;

namespace composite_file_system
{
    /// <summary>
    /// Represents a component in the file system (file or folder).
    /// </summary>
    public interface IFileSystemComponent
    {
        /// <summary>
        /// Displays details of the component.
        /// </summary>
        void ShowDetails();
    }

    /// <summary>
    /// Represents a file in the file system.
    /// </summary>
    public class File : IFileSystemComponent
    {
        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="File"/> class.
        /// </summary>
        /// <param name="name">The name of the file.</param>
        public File(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc/>
        public void ShowDetails()
        {
            Console.WriteLine($"File: {_name}");
        }
    }

    /// <summary>
    /// Represents a folder in the file system, which can contain files and folders.
    /// </summary>
    public class Folder : IFileSystemComponent
    {
        private readonly string _name;
        private readonly List<IFileSystemComponent> _children = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="Folder"/> class.
        /// </summary>
        /// <param name="name">The name of the folder.</param>
        public Folder(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Adds a child component to the folder.
        /// </summary>
        /// <param name="component">The component to add.</param>
        public void Add(IFileSystemComponent component)
        {
            if (component == null) throw new ArgumentNullException(nameof(component));
            _children.Add(component);
        }

        /// <summary>
        /// Removes a child component from the folder.
        /// </summary>
        /// <param name="component">The component to remove.</param>
        public void Remove(IFileSystemComponent component)
        {
            if (component == null) throw new ArgumentNullException(nameof(component));
            _children.Remove(component);
        }

        /// <inheritdoc/>
        public void ShowDetails()
        {
            Console.WriteLine($"Folder: {_name}");
            foreach (var child in _children)
            {
                child.ShowDetails();
            }
        }
    }
}
