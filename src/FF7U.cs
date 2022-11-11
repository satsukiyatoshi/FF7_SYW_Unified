
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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

            setDefaultUIValues();
            loadValues();

            //set default menu status
            menuClick(menuAbout);
        }


        //generate FFNx config file
        private void ffnxTomlGenerate()
        {
            string soundsFolder;

            TextWriter twx = new StreamWriter(Application.StartupPath + @"\Game\FFNx.toml", false);

                twx.WriteLine("renderer_backend = " + FFNx3dEngine.SelectedIndex.ToString());
                twx.WriteLine(@"mod_path = Mods\SYW\Textures");
                twx.WriteLine(@"mod_ext = dds");
                if (FFNxScreen.SelectedIndex == 0) { twx.WriteLine("fullscreen = true"); }
                if (FFNxScreen.SelectedIndex == 1) { twx.WriteLine("fullscreen = false"); twx.WriteLine("borderless = false"); }
                if (FFNxScreen.SelectedIndex == 2) { twx.WriteLine("fullscreen = false"); twx.WriteLine("borderless = true"); }
                if (FFNxResolution.SelectedIndex != 0) { twx.WriteLine("window_size_x = " + FFNxResolution.Text.Substring(0, FFNxResolution.Text.LastIndexOf("x"))); twx.WriteLine("window_size_y = " + FFNxResolution.Text.Substring(FFNxResolution.Text.LastIndexOf("x") + 1)); }
                twx.WriteLine("aspect_ratio = " + FFNxRatio.SelectedIndex.ToString());
                if (FFNxIR.SelectedIndex != 0) { twx.WriteLine("internal_resolution_scale = " + FFNxIR.Text.Substring(1)); }
                if (FFNxAA.SelectedIndex != 0) { twx.WriteLine("enable_antialiasing = " + FFNxAA.Text.Substring(1)); }
                twx.WriteLine("external_audio_number_of_channels = " + FFNxAudioChannels.SelectedIndex.ToString());
                if (FFNxAudioSample.SelectedIndex == 0) { twx.WriteLine("external_audio_sample_rate = 0"); } else { twx.WriteLine("external_audio_sample_rate = " + FFNxAudioSample.Text); }
                if (FFNxHDR.SelectedIndex != 0) { twx.WriteLine("hdr_max_nits = " + FFNxHDR.Text); }
                twx.WriteLine("ff7_fps_limiter = " + (FFNxFps.SelectedIndex + 1).ToString());
                twx.WriteLine("speedhack_step = " + FFNxSpeedhackStep.Text);
                twx.WriteLine("speedhack_min = " + FFNxSpeedhackMin.Text);
                twx.WriteLine("speedhack_max = " + FFNxSpeedhackMax.Text);
                twx.WriteLine("right_analog_stick_deadzone = " + FFNxContolerDeathzoneStick.Text);
                twx.WriteLine("right_analog_trigger_deadzone = " + FFNxContolerDeathzoneRT.Text);
                twx.WriteLine("left_analog_trigger_deadzone = " + FFNxContolerDeathzoneLT.Text);
                if (FFNxVsync.Checked) { twx.WriteLine("enable_vsync = true"); } else { twx.WriteLine("enable_vsync = false"); }
                if (FFNxAnisotropic.Checked) { twx.WriteLine("enable_anisotropic = true"); } else { twx.WriteLine("enable_anisotropic = false"); }
                if (FFNxLighting.Checked) { twx.WriteLine("enable_lighting = true"); } else { twx.WriteLine("enable_lighting = false"); }
                if (FFNXMusicResume.Checked) { twx.WriteLine("external_music_resume = true"); } else { twx.WriteLine("external_music_resume = false"); }
                if (FFNxFootSteps.Checked) { twx.WriteLine("ff7_footsteps = true"); } else { twx.WriteLine("ff7_footsteps = false"); }
                if (FFNXSteamSucces.Checked) { twx.WriteLine("enable_steam_achievements = true"); } else { twx.WriteLine("enable_steam_achievements = false"); }
                if (FFNxAnalogController.Checked) { twx.WriteLine("enable_analogue_controls = true"); } else { twx.WriteLine("enable_analogue_controls = false"); }
                if (graphicsAnimations.Checked) { twx.WriteLine("enable_animated_textures = true"); } else { twx.WriteLine("enable_animated_textures = false"); }

                if (FFNxShowStats.Checked)
                { 
                    twx.WriteLine("show_version = true");
                    twx.WriteLine("show_fps = true");
                    twx.WriteLine("show_renderer_backend = true");
                    twx.WriteLine("show_stats = true");
                }
                else
                {
                    twx.WriteLine("show_version = false");
                    twx.WriteLine("show_fps = false");
                    twx.WriteLine("show_renderer_backend = false");
                    twx.WriteLine("show_stats = false");
                }

                if (FFNxDebugTool.Checked)
                {
                    twx.WriteLine("enable_devtools = true");
                    twx.WriteLine("devtools_hotkey = 0x7B");
                }
                else
                {
                    twx.WriteLine("enable_devtools = false");
                }

                if (FFNxLogs.Checked)
                {
                    twx.WriteLine("more_debug = true");
                    twx.WriteLine("create_crash_dump = true");
                    twx.WriteLine("renderer_debug = true");
                    twx.WriteLine("trace_all = true");
                }
                else
                {
                    twx.WriteLine("more_debug = false");
                    twx.WriteLine("create_crash_dump = false");
                    twx.WriteLine("renderer_debug = false");
                    twx.WriteLine("trace_all = false");
                }

                if (soundsMusics.SelectedIndex == 0)
                {
                    twx.WriteLine("use_external_music = false");
                } 
                else
                {
                    soundsFolder = getModCustomFolder(soundsMusics, @"audio\musics");
                    twx.WriteLine("use_external_music = true");
                    twx.WriteLine("he_bios_path = \"" + soundsFolder.Remove(0, Application.StartupPath.Length) + @"\files" + "\"");
                    twx.WriteLine("external_music_ext = " + getSoundExts(soundsFolder));
                    twx.WriteLine("external_music_path = \"" + soundsFolder.Remove(0, Application.StartupPath.Length) + @"\files" + "\"");
                }

                if (soundsSfx.SelectedIndex == 0)
                {
                    twx.WriteLine("use_external_sfx = false");
                } 
                else
                {
                    soundsFolder = getModCustomFolder(soundsMusics, @"audio\sfxs");
                    twx.WriteLine("use_external_sfx = true");
                    twx.WriteLine("external_music_ext = " + getSoundExts(soundsFolder));
                    twx.WriteLine("external_sfx_path = \"" + soundsFolder.Remove(0, Application.StartupPath.Length) + @"\files" + "\"");
                }

                if (soundsVoices.SelectedIndex != 0)
                {
                    soundsFolder = getModCustomFolder(soundsMusics, @"audio\voices");
                    twx.WriteLine("external_voice_ext = " + getSoundExts(soundsFolder));
                    twx.WriteLine("external_voice_path = \"" + soundsFolder.Remove(0, Application.StartupPath.Length) + @"\files" + "\"");
                }

                if (soundsAmbients.SelectedIndex == 0)
                {
                    soundsFolder = getModCustomFolder(soundsMusics, @"audio\ambients");
                    twx.WriteLine("external_ambient_ext = " + getSoundExts(soundsFolder));
                    twx.WriteLine("external_ambient_path = \"" + soundsFolder.Remove(0, Application.StartupPath.Length) + @"\files" + "\"");
                }

                if (soundsFMV.SelectedIndex == 0)
                {
                    soundsFolder = getModCustomFolder(soundsMusics, @"audio\movies");
                    twx.WriteLine("external_movie_audio_ext = " + getSoundExts(soundsFolder));
                }

            // override_path = "override" pour mods textures
            // save_path = "save" pour mod gameplay

            twx.Close();
        }


        //restore all dds files and delete the currently used mods file
        private void restoreFiles()
        {
            List<string> disabledFiles = Directory.GetFiles(Application.StartupPath + @"mods\SYW\Textures", "*.SYWD", SearchOption.AllDirectories).ToList();
            List<string> currentFiles = Directory.GetFiles(Application.StartupPath + @"mods\Current", "*", SearchOption.AllDirectories).ToList();

            foreach (string file in disabledFiles)
            {
                File.Move(file, Path.ChangeExtension(file, ".dds"));
            }

            foreach (string file in currentFiles)
            {
                File.Delete(file);
            }
        }


        //disable texture file by renaming them to SYWD extention
        private void disableFiles (string textureFolder, Boolean subfolder = true)
        {
            List<string> files = Directory.GetFiles(Application.StartupPath + textureFolder, "*.dds", subfolder ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).ToList();

            foreach (string file in files)
            {
                File.Move(file, Path.ChangeExtension(file, ".SYWD"));
            }
        }


        //disable SYW textures depending choosen options
        private void applySywTextures()
        {
            if(!graphicsFields.Checked)
            {
                disableFiles(@"mods\SYW\Textures\char");
                disableFiles(@"mods\SYW\Textures\field");
                disableFiles(@"mods\SYW\Textures\flevel");
            }

            if(!graphicsBattles.Checked){ disableFiles(@"mods\SYW\battle"); }

            if (!graphicsMagics.Checked)
            {
                disableFiles(@"mods\SYW\Textures\magic");
                disableFiles(@"mods\SYW\Textures", false);
            }

            if (!graphicsWorldMap.Checked) { disableFiles(@"mods\SYW\world"); }

            if (!graphicsMiniGames.Checked)
            {
                disableFiles(@"mods\SYW\Textures\Chocobo");
                disableFiles(@"mods\SYW\Textures\coaster");
                disableFiles(@"mods\SYW\Textures\condor");
                disableFiles(@"mods\SYW\Textures\high");
                disableFiles(@"mods\SYW\Textures\snowboard");
                disableFiles(@"mods\SYW\Textures\sub");
            }

            //disable some texture files if no animation used to avoid bug in certains fields
            if (!graphicsAnimations.Checked && graphicsFields.Checked)
            {
                string file = "";

                var lines = File.ReadLines(Application.StartupPath + @"\Mods\SYW\disable.for.animation");
                foreach (var line in lines)
                {
                    file = Application.StartupPath + @"\Mods\SYW\Textures\field\" + line;
                    File.Move(file, Path.ChangeExtension(file, ".SYWD"));
                }
            }

        }


        //apply settings and launch the game
        private void launchGame_Click(object sender, EventArgs e)
        {
            playAudioClose();
            restoreFiles();
            applySywTextures();
            ffnxTomlGenerate();
            saveValues();
            MessageBox.Show("launch");
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