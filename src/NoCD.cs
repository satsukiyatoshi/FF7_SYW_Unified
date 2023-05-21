
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

                    //TODO need to fin exe offset to check version (check lang & version, if not 1.02 version based, output error)
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
