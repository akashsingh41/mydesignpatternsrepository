using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{

    public interface IContainer
    {
        int GetTotalSize();
    }

    public class Folder : IContainer
    {
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public List<IContainer> ContainerList { get; set; }

        public Folder(string name, DateTime createdDateTime, List<IContainer> containerList)
        {
            Name = name;
            CreatedDateTime = createdDateTime;
            ContainerList = containerList;
        }

        public int GetTotalSize()
        {
            return ContainerList.Sum(x => x.GetTotalSize());
        }

        public void Add(IContainer container)
        {
            ContainerList.Add(container);
        }
    }

    public class File : IContainer
    {
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int Size;

        public File(int size, string name, DateTime createdDateTime)
        {
            Size = size;
            Name = name;
            CreatedDateTime = createdDateTime;
        }

        public int GetTotalSize()
        {
            return Size;
        }
    }
    public class Program
    {
        public static void Main()
        {
            File file1 = new File(5, "file1", DateTime.Now);
            File file2 = new File(5, "file2", DateTime.Now);
            File file3 = new File(5, "file3", DateTime.Now);
            Folder folder1 = new Folder("folder1", DateTime.Now, new List<IContainer>());
            folder1.Add(file3);
            //user put 2 in 1 single folder
            List<IContainer> list = new List<IContainer>(new File[] { file2, file3 });
            IContainer folder2 = new Folder("folder2", DateTime.Now, list);
            Console.WriteLine(folder2.GetTotalSize());
            Console.ReadLine();
        }
    }
}

