
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

            string[] args = Environment.GetCommandLineArgs();
            foreach (string arg in args)
            {
                if (arg == "direct")
                {
                    if (File.Exists(Application.StartupPath + @"\Game\FFNx.toml") && File.Exists(Application.StartupPath + @"\settings.ini"))
                        Globals.directLaunch = true;
                }
            }

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

            //if "direct" is used as argument, then launch the game without any changes
            if (Globals.directLaunch == true)
            {
                menuLaunchGame_Click(sender, e);
            }
        }


        //apply settings and launch the game
        private void menuLaunchGame_Click(object sender, EventArgs e)
        {

            Globals.isGameLoading = true;
            menuFrame.Enabled = false;
            menuClick(menuLaunchGame);

            loadingAnimation.Visible = true;
            Application.DoEvents();

            loadingLog(translate("noCdExe", Globals.translateUI));

            //Apply mods only if not a direct launch
            if (Globals.directLaunch == false)
            {
                playAudioClose();
                restoreFiles();
                ApplyGameLang();
                applySywTextures();
                applyMods();
                applyPatchs();
                ffnxTomlGenerate();
                saveValues();

                string exeVersion = checkExeVersion();

                if (FFNxNoCd.Checked)
                {
                    if (exeVersion == "")
                    {
                        MessageBox.Show(translate("unknownExe", Globals.translateUI));
                    }
                    else
                    {
                        noCd(exeVersion);
                    }

                }
            }

            regFF7();

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

            this.Close();

        }


        private void FormClosingCheck(Object sender, FormClosingEventArgs e)
        {
            if (Globals.isGameLoading)
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

            playAudioClose();
            Process.GetCurrentProcess().Kill();
        }
    }

}