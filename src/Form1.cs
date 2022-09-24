
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


        //display preview picture and description for combobox mods
        private void modShowCustom(ComboBox combo, string folderwSource, string modType)
        {
            string folderMod = "";
            string modDir = "";

            folderwSource = Application.StartupPath + @"mods\" + folderwSource;

            string[] dirs = Directory.GetDirectories(folderwSource, "*", SearchOption.TopDirectoryOnly);

            folderMod = dirs[combo.SelectedIndex];

            graphicPrevPic.ImageLocation = folderMod + @"\prev.jpg";

            modDir = Path.GetFileName(folderMod);

            graphicsHelp.Text = translate("descriptionmod." + modType + "." + modDir, Globals.translateMod);
            graphicsHelpAuthor.Text = translate("authormod." + modType + "." + modDir, Globals.translateMod);
        }


        private void launchGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("launch game");
        }

    }

  }