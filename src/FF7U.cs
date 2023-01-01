

using System.ComponentModel;
using System.Diagnostics;


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

            //set default placeholder pictures
            gameplayPrevPic.ImageLocation = Application.StartupPath + @"\Ressources\phgameplay.jpg";
            graphicPrevPic.ImageLocation = Application.StartupPath + @"\Ressources\phgaphics.jpg";
            soundPrevPic.ImageLocation = Application.StartupPath + @"\Ressources\phaudio.jpg";

            //set default menu status
            menuClick(menuAbout);
        }



        //apply settings and launch the game
        private void menuLaunchGame_Click(object sender, EventArgs e)
        {
            Globals.isGameLoading = true;
            menuFrame.Enabled = false;
            menuClick(menuLaunchGame);

            loadingAnimation.Visible = true;
            Application.DoEvents();

            loadingLog(translate("isoMount", Globals.translateUI));

            if (FFNxNoCd.Checked)
            {
                Globals.isodrive = getLastAvailableDriveLetter();
                mountIso(Globals.isodrive);
                regFF7(Globals.isodrive);
            }

            playAudioClose();
            restoreFiles();
            ApplyGameLang();
            applySywTextures();
            applyMods();
            applyPatchs();
            ffnxTomlGenerate();
            saveValues();

            this.Visible = false;   
            
            string ff7Path = Application.StartupPath + @"\Game\ff7.exe";

            ProcessStartInfo ff7Launch = new ProcessStartInfo(ff7Path)
            {
                WorkingDirectory = Path.GetDirectoryName(ff7Path),
                UseShellExecute = true,
                CreateNoWindow = false,
                WindowStyle = ProcessWindowStyle.Normal,
            };

            using (Process ff7 = Process.Start(ff7Launch))
            {
                ff7.WaitForExit();
            }

            Globals.isGameLoading = false;

            if (FFNxNoCd.Checked) { unmountIso(); }

            this.Close();

        }

        private void FormClosingCheck(Object sender, FormClosingEventArgs e)
        {
            if(Globals.isGameLoading)
            {
                string msg = translate("quit", Globals.translateUI);

                DialogResult result = MessageBox.Show(msg, "",
                    MessageBoxButtons.YesNo/*Cancel*/, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            if (FFNxNoCd.Checked) { unmountIso(); }
            playAudioClose();
            Process.GetCurrentProcess().Kill();
        }

    }

  }