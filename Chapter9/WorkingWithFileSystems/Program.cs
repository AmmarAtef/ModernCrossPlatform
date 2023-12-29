using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;


//OutputFileSystemInfo();

static void OutputFileSystemInfo()
{
    WriteLine($"Path.PathSeparator {PathSeparator}");
    WriteLine($"Path.DirectorySeparatorChar {DirectorySeparatorChar}");
    WriteLine($"Directory.GetCurrentDirectory() {Directory.GetCurrentDirectory()}");
    WriteLine($"Environment.CurrentDirectory {Environment.CurrentDirectory}");
    WriteLine($"Environment.SystemDirectory {Environment.SystemDirectory}");
    WriteLine($"Path.GetTempPath() {Path.GetTempPath()}");


    WriteLine($"GetFolderPath");
    WriteLine($".System {GetFolderPath(SpecialFolder.System)}");
    WriteLine($".ApplicationData {GetFolderPath(SpecialFolder.ApplicationData)}");
    WriteLine($".MyDocuments {GetFolderPath(SpecialFolder.MyDocuments)}");
    WriteLine($".Personal {GetFolderPath(SpecialFolder.Personal)}");
}


//WorkWithDrives();
static void WorkWithDrives()
{
    WriteLine($"Name | FORMAT | Type | SIZE(BYTES) | FREE SPACE");


    foreach (DriveInfo drive in DriveInfo.GetDrives())
    {
        if (drive.IsReady)
        {
            WriteLine($"{drive.Name} | {drive.DriveType} | {drive.DriveFormat} | {drive.TotalSize} | {drive.AvailableFreeSpace}");

        }
        else
        {
            WriteLine($"{drive.Name} | {drive.DriveType}");
        }
    }
}


//WorkingWithDirectories();
static void WorkingWithDirectories()
{
    string newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "Code", "Chapter09", "NewFolder");
    WriteLine($"Working with: {newFolder}");

    //check if it exists
    WriteLine($"Does it exist?  {Exists(newFolder)}");


    //create directory
    WriteLine("Creating it....");
    CreateDirectory(newFolder);
    WriteLine($"Does it exist?  {Exists(newFolder)}");
    WriteLine("Confirm the directory exists, and then press Enter: ");
    ReadLine();

    //delete directory
    WriteLine("Deleting it....");
    Delete(newFolder,true);
    WriteLine($"Does it exist? {Exists(newFolder)}");

}

workingWithFiles();
static void workingWithFiles()
{
    string dir = Combine(GetFolderPath(SpecialFolder.Personal)
        , "Code", "Chapter09", "OutputFiles");

    CreateDirectory(dir);

    string textFile = Combine(dir, "newText.txt");
    string backupText = Combine(dir, "Dummy.txt");
    WriteLine($"Working with: {textFile}");

    //check if file Exists 
    //WriteLine($"Check if file exists? {File.Exists(textFile)}");



    //// create a new text file and write a line to it 
    StreamWriter textWriter = File.CreateText(textFile);
    //textWriter.WriteLine("Ammar is the best.");
    //textWriter.Close();
    //WriteLine($"Does it exist? {File.Exists(textFile)}");


    //// copy the file, and overwrite if it already exists
    ////File.Copy(textFile, backupText, true);

    //WriteLine($"Does {backupText} exist? {File.Exists(backupText)}");

    //WriteLine("Confirm the file exist, and then press enter: ");
    //ReadLine();

    //File.Delete(textFile);
    //WriteLine($"Does it exist?{File.Exists(textFile)}");

    //WriteLine($"Reading contents of {backupText}");
    //StreamReader streamReader = File.OpenText(backupText);
    //WriteLine(streamReader.ReadToEnd());
    //streamReader.Close();

    WriteLine($"Folder Name: {GetDirectoryName(textFile)}");
    WriteLine($"File Name {GetFileName(textFile)}");
    WriteLine($"File name without Extension: {GetFileNameWithoutExtension(textFile)}");
    WriteLine($"File Extension: {GetExtension(textFile)}");
    WriteLine($"Random File Name: {GetRandomFileName()}");
    WriteLine($"Temporary File Name: {GetTempFileName()}");

    FileInfo info = new FileInfo(backupText);
    WriteLine($"{backupText}");
    WriteLine($"Contains {info.Length} bytes.");
    WriteLine($"Last accessed {info.LastAccessTime}");
    WriteLine($"Has readonly set to  {info.IsReadOnly}");


}



