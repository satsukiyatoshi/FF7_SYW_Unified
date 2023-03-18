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



        private void documentsFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", getModCustomFolder(gameplayMods, @"gameplay\") + @"\docs");
        }


        private void saveByMod_MouseEnter(object sender, EventArgs e) { saveByMod.BackColor = Globals.activButtonBolor; }
        private void saveByMod_MouseLeave(object sender, EventArgs e) { saveByMod.BackColor = Globals.inactivButtonBolor; }
        private void documentsFolder_MouseEnter(object sender, EventArgs e) { documentsFolder.BackColor = Globals.activButtonBolor; }
        private void documentsFolder_MouseLeave(object sender, EventArgs e) { documentsFolder.BackColor = Globals.inactivButtonBolor; }

    }

}
