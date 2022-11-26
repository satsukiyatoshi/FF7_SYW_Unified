
using System.Collections;
using System.Diagnostics;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {

        private void runWinCdemu(string arguments, int timeoutInSeconds = 10)
        {
            string winCdeEmuPath = Application.StartupPath + @"\Tools\WinCDEmu\PortableWinCDEmu.exe";

            ProcessStartInfo startInfo = new ProcessStartInfo(winCdeEmuPath, arguments)
            {
                WorkingDirectory = Path.GetDirectoryName(winCdeEmuPath),
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
        };

            using (Process winCd = Process.Start(startInfo))
            {
                winCd.WaitForExit(timeoutInSeconds * 1000);
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


        private void regFF7(string drive, int timeoutInSeconds = 10)
        {
            File.Copy(Application.StartupPath + @"Tools\FF7reg.exe", Application.StartupPath + @"Game\FF7reg.exe", true);

            string ff7Reg = Application.StartupPath + @"Game\FF7reg.exe";

            ProcessStartInfo startInfo = new ProcessStartInfo(ff7Reg, "/ISO=" + drive)
            {
                WorkingDirectory = Path.GetDirectoryName(ff7Reg),
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };

            using (Process reg = Process.Start(startInfo))
            {
                reg.WaitForExit(timeoutInSeconds * 1000);
            }
        }

    }
}
