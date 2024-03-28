
using System.Diagnostics;
using System.IO;
using System;
using System.Management;

namespace FF7_SYW_Unified
{
    public partial class FF7U : Form
    {

        private void initTrainers(int step)
        {
            TextWriter iniw = new StreamWriter(Application.StartupPath + @"\Mods\SYW\Trainer\FF7_Multi_Trainer.ini", false);
            iniw.WriteLine(Globals.gameLang);
            iniw.Close();

            TextWriter twx = new StreamWriter(Application.StartupPath + @"\Mods\SYW\Trainer\config.xml", false);

            if (step == 0)
            {
                twx.WriteLine("<trainers>");
            }


            if (step == 1) 
            {
                twx.WriteLine("</trainers>");
            }

            twx.Close();
        }


        private void enableTrainers()
        {
            folderCopyAll(new DirectoryInfo(Application.StartupPath + @"\Mods\SYW\Trainer"), new DirectoryInfo(Application.StartupPath + @"\Game\current"));
        }

    }
}
