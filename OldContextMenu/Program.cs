using Microsoft.Win32; 
using System.Diagnostics;

const string regKey = @"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32";

Console.WriteLine("Let's change the context menu!");

RegistryKey key = Registry.CurrentUser.OpenSubKey(regKey);

if (key == null)
    OldContext();
else
    NewContext();

Console.WriteLine(@"Press any key to finish...");
Console.ReadKey();

static void OldContext()
{
    try
    {
        Console.WriteLine("New context menu ---> Old context menu");
        Console.WriteLine($"Creating subkey {regKey}");

        RegistryKey keyIn = Registry.CurrentUser.CreateSubKey(regKey);

        keyIn.SetValue("", "");
        keyIn.Close();
    

        //Gets all processes with "explorer" as name. Since there probably is only one. Is there a GetProcessByName? probably
        Process[] explorer = Process.GetProcessesByName("explorer");

        //kills Explorer.exe since needed for the context menu to update
        explorer[0].Kill();

        Process process = new Process();
        process.StartInfo.FileName = "explorer";
        process.StartInfo.UseShellExecute = true;
        process.Start();

        Console.WriteLine("Added registry key to get the old context menu back. Try right-clicking a file!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}

static void NewContext()
{
    try
    {
        Console.WriteLine("Old context menu ---> new context menu");
        Console.WriteLine($"Deleting subkey {regKey}");

        Registry.CurrentUser.DeleteSubKey(regKey);
        Registry.CurrentUser.DeleteSubKey(regKey.Remove(regKey.Length - 15));
    

        //Gets all processes with "explorer" as name. Since there probably is only one. Is there a GetProcessByName? probably
        Process[] explorer = Process.GetProcessesByName("explorer");

        //kills Explorer.exe since needed for the context menu to update
        explorer[0].Kill();

        Process process = new Process();
        process.StartInfo.FileName = "explorer";
        process.StartInfo.UseShellExecute = true;
        process.Start();

        Console.WriteLine("Deleted registry key to get the new context menu back. Try right-clicking a file!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}