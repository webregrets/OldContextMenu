using Microsoft.Win32;

namespace OldContextMenu
{
    public class Functions
    {

        public static void OldContext()
        {

            try
            {
                Console.WriteLine(@"Creating subkey HKCU\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32");
                RegistryKey keyIn = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32");

                keyIn.SetValue("", "");
                keyIn.Close();
                Console.WriteLine("Created regkey");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public static void NewContext()
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

        public static bool PreCheck()
        {
            string osVer = Environment.OSVersion.ToString();

            string osString = osVer.Substring(0, 28);

            if (osString == "Microsoft Windows NT 10.0.22") 
            {
                Console.WriteLine("OS detected as: " + osVer);
                return true; 
            }
            else 
            {
                Console.WriteLine("OS detected as: " + osVer);
                return false; 
            }

        }



    }
}
