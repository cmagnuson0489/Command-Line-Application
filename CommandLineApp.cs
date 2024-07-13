using System;
using System.IO;
using System.Security.Cryptography;

namespace FileAnalyzer
{
    class CommandLine
    {
        static void Main(string[] args)
        {
            //We need to check if the correct number of arguments have been provided
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: FileAnalyzer <input directory> <output path> <include subdirectories (true/false)>");
                return;
            }

            string inputDirectory = args[0];
            string outputPath = args[1];
            bool includeSubdirectories = bool.Parse(args[2]);

            //Checking if the specified input directory exists

            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("The specified input directory does not exist.");
                return;
            }

            //Create or overwrite the output CSV file and write the header

            using StreamWriter writer = new StreamWriter(outputPath);
            writer.WriteLine("File Path,File Type,MD5 Hash");  // CSV header
            
            //Start processing the file that was givien with the provided directory
            ProcessDirectory(inputDirectory, includeSubdirectories, writer);
        }

        static void ProcessDirectory(string dirPath, bool includeSubdirectories, StreamWriter writer)
        {
            foreach (var file in Directory.GetFiles(dirPath))
            {
                AnalyzeFile(file, writer);
            }

            if (includeSubdirectories)
            {
                foreach (var subDir in Directory.GetDirectories(dirPath))
                {
                    ProcessDirectory(subDir, includeSubdirectories, writer);
                }
            }
        }

        static void AnalyzeFile(string filePath, StreamWriter writer)
        {
            using FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            // Read the first 4 bytes to determine the file type. 
            byte[] signature = new byte[4];
            fs.Read(signature, 0, signature.Length);
            string fileType = null;

            //Checking id the file is a JPG based on the signature
            if (signature[0] == 0xFF && signature[1] == 0xD8) fileType = "JPG";
            else if (signature[0] == 0x25 && signature[1] == 0x50 && signature[2] == 0x44 && signature[3] == 0x46) fileType = "PDF";

            if (fileType != null)
            {
                fs.Seek(0, SeekOrigin.Begin)  //Reset the stream position for MD5 calcualtions
                string md5Hash = CalculateMD5(fs);
                writer.WriteLine($"\"{filePath}\",{fileType},{md5Hash}");
            }
        }

        static string CalculateMD5(FileStream fs)
        {
            using MD5 md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(fs);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
