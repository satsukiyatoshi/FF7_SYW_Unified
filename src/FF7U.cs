
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
            playAudioClose();
            //restoreFiles();
            //applySywTextures();
            //applyMods();
            ffnxTomlGenerate();
            saveValues();
            Globals.isodrive = getLastAvailableDriveLetter();
            mountIso(Globals.isodrive);
            regFF7(Globals.isodrive);
            MessageBox.Show("launch");
            unmountIso();
        }


        /*
        protected virtual void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
        {
            playAudioClose();
            Application.DoEvents();
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "FormClosing Event");
            
        }
        */

    }

  }