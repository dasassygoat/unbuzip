using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

using System.Text;
using Ionic.Zip;


namespace Unzipper
{
    class Program
    {
        
        

        static void Main(string[] args)
        {
            string dirpath = "/home/bryan/src/unbuzip";
            string extractDirectory = "/home/bryan/src/unbuzip/temp/";
            DirectoryInfo di = new DirectoryInfo(dirpath);

            foreach (FileInfo fi in di.GetFiles("*.zip"))
            {
                //add to database
                Decompress(fi, extractDirectory);
				//Console.WriteLine("found file");
            }
            Console.WriteLine("Finished decompressing");
            Console.ReadKey();

            
        }

        public static void Decompress (FileInfo fi, string extractDirectory)
		{
			//UnzipDataDataContext db = new UnzipDataDataContext();
			string compressedFile = fi.DirectoryName + "/" + fi.Name;
			string fileName = fi.Name.Replace (".zip", "");
			string directory = fi.DirectoryName + "/" + fileName;


			//ZipFileName zipname = new ZipFileName();

			
            
			/*var found = from name in db.ZipFileNames
                        where name.ZipFileName1 == fileName & name.Extracted == true
                        select name;
            zipname.ZipFileName1 = fileName;
            if (found.Count() == 0)
            { */

			try {
				Directory.CreateDirectory (directory);
				Console.WriteLine("Created Directory at {0}\n\n", directory);
				//ZipFile.ExtractToDirectory(compressedFile, directory);

				using (ZipFile zip = ZipFile.Read(compressedFile))
                {
                    // This call to ExtractAll() assumes:
                    //   - none of the entries are password-protected.
                    //   - want to extract all entries to current working directory
                    //   - none of the files in the zip already exist in the directory;
                    //     if they do, the method will throw.
                    zip.ExtractAll(directory, ExtractExistingFileAction.OverwriteSilently);
                }

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

