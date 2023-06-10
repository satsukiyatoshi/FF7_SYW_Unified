
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
            int offset = 0x404; // Offset where check the ff7 version

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                fs.Seek(offset, SeekOrigin.Begin);

                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes(4); // 4 octets reading

                    uint value = BitConverter.ToUInt32(bytes, 0);
                    string hexValue = value.ToString("X"); // convert to hext

                    if (hexValue == "99EBF805") { exeVersion = "F"; }
                    if (hexValue == "99CE0805") { exeVersion = "E"; }
                    if (hexValue == "99DBC805") { exeVersion = "G"; }
                    if (hexValue == "99F65805") { exeVersion = "S"; }
                }
            }

            return exeVersion;
        }

        private void noCd(string exeVersion)
        {
            string filePath = Application.StartupPath + @"\Game\ff7.exe";

            int[] addresses = new int[4];

            // nocd exe's offsets
            if (exeVersion == "F" || exeVersion == "S") { addresses = new int[] { 0x3F75, 0x8408, 0x887C, 0x9765 }; }
            if (exeVersion == "E" || exeVersion == "G") { addresses = new int[] { 0x3F65, 0x83F8, 0x886C, 0x9755 }; }

            // nocd value's
            byte[][] data = {
                            new byte[] { 0x90, 0x90 },
                            new byte[] { 0xEB, 0x17 },
                            new byte[] { 0xEB, 0x3A },
                            new byte[] { 0xEB, 0x22 }
                            };

            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                for (int i = 0; i < addresses.Length; i++)
                {
                    long address = addresses[i];
                    byte[] value = data[i];

                    fileStream.Seek(address, SeekOrigin.Begin);

                    fileStream.Write(value, 0, value.Length);
                }
            }

        }


        //register FF7 for using withg FFNx
        private void regFF7(string drive)
        {
            File.Copy(Application.StartupPath + @"Tools\FF7reg.exe", Application.StartupPath + @"Game\FF7reg.exe", true);

            string ff7Reg = Application.StartupPath + @"Game\FF7reg.exe";

            ProcessStartInfo registerFF7 = new ProcessStartInfo(ff7Reg)
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
