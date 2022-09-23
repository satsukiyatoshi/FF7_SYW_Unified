
using System.Diagnostics;

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


        private void modsSetValues()
        {
            graphicsModels3Df.Items.Clear();
            graphicsModels3Dc.Items.Clear();

            graphicsModels3Df.Items.Add(Globals.vanilla);
            graphicsModels3Dc.Items.Add(Globals.vanilla);

            setModsItems(graphicsModels3Dc, @"Models\Battle\");

            graphicsModels3Df.Text = graphicsModels3Df.GetItemText(graphicsModels3Df.Items[0]);
            graphicsModels3Dc.Text = graphicsModels3Dc.GetItemText(graphicsModels3Dc.Items[0]);
        }


        private void setModsItems(ComboBox combo, string folderwSource)
        {
            string translationFile = "";

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
                    MessageBox.Show("Error with mod : " + dir + " Need at least one english translation file");
                    Process.GetCurrentProcess().Kill();
                }

                Globals.translateMod.Clear();
                getTranslationXml(translationFile, Globals.translateMod);
                combo.Items.Add(translate("name", Globals.translateMod));

            }

        }


        private void launchGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("launch game");
        }

    }

  }