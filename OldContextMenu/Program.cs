using Microsoft.Win32; 
using System.Diagnostics;

Console.WriteLine("Let's change the context menu!");

RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32");

if (key == null)
{
    OldContext();
}
else
{
    NewContext();
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

// HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32

static void OldContext()
{

    try
    {
        Console.WriteLine(@"Creating subkey HKCU\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32");
        RegistryKey keyIn = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32");

        //Adds the "(Default)" value and sets data to "" instead of "not defined" 
        keyIn.SetValue("", "");
        keyIn.Close();
        Console.WriteLine("Created regkey");

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
        Console.WriteLine(@"Deleting HKCU\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2} and subkeys");

        Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}");
        Console.WriteLine("Deleted regkey");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}