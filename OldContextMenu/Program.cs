using Microsoft.Win32; 
using System.Diagnostics;

Console.WriteLine("Let's change the context menu!");



// HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32

try
{
    Console.WriteLine(@"Creating subkey HKCU\Software\Classes\CLSID\{ 86ca1aa0 -34aa - 4e8b - a509 - 50c905bae2a2}");
    RegistryKey keyG = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}");
    keyG.Close();

    //Maybe this can be run instead of the middle-step above...
    Console.WriteLine(@"Creating subkey HKCU\Software\Classes\CLSID\{ 86ca1aa0 -34aa - 4e8b - a509 - 50c905bae2a2}\InprocServer32");
    RegistryKey keyIn = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32");

    //Adds the "(Default)" value and sets data to "" instead of "not defined" 
    keyIn.SetValue("", "");
    keyIn.Close();
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

//Gets all processes with "eplorer" as name. Since there probably is only one. Is there a GetProcessByName? probably
Process[] explorer = Process.GetProcessesByName("explorer");

//kills Explorer.exe since needed for the context menu to update
explorer[0].Kill();


Process process = new Process();
process.StartInfo.FileName = "explorer";
process.StartInfo.UseShellExecute = true;
process.Start();

Console.WriteLine("Added registry key to get the old context menu back. Try right-clicking a file!");

Console.ReadKey();