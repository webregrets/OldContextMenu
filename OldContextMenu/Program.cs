global using Microsoft.Win32; 
global using System.Diagnostics;

global using OldContextMenu;


bool ok = Functions.PreCheck();

Console.WriteLine("Let's change the context menu!");

if (ok)
{
    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32");

    if (key == null)
    {
        Functions.OldContext();
    }
    else
    {
        Functions.NewContext();
    }

    //Gets all processes with "explorer" as name. Since there probably is only one. Is there a GetProcessByName? probably
    Process[] explorer = Process.GetProcessesByName("explorer");

    //kills Explorer.exe since needed for the context menu to update
    explorer[0].Kill();

    Process process = new Process();
    process.StartInfo.FileName = "explorer";
    process.StartInfo.UseShellExecute = true;
    process.Start();

    Console.WriteLine("Did some registry changes. Try right-clicking a file!");
    Console.WriteLine("This window closes in five seconds");

    System.Threading.Thread.Sleep(5000);
}
else
{
    Console.WriteLine("You are not running Windows 11. No menu-switching for you my friend!");
    Console.WriteLine("This window closes in five seconds");

    System.Threading.Thread.Sleep(5000);
}
