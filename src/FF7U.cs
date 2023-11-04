
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

                //function to backup all save files in case of uninstall
                if (arg == "backupsaves")
                {
                    DateTime currentDate = DateTime.Now;

                    string targetFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\FF7_SYW_Saves_" + currentDate.ToString("yyyy-MM-dd-(HH") + "h" + currentDate.ToString("mm)");
                    string sourceFolderPath = Application.StartupPath + @"Mods\Gameplay";

                    Directory.CreateDirectory(targetFolderPath);

                    foreach (string subfolderPath in Directory.GetDirectories(sourceFolderPath))
                    {
                        string subfolderName = new DirectoryInfo(subfolderPath).Name;

                        string saveFolderPath = Path.Combine(subfolderPath, "save");
                        if (Directory.Exists(saveFolderPath) && Directory.GetFiles(saveFolderPath).Length > 0)
                        {
                            string targetSubfolderPath = Path.Combine(targetFolderPath, subfolderName, "save");
                            Directory.CreateDirectory(targetSubfolderPath);

                            foreach (string sourceFilePath in Directory.GetFiles(saveFolderPath))
                            {
                                string sourceFileName = Path.GetFileName(sourceFilePath);
                                string targetFilePath = Path.Combine(targetSubfolderPath, sourceFileName);
                                File.Copy(sourceFilePath, targetFilePath, true);
                            }
                        }
                    }


                    this.Close();
                }
            }


            using (StreamReader sr = new StreamReader(Application.StartupPath + @"\version.vrs"))
            {
                this.Text = "FF7_SYW_Unified " + sr.ReadLine();
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

            loadValues(Application.StartupPath + @"\lang.ini");
            setDefaultFFNxValues();
            setDefaultGameplayPatchsListValues();
            loadValues(Application.StartupPath + @"\settings.ini");

            //set default mod/placeholder pictures
            gameplayModsChange(this, EventArgs.Empty);
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
                applyGameplayPatchs();
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