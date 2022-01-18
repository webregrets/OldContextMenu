

namespace OldContextMenu
{

    public class Functions
    {
        public static EventLog eventLog = new EventLog();
       
        public static void OldContext()
        {
            eventLog.Log = "Application";
            eventLog.Source = "Application";

            try
            {
                Console.WriteLine(@"Creating subkey HKCU\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32");
                RegistryKey keyIn = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32");
                eventLog.WriteEntry(@"Creating subkey HKCU\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32");

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
            eventLog.Log = "Application";
            eventLog.Source = "Application";
            try
            {
                Console.WriteLine(@"Deleting HKCU\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2} and subkeys");
                eventLog.WriteEntry(@"Deleting HKCU\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2} and subkeys");
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
            eventLog.Log = "Application";
            eventLog.Source = "Application";

            string osVer = Environment.OSVersion.ToString();

            string osString = osVer.Substring(0, 28);

            if (osString == "Microsoft Windows NT 10.0.22") 
            {
                Console.WriteLine("OS detected as: " + osVer);
                eventLog.WriteEntry("OS detected as: " + osVer);
                return true; 
            }
            else 
            {
                Console.WriteLine("OS detected as: " + osVer);
                eventLog.WriteEntry("OS detected as: " + osVer + ". Sorry, you cant run this applocation");

                return false; 
            }

        }



    }
}
