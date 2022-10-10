using System.Diagnostics;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {

        //set items of combos mods option and put their translation to Globals.translateMod
        private void setModsItems(ComboBox combo, string folderwSource)
        {
            string translationFile = "";
            string modDir = "";

            folderwSource = Application.StartupPath + @"mods\" + folderwSource;

            string[] dirs = Directory.GetDirectories(folderwSource, "*", SearchOption.TopDirectoryOnly);

            foreach (string dir in dirs)
            {
                if (File.Exists(dir + @"\translations\" + langInterface.Text + ".xml"))
                {
                    translationFile = dir + @"\translations\" + langInterface.Text + ".xml";
                }
                else if (File.Exists(dir + @"\translations\english.xml"))
                {
                    translationFile = dir + @"\translations\english.xml";
                }
                else
                {
                    MessageBox.Show(translate("errorloadingmod", Globals.translateUI) + dir);
                    Process.GetCurrentProcess().Kill();
                }

                modDir = Path.GetFileName(dir);

                getTranslationXml(translationFile, Globals.translateMod, combo.Name + "." + modDir);
                combo.Items.Add(translate(combo.Name + "." + modDir, Globals.translateMod));

            }

        }



        //display preview picture and description for SYW mods and FFNx options
        private void modShow(string name, Label help, Label author)
        {
            graphicPrevPic.ImageLocation = Application.StartupPath + @"Mods\SYW\Prev\" + name + ".jpg";
            help.Text = translate(name + "help", Globals.translateUI);
            author.Text = translate(name + "author", Globals.translateUI);
            Globals.actualModUrl = translate(name + "url", Globals.translateUI);
        }



        //Backup mouse Y position
        private void getMousePos(object sender, EventArgs e) { Globals.mouseY = Cursor.Position.Y; }



        //Restore pouse Y position
        private void setMousePos(object sender, EventArgs e)
        {
            if (Globals.mouseY != 0)
            {
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X, Globals.mouseY);
                Globals.mouseY = 0;
            }
        }



        //display preview picture and description for combobox custom mods
        private void modShowCustom(ComboBox combo, string folderwSource, Label helpLabel, Label authorLabel, PictureBox prevPic)
        {
            string folderMod = "";
            string modDir = "";

            //TODO check if possible to use setMousePos ?//
            if (Globals.mouseY != 0)
            {
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X, Globals.mouseY);
                Globals.mouseY = 0;
            }

            folderMod = getModCustomFolder(combo, folderwSource);

            prevPic.ImageLocation = folderMod + @"\prev.jpg";

            modDir = Path.GetFileName(folderMod);

            helpLabel.Text = translate(combo.Name + "." + modDir + "help", Globals.translateMod);
            authorLabel.Text = translate(combo.Name + "." + modDir + "author", Globals.translateMod);
            Globals.actualModUrl = translate(combo.Name + "." + modDir + "url", Globals.translateMod);
            Globals.actualModFlags = translate(combo.Name + "." + modDir + "compatibily", Globals.translateMod);
        }



        static string getModCustomFolder(ComboBox combo, string folderwSource)
        {
            try
            {
                folderwSource = Application.StartupPath + @"mods\" + folderwSource;
                string[] dirs = Directory.GetDirectories(folderwSource, "*", SearchOption.TopDirectoryOnly);
                return dirs[combo.SelectedIndex];
            }

            catch
            {
                MessageBox.Show(translate("errorloadingmod", Globals.translateUI) + folderwSource);
                Process.GetCurrentProcess().Kill();
                return "";
            }
        }



        static void setModFlags(Control modgroup)
        {
            string flagFsource = Globals.actualModFlags.ToLower().Contains("f") ? Application.StartupPath + @"\Ressources\french.png" : Application.StartupPath + @"\Ressources\french-off.png";
            string flagEsource = Globals.actualModFlags.ToLower().Contains("e") ? Application.StartupPath + @"\Ressources\english.png" : Application.StartupPath + @"\Ressources\english-off.png";
            string flagGsource = Globals.actualModFlags.ToLower().Contains("g") ? Application.StartupPath + @"\Ressources\german.png" : Application.StartupPath + @"\Ressources\german-off.png";
            string flagSsource = Globals.actualModFlags.ToLower().Contains("s") ? Application.StartupPath + @"\Ressources\spain.png" : Application.StartupPath + @"\Ressources\spain-off.png";

            foreach (PictureBox pict in modgroup.Controls.OfType<PictureBox>())
            {
                if (pict.Name.Contains("flagF")) { pict.ImageLocation = flagFsource; }
                if (pict.Name.Contains("flagE")) { pict.ImageLocation = flagEsource; }
                if (pict.Name.Contains("flagG")) { pict.ImageLocation = flagGsource; }
                if (pict.Name.Contains("flagS")) { pict.ImageLocation = flagSsource; }
            }

        }

    }
}