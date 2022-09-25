
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace FF7_SYW_Unified
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //get translations list
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

            langInterface.Text = langInterface.GetItemText(langInterface.Items[0]);

            //set default menu status
            menuClick(menuAbout);
        }



        //display preview picture and description for SYW mods
        private void modShow(string path, string name)
        {
            graphicPrevPic.ImageLocation = Application.StartupPath + @"Prev\Mods\" + path + @"\" + name + ".jpg";
            graphicsHelp.Text = translate(name, Globals.translateUI);
            graphicsHelpAuthor.Text = translate(name + " author", Globals.translateUI);
        }



        //Backup mouse Y position
        private void getMousePos(object sender, EventArgs e) { Globals.mouseY = Cursor.Position.Y; }



        //display preview picture and description for combobox mods
        private void modShowCustom(ComboBox combo, string folderwSource, string modType)
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

            graphicPrevPic.ImageLocation = folderMod + @"\prev.jpg";

            modDir = Path.GetFileName(folderMod);

            graphicsHelp.Text = translate("descriptionmod." + modType + "." + modDir, Globals.translateMod);
            graphicsHelpAuthor.Text = translate("authormod." + modType + "." + modDir, Globals.translateMod);

        }



        private string getModCustomFolder(ComboBox combo, string folderwSource)
        {
            folderwSource = Application.StartupPath + @"mods\" + folderwSource;

            string[] dirs = Directory.GetDirectories(folderwSource, "*", SearchOption.TopDirectoryOnly);

            return dirs[combo.SelectedIndex];
        }



        private void launchGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("launch game");
        }

    }

  }