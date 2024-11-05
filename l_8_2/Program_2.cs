using System.IO.Compression;
using System.Xml.Serialization;

public class Program_2
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the path to the folder where you want to search: ");
        string searchDirectory = Console.ReadLine();
        Console.WriteLine("Enter file name: ");
        string targetName = Console.ReadLine();
        string[] files = Directory.GetFiles(searchDirectory, targetName, SearchOption.AllDirectories);
        if (files.Length == 0) { Console.WriteLine("File not found."); }
        else
        {
            foreach (string filePath in files)
            {
                Console.WriteLine($"File found: {filePath}");
                using (FileStream fileStream = File.OpenRead(filePath))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string fileContent = reader.ReadToEnd();
                        Console.WriteLine($"File contents:\n{fileContent}");
                    }
                }
                string compressedFilePath = Path.ChangeExtension(filePath, ".gz");
                using (FileStream originalFileStream = File.OpenRead(filePath))
                {
                    using (FileStream compressedFileStream = File.Create(compressedFilePath))
                    {
                        using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                        {
                            originalFileStream.CopyTo(compressionStream);
                            Console.WriteLine($"File compressed and saved as: {compressedFilePath}");
                        }
                    }
                }
            }
        }
    }
}
