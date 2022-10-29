
using System.Diagnostics;
using System.Diagnostics.Metrics;
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



        private void ffnxTomlGenerate()
        {
            string soundsFolder;

            TextWriter twx = new StreamWriter(Application.StartupPath + @"\FFNx.toml", false);

                twx.WriteLine("renderer_backend = " + FFNx3dEngine.SelectedIndex.ToString());
                twx.WriteLine(@"mod_path = Mods\SYW\Textures");
                twx.WriteLine(@"mod_ext = [""dds"", ""png"", ""tga"", ""tiff"", ""bmp"", ""jpg""]");
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



        private void launchGame_Click(object sender, EventArgs e)
        {
            playAudioClose();
            ffnxTomlGenerate();
            saveValues();
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