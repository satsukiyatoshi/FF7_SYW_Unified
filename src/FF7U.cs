
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace FF7_SYW_Unified
{
    public partial class FF7U : Form
    {

        public FF7U()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //get translations list
            try
            {
                string[] translations = Directory.GetFiles(Application.StartupPath + @"\Translations\", "*.xml");
                for (var i = 0; i < translations.Length; i += 1)
                {
                    langInterface.Items.Add(Path.GetFileName(translations[i]).Replace(".xml", ""));
                }

                string[] langs = Directory.GetDirectories(Application.StartupPath + @"\Langs\");
                for (var i = 0; i < langs.Length; i += 1)
                {
                    langGame.Items.Add(Path.GetFileName(langs[i]).Replace(".xml", ""));
                }
            }

            catch
            {
                MessageBox.Show("Error while loading main translation file, please reinstall FF7 SYW Unified");
                Environment.Exit(0);
            }

            langInterface.Text = langInterface.GetItemText(langInterface.Items[0]);

            //set default menu status
            menuClick(menuAbout);
        }


        //display preview picture and description for SYW mods
        private void modShow(string name)
        {
            graphicPrevPic.ImageLocation = Application.StartupPath + @"Mods\SYW\Prev\" + name + ".jpg";
            graphicsHelp.Text = translate(name, Globals.translateUI);
            graphicsHelpAuthor.Text = translate(name + " author", Globals.translateUI);
        }


        //Backup mouse Y position
        private void getMousePos(object sender, EventArgs e) { Globals.mouseY = Cursor.Position.Y; }


        //display preview picture and description for combobox mods
        static void modShowCustom(ComboBox combo, string folderwSource, string modType, Label helpLabel, Label authorLabel, PictureBox prevPic)
        {
            string folderMod = "";
            string modDir = "";

            //resore mouse Y postion on combo before display mods information to avoid to display other mods information on-hover
            if (Globals.mouseY != 0)
            {
                Cursor.Position = new System.Drawing.Point (Cursor.Position.X, Globals.mouseY);
                Globals.mouseY = 0;
            }

            folderMod = getModCustomFolder(combo, folderwSource);

            prevPic.ImageLocation = folderMod + @"\prev.jpg";

            modDir = Path.GetFileName(folderMod);

            helpLabel.Text = translate("descriptionmod." + modType + "." + modDir, Globals.translateMod);
            authorLabel.Text = translate("authormod." + modType + "." + modDir, Globals.translateMod);
            Globals.actualModUrl = translate("urlmod." + modType + "." + modDir, Globals.translateMod);
            Globals.actualModFlags = translate("compatibilymod." + modType + "." + modDir, Globals.translateMod);
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


        private void setModFlags(Control modgroup) 
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


        private void launchGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("placeholder");
        }

    }

  }