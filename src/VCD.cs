
using System.Collections;
using System.Diagnostics;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {

        //Used to run an emulated cd drive
        private void runWinCdemu(string arguments)
        {
            string winCdeEmuPath = Application.StartupPath + @"\Tools\WinCDEmu\PortableWinCDEmu.exe";

            ProcessStartInfo mountIso = new ProcessStartInfo(winCdeEmuPath, arguments)
            {
                WorkingDirectory = Path.GetDirectoryName(winCdeEmuPath),
                UseShellExecute = true,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
            };

            using (Process winCd = Process.Start(mountIso))
            {
                winCd.WaitForExit(10000);
            }
        }



        private void installWinCdeDriver()
        {
            runWinCdemu("/install");
        }



        private void unmountIso()
        {
            installWinCdeDriver();
            runWinCdemu($"/unmount \"{Application.StartupPath + @"\Tools\WinCDEmu\FF7DISC1.ISO"}\"");
        }



        private void mountIso(string drive)
        {
            installWinCdeDriver();
            runWinCdemu($"\"{Application.StartupPath + @"\Tools\WinCDEmu\FF7DISC1.ISO"}\"" + " " + drive);
        }



        //get last avaibleletter for mounting iso
        public string getLastAvailableDriveLetter()
        {
            ArrayList driveLetters = new ArrayList(26);

            for (int i = 67; i < 91; i++)
            {
                driveLetters.Add(Convert.ToChar(i));
            }

            foreach (string drive in Directory.GetLogicalDrives())
            {
                driveLetters.Remove(drive[0]);
            }

            return driveLetters[^1].ToString();
        }



        //register FF7 for using withg FFNx and iso letter
        private void regFF7(string drive)
        {
            File.Copy(Application.StartupPath + @"Tools\FF7reg.exe", Application.StartupPath + @"Game\FF7reg.exe", true);

            string ff7Reg = Application.StartupPath + @"Game\FF7reg.exe";

            ProcessStartInfo registerFF7 = new ProcessStartInfo(ff7Reg, "/ISO=" + drive)
            {
                WorkingDirectory = Path.GetDirectoryName(ff7Reg),
                UseShellExecute = true,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
            };

            using (Process reg = Process.Start(registerFF7))
            {
                reg.WaitForExit(10000);
            }

            File.Delete(ff7Reg);
        }

    }
}
