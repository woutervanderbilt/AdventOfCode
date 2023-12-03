using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2022
{
    internal class Dag07 : Problem
    {
        private const string testinput = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";
        public override async Task ExecuteAsync()
        {
            var input = await GetInputAsync();
            Directory current = new Directory{Name = "/"};
            IList<Directory> directories = new List<Directory>();
            directories.Add(current);
            foreach (var line in input.Split(Environment.NewLine).Skip(1))
            {
                var split = line.Split();
                if (split[0]=="$")
                {
                    if (split[1] == "cd")
                    {
                        if (split[2] == "..")
                        {
                            current = current.Parent;
                        }

                        else
                        {

                            var child = current.Directories.SingleOrDefault(d => d.Name == split[2]);
                            if (child == null)
                            {
                                child = new Directory
                                {
                                    Parent = current,
                                    Name = split[2]
                                };
                                current.Directories.Add(child);
                                directories.Add(child);
                            }

                            current = child;
                        }
                    }
                }
                else
                {
                    if (split[0] == "dir")
                    {
                        var child = current.Directories.SingleOrDefault(d => d.Name == split[1]);
                        if (child == null)
                        {
                            child = new Directory
                            {
                                Parent = current,
                                Name = split[1]
                            };
                            current.Directories.Add(child);
                            directories.Add(child);
                        }
                    }
                    else
                    {
                        
                        var file = current.Files.SingleOrDefault(f => f.Name == split[1]);
                        if (file == null)
                        {
                            file = new File()
                            {
                                Name = split[1],
                                Size = long.Parse(split[0])
                            };
                            current.Files.Add(file);
                        }
                    }
                    
                }
            }


            var total = directories[0].Size();
            Result = directories.Where(d => d.Size() >= total - 40000000).Min(d => d.Size()).ToString();
            //foreach (var directory in directories.OrderBy(d => d.Size()))
            //{
            //    Console.WriteLine($"{directory.Name}  {directory.Size()}");
            //}
        }

        public override int Nummer => 202207;

        private class Directory
        {
            public string Name { get; set; }
            public Directory? Parent { get; set; }
            public IList<Directory> Directories { get; set; } = new List<Directory>();
            public IList<File> Files { get; set; } = new List<File>();

            public long Size() => Files.Sum(f => f.Size) + Directories.Sum(d => d.Size());
        }

        private class File
        {
            public string Name { get; set; }
            public long Size { get; set; }
        }

    }
}
