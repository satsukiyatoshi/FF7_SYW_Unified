
using System.Collections;
using System.Diagnostics;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {
        //convert an hext string value to bytes
        static byte[] StringToByteArray(string hex)
        {
            int length = hex.Length / 2;
            byte[] bytes = new byte[length];

            for (int i = 0; i < length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return bytes;
        }

        private string checkExeVersion()
        {
            string exeVersion = "";
            string filePath = Application.StartupPath + @"\Game\ff7.exe";
            int offset = 0x10; // Offset where check the ff7 version

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                fs.Seek(offset, SeekOrigin.Begin);

                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes(4); // 4 octets reading

                    uint value = BitConverter.ToUInt32(bytes, 0);
                    string hexValue = value.ToString("X"); // convert to hext

                    //TODO need to fin exe offset to check version (check lang & version, if not 1.02 version based, output error)
                    if (hexValue == "") { exeVersion = "F"; }
                    if (hexValue == "") { exeVersion = "E"; }
                    if (hexValue == "") { exeVersion = "G"; }
                    if (hexValue == "") { exeVersion = "S"; }
                }
            }

            return exeVersion;
        }

        private void NoCd(string exeVersion)
        {
            string filePath = Application.StartupPath + @"\Game\ff7.exe";

            string[] hexValues = new string[4] { "9090", "EB17", "EB3A", "EB22" }; //Hexts values to write
            int[] offsets = new int[4];

            //todo need to fin exacts offset for each exe version
            if (exeVersion == "F") {offsets = new int[] { 0x10, 0x10, 0x10, 0x10 }; }//Hexts offset where to write}
            if (exeVersion == "E") {offsets = new int[] { 0x10, 0x10, 0x10, 0x10 }; }
            if (exeVersion == "G") {offsets = new int[] { 0x10, 0x10, 0x10, 0x10 }; }
            if (exeVersion == "S") {offsets = new int[] { 0x10, 0x10, 0x10, 0x10 }; }

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {

                foreach (int i in offsets)
                {
                    fs.Seek(offsets[i], SeekOrigin.Begin); // go to hext offset where to write

                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] bytes = StringToByteArray(hexValues[i]); //hexValue = hext string value to write
                        bw.Write(bytes); //Write bytes
                    }
                }
            }
        }


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
