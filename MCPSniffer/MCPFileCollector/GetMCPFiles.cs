using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using MCPSniffer.Model;
using ElasticSeachSDK;

namespace MCPFileCollector
{
    public class GetMCPFiles
    {
        IElasticSeachClient client = new ElasticSeachClient();

        private string currentPath = "C:"; //need provide a connect drive. Can hardcode or use the configuration
        public List<MCPFileInfo> allFilesOnMCP;


        public GetMCPFiles(string MCPDrivePath)
        {
            currentPath = MCPDrivePath;
            allFilesOnMCP = new List<MCPFileInfo>();
        }

        public void GetAllFromMCP()
        {
            DirectoryInfo theFolders = new DirectoryInfo(currentPath);
            DirectoryInfo[] allDirs = theFolders.GetDirectories();

            foreach (var nextFolder in allDirs)
            {
                try
                {
                    Console.WriteLine($"Start Read Directory {nextFolder}");

                    CheckAllInFolder(nextFolder.FullName);
                    //continue;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            //StartFileMonitor();
        }

        public void StartFileMonitor()
        {
            // instantiate the FileSystemWatcher Class
            FileSystemWatcher mCPFileMonitor = new FileSystemWatcher();

            // Associate event handlers with the events
            mCPFileMonitor.Created += FileSystemWatcher_Created;
            mCPFileMonitor.Changed += FileSystemWatcher_Changed;
            mCPFileMonitor.Deleted += FileSystemWatcher_Deleted;
            mCPFileMonitor.Renamed += FileSystemWatcher_Renamed;

            // tell the watcher where to look
            mCPFileMonitor.Path = currentPath;
            mCPFileMonitor.IncludeSubdirectories = true;

            // You must add this line - this allows events to fire.
            mCPFileMonitor.EnableRaisingEvents = true;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Listening...{ mCPFileMonitor.Path }");
            Console.WriteLine("(Press any key to exit.)");

            Console.ReadLine();
        }

        private int Id = 1;
        private void CheckAllInFolder(string folderPath)
        {
            DirectoryInfo theFolder = new DirectoryInfo(folderPath);
            DirectoryInfo[] HasFolders = theFolder.GetDirectories();
            FileInfo[] HasFiles = theFolder.GetFiles();

            if (theFolder == null)
            {
                return;
            }
            else
            {
                if (HasFiles.Length != 0)
                {
                    foreach (var nextFile in HasFiles)
                    {
                        Console.WriteLine($"Start Read File {nextFile}");

                        MCPFileInfo theFileInfo = new MCPFileInfo()
                        {
                            Id= this.Id++,
                            Name = nextFile.Name,
							//FullName = nextFile.FullName,
							//Directory = nextFile.DirectoryName,
							LastModifyTime = nextFile.LastWriteTime,
                            Size = string.Concat(nextFile.Length.ToString(), " bytes"),
                            Content = nextFile.Length < 2000000 ? GetFileContent(nextFile) : "File is too large..."
                        };

                        //Console.WriteLine($"Start Send File Info {nextFile}");
                        client.SaveMCPFileInfo(theFileInfo);
                        Console.WriteLine($"Send File Info {nextFile} to ES Successfully");

                    }
                }

                if (HasFolders.Length != 0)
                {
                    foreach (var NextFolder in HasFolders)
                    {
                        CheckAllInFolder(NextFolder.FullName);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private string GetFileContent(FileInfo theFile)
        {
            string totalFileContent = string.Empty;
            try
            {
                FileStream fs = File.Open(theFile.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                totalFileContent = Encoding.Default.GetString(data);
                fs.Close();
            }
            catch (Exception e)
            {
                totalFileContent = e.Message;
            }

            return totalFileContent;
        }

        private static void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"A new file has been renamed from {e.OldName} to {e.Name}");
        }

        private static void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"A new file has been deleted - {e.Name}");
        }

        private static void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"A new file has been changed - {e.Name}");
        }

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"A new file has been created - {e.Name}");
        }
    }
}

