using System.Diagnostics;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {
        private void gameplayHelpAuthor_Click(object sender, EventArgs e) { openUrlMod(); }


        private void gameplayClear()
        {
            gameplayMods.Items.Clear();
        }



        private void gameplaySetDefaults()
        {
            setModsItems(gameplayMods, @"gameplay\");
            gameplayMods.Text = gameplayMods.Items[0].ToString();
        }



        private void gameplayModsChange(object sender, EventArgs e)
        {
            modShowCustom(gameplayMods, @"gameplay\", gameplayHelp, gameplayHelpAuthor, gameplayPrevPic);
            setModFlags(gameplayFrame1);

            if (Directory.Exists(getModCustomFolder(gameplayMods, @"gameplay\") + @"\docs"))
            {
                documentsFolder.Enabled = true;
            }
            else
            {
                documentsFolder.Enabled = false;
            }

            if (!Directory.Exists(getModCustomFolder(gameplayMods, @"gameplay\") + @"\save"))
            {
                Directory.CreateDirectory(getModCustomFolder(gameplayMods, @"gameplay\") + @"\save");
            }

        }



        private void saveByMod_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", getModCustomFolder(gameplayMods, @"gameplay\") + @"\save");
        }


        private void saveEdit_Click(object sender, EventArgs e)
        {
            string editIniFile = Application.StartupPath + @"\Tools\BlackChocobo\settings.ini";
            string[] lines = File.ReadAllLines(editIniFile);
            string lang = "en";
            string region = "PAL-E";

            if (Globals.gameLang == "F") { region = "PAL-FR"; }
            if (Globals.gameLang == "D") { region = "PAL-DE"; }
            if (Globals.gameLang == "S") { region = "PAL-ES"; }
            if (langInterface.Text == "Français") { lang = "fr"; }
            if (langInterface.Text == "Deutsch") { lang = "de"; }
            if (langInterface.Text == "Español") { lang = "es"; }

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("langPath="))
                {
                    lines[i] = "langPath=" + (Application.StartupPath + @"\Tools\BlackChocobo\").Replace("\\", "/");
                }
                else if (lines[i].StartsWith("region="))
                {
                    lines[i] = "region=" + region;
                }
                else if (lines[i].StartsWith("lang="))
                {
                    lines[i] = "lang=" + lang;
                }
                else if (lines[i].StartsWith("load_path="))
                {
                    lines[i] = "load_path=" + (getModCustomFolder(gameplayMods, @"gameplay\") + @"\save").Replace("\\", "/");
                }
            }

            File.WriteAllLines(editIniFile, lines);

            Process.Start(Application.StartupPath + @"\Tools\BlackChocobo\black_chocobo.exe");
        }



        private void documentsFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", getModCustomFolder(gameplayMods, @"gameplay\") + @"\docs");
        }


        private void saveByMod_MouseEnter(object sender, EventArgs e) { saveByMod.BackColor = Globals.activButtonBolor; }
        private void saveByMod_MouseLeave(object sender, EventArgs e) { saveByMod.BackColor = Globals.inactivButtonBolor; }
        private void saveEdit_MouseEnter(object sender, EventArgs e) { saveEdit.BackColor = Globals.activButtonBolor; }
        private void saveEdit_MouseLeave(object sender, EventArgs e) { saveEdit.BackColor = Globals.inactivButtonBolor; }
        private void documentsFolder_MouseEnter(object sender, EventArgs e) { documentsFolder.BackColor = Globals.activButtonBolor; }
        private void documentsFolder_MouseLeave(object sender, EventArgs e) { documentsFolder.BackColor = Globals.inactivButtonBolor; }

    }

}
