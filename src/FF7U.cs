
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;
using SearchOption = System.IO.SearchOption;

namespace FF7_SYW_Unified
{
    public partial class FF7U : Form
    {

        public FF7U()
        {
            InitializeComponent();
        }



        //initialize form and load settings
        private void FF7U_Load(object sender, EventArgs e)
        {
            //get translations list
            try
            {
                string[] translations = Directory.GetFiles(Application.StartupPath + @"\Translations\", "*.xml");
                for (var i = 0; i < translations.Length; i += 1)
                {
                    langInterface.Items.Add(Path.GetFileName(translations[i]).Replace(".xml", ""));
                }

                langGame.Items.Add("Français");
                langGame.Items.Add("English");
                langGame.Items.Add("Deutsch");
                langGame.Items.Add("Español");
            }

            catch
            {
                MessageBox.Show("Error while loading main translation file, please reinstall FF7 SYW Unified");
                Environment.Exit(0);
            }

            langInterface.Text = langInterface.GetItemText(langInterface.Items[0]);

            setDefaultUIValues();
            loadValues();

            //set default menu status
            menuClick(menuAbout);
        }



        //apply settings and launch the game
        private void launchGame_Click(object sender, EventArgs e)
        {
            if (FFNxNoCd.Checked)
            {
                Globals.isodrive = getLastAvailableDriveLetter();
                mountIso(Globals.isodrive);
                regFF7(Globals.isodrive);
            }

            MessageBox.Show("iso");
            playAudioClose();
            restoreFiles();
            applySywTextures();
            applyMods();
            applyPatchs();
            ffnxTomlGenerate();
            saveValues();

            string ff7Path = Application.StartupPath + @"\Game\ff7.exe";

            ProcessStartInfo ff7Launch = new ProcessStartInfo(ff7Path)
            {
                WorkingDirectory = Path.GetDirectoryName(ff7Path),
                UseShellExecute = false,
                CreateNoWindow = false,
                WindowStyle = ProcessWindowStyle.Normal,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };

            using (Process ff7 = Process.Start(ff7Launch))
            {
                ff7.WaitForExit(1000);
            }


            if (FFNxNoCd.Checked) { unmountIso(); }

        }

    }

  }