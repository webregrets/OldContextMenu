using Microsoft.Win32;
using System.Diagnostics;

Console.WriteLine("Let's change the context menu!");



// HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32

// Separerat för enklare copy paste: {86ca1aa0-34aa-4e8b-a509-50c905bae2a2}
// InprocServer32

//Default måste sättaas som ""

//Man måste också starta om explorer.exe! 

//Shouldn't be that hard

//string guid = "{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}";
//string Inproc = "InprocServer32";

try
{
    Console.WriteLine(@"Skapar subkey HKCU\Software\Classes\CLSID\{ 86ca1aa0 -34aa - 4e8b - a509 - 50c905bae2a2}");
    RegistryKey keyG = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}");
    keyG.Close();

    Console.WriteLine(@"Skapar subkey HKCU\Software\Classes\CLSID\{ 86ca1aa0 -34aa - 4e8b - a509 - 50c905bae2a2}\InprocServer32");
    RegistryKey keyIn = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32");

    keyIn.SetValue("", "");
    keyIn.Close();
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

Process[] explorer = Process.GetProcessesByName("explorer");

explorer[0].Kill();


Process process = new Process();
process.StartInfo.FileName = "explorer";
process.StartInfo.UseShellExecute = true;
process.Start();

Console.WriteLine("Alla värden satta och explorer omstartat. Testa högerklicka på någon fil ;)");