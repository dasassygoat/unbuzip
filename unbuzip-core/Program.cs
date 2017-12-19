using System;
using System.IO;
using System.IO.Compression;

namespace unbuzip_core
{
    class Program
    {
        static void Main(string[] args)
        {
            const string dirpath = "/home/bryan/src/unbuzip";
            const string extractDirectory = "/home/bryan/src/unbuzip/temp";
            var di = new DirectoryInfo(dirpath);

            foreach (var fi in di.GetFiles("*.zip"))
            {
                //add to database
                Decompress(fi, extractDirectory);
                //Console.WriteLine("found file");
            }
            Console.WriteLine("Finished decompressing");
            Console.ReadKey();
        }

        private static void Decompress (FileInfo fi, string extractDirectory)
        {
            //UnzipDataDataContext db = new UnzipDataDataContext();
            var compressedFile = fi.DirectoryName + "/" + fi.Name;
            var fileName = fi.Name.Replace (".zip", "");
            var directory = fi.DirectoryName + "/" + fileName+ "/";

            try {
                Directory.CreateDirectory (extractDirectory + "/" + fileName);
                Console.WriteLine("Created Directory at {0}\n\n", extractDirectory + "/" + fileName);
                
                ZipFile.ExtractToDirectory(fi.DirectoryName + "/" + fi.Name,extractDirectory+ "/" + fileName);

                //zipname.Extracted = true;
                //File.Delete(compressedFile);

                Console.WriteLine ("Decompressed: {0}", fi.Name);

            } catch (Exception e) {
                //zipname.Extracted = false;
                Console.WriteLine ("Couldn't decompress: {0} The Directory is {1}\nError: {2}\n\n", fi.Name, directory, e.ToString ());
            }
        }
    }
}
