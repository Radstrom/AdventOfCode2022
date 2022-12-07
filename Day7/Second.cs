namespace Day7;

public static class Second
{
    public static int Solve(string input)
    {
        var folders = Setup(input);

        var space = 70000000 - folders.First().GetSize();
        var req = 30000000;
        return folders.Select(x => x.GetSize()).Where(x => x > System.Math.Abs(space - req)).Min();
    }
    
    public static List<Folder> Setup(string input) 
    {
        var chunks = input.Split("$");
        var folders = new List<Folder>()
        {
            new Folder()
            {
                Name = "/",
                LocatedIn = null
            }
        };
        var currentDirectory = folders.First();
        
        foreach (var chunk in chunks)
        {
            if (chunk.StartsWith(" cd"))
            {
                var choice = chunk.Split(" ").ElementAt(2).TrimEnd('\n');
                if (choice == "..")
                {
                    currentDirectory = currentDirectory.LocatedIn;
                }
                else
                {
                    if (choice != "/")
                    {
                        currentDirectory = currentDirectory.Folders.Single(x => x.Name == choice);
                    }
                }
            }

            if (chunk.StartsWith(" ls"))
            {
                var output = chunk.Split("\n");
                for (var i = 1; i < output.Length; i++)
                {
                    var fileOrFolder = output.ElementAt(i).Split(" ");

                    if (fileOrFolder.ElementAt(0) == String.Empty)
                    {
                        continue;
                    }
                    
                    if (fileOrFolder.ElementAt(0) == "dir")
                    {
                        var folder = new Folder
                        {
                            Name = fileOrFolder.ElementAt(1).TrimEnd('\n'),
                            LocatedIn = currentDirectory
                        };
                        folders.Add(folder);
                        currentDirectory.Folders.Add(folder);
                    }
                    else
                    {
                        currentDirectory.Files.Add(new File
                        {
                            Name = fileOrFolder.ElementAt(1),
                            Size = int.Parse(fileOrFolder.ElementAt(0))
                        });
                    }
                }
            }
        }
        
        return folders;
    }

    public class Folder
    {
        public List<File> Files { get; set; } = new List<File>();
        public List<Folder> Folders { get; set; } = new List<Folder>();
        public string Name { get; set; }
        public Folder LocatedIn { get; set; }

        public int GetSize()
        {
            return Folders.Select(x => x.GetSize()).Sum() + 
                   Files.Select(x => x.Size).Sum();
        }
    }

    public class File
    {
        public int Size { get; set; }
        public string Name { get; set; }
    }
}