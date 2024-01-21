
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Reflection.PortableExecutable;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {

        private void FFNxHelpAuthor_Click(object sender, EventArgs e) { openUrlMod(); }


        //register FF7 for using withg FFNx
        private void regFF7()
        {
            File.Copy(Application.StartupPath + @"Tools\FF7reg.exe", Application.StartupPath + @"Game\FF7reg.exe", true);

            string ff7Reg = Application.StartupPath + @"Game\FF7reg.exe";

            ProcessStartInfo registerFF7 = new ProcessStartInfo(ff7Reg)
            {
                WorkingDirectory = Path.GetDirectoryName(ff7Reg),
                UseShellExecute = true,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
            };

            using (Process reg = Process.Start(registerFF7))
            {
                reg.WaitForExit(10000);
            }

            File.Delete(ff7Reg);
        }



        //set default values for FFNx settings
        private void setDefaultFFNxValues()
        {
            FFNxComboPatchs.Items.Clear();
            FFNxPatchsList.Items.Clear();
            FFNx3dEngine.Items.Clear();
            FFNxScreen.Items.Clear();
            FFNxResolution.Items.Clear();
            FFNxRatio.Items.Clear();
            FFNxIR.Items.Clear();
            FFNxHDR.Items.Clear();
            FFNxAA.Items.Clear();
            FFNxFps.Items.Clear();
            FFNxAudioChannels.Items.Clear();
            FFNxAudioSample.Items.Clear();
            FFNxSpeedhackStep.Items.Clear();
            FFNxSpeedhackMin.Items.Clear();
            FFNxSpeedhackMax.Items.Clear();
            FFNxContolerDeathzoneStick.Items.Clear();
            FFNxContolerDeathzoneLT.Items.Clear();
            FFNxContolerDeathzoneRT.Items.Clear();
            FFNxalphaValue.Items.Clear();

            FFNxalphaValue.Items.Add("0 %");
            FFNxalphaValue.Items.Add("10 %");
            FFNxalphaValue.Items.Add("20 %");
            FFNxalphaValue.Items.Add("30 %");
            FFNxalphaValue.Items.Add("40 %");
            FFNxalphaValue.Items.Add("50 %");
            FFNxalphaValue.Items.Add("60 %");
            FFNxalphaValue.Items.Add("70 %");
            FFNxalphaValue.Items.Add("80 %");
            FFNxalphaValue.Items.Add("90 %");
            FFNxalphaValue.Items.Add("100 %");
            FFNxalphaValue.Text = "0 %";

            FFNx3dEngine.Items.Add(translate("auto", Globals.translateUI));
            FFNx3dEngine.Items.Add("OpenGL");
            FFNx3dEngine.Items.Add("Direct3D9");
            FFNx3dEngine.Items.Add("Direct3D11");
            FFNx3dEngine.Items.Add("Direct3D12");
            FFNx3dEngine.Items.Add("Vulkan");
            FFNx3dEngine.Text = translate("auto", Globals.translateUI);

            FFNxScreen.Items.Add(translate("fullscreen", Globals.translateUI));
            FFNxScreen.Items.Add(translate("windowed", Globals.translateUI));
            FFNxScreen.Items.Add(translate("windowedborderless", Globals.translateUI));
            FFNxScreen.Text = (translate("fullscreen", Globals.translateUI));

            FFNxResolution.Items.Add(translate("auto", Globals.translateUI));
            getScreenResolutions();
            FFNxResolution.Text = (translate("auto", Globals.translateUI));

            FFNxRatio.Items.Add("4/3 (" + translate("vanilla", Globals.translateUI) + ")");
            FFNxRatio.Items.Add(translate("strechedwidescreen", Globals.translateUI));
            FFNxRatio.Items.Add(translate("realwidescreen", Globals.translateUI));
            FFNxRatio.Items.Add(translate("realwidescreendeck", Globals.translateUI));
            FFNxRatio.Text = ("4/3 (" + translate("vanilla", Globals.translateUI) + ")");

            FFNxIR.Items.Add(translate("auto", Globals.translateUI));
            FFNxIR.Items.Add("x1");
            FFNxIR.Items.Add("x2");
            FFNxIR.Items.Add("x4");
            FFNxIR.Items.Add("x8");
            FFNxIR.Text = translate("auto", Globals.translateUI);

            FFNxHDR.Items.Add(translate("auto", Globals.translateUI));
            FFNxHDR.Items.Add("100");
            FFNxHDR.Items.Add("200");
            FFNxHDR.Items.Add("300");
            FFNxHDR.Items.Add("400");
            FFNxHDR.Items.Add("500");
            FFNxHDR.Items.Add("600");
            FFNxHDR.Items.Add("700");
            FFNxHDR.Items.Add("800");
            FFNxHDR.Items.Add("900");
            FFNxHDR.Items.Add("1000");
            FFNxHDR.Items.Add("1100");
            FFNxHDR.Items.Add("1200");
            FFNxHDR.Items.Add("1300");
            FFNxHDR.Items.Add("1400");
            FFNxHDR.Items.Add("1500");
            FFNxHDR.Text = translate("auto", Globals.translateUI);

            FFNxAA.Items.Add(translate("disabled", Globals.translateUI));
            FFNxAA.Items.Add("x2");
            FFNxAA.Items.Add("x4");
            FFNxAA.Items.Add("x6");
            FFNxAA.Items.Add("x8");
            FFNxAA.Text = "x4";

            FFNxSpeedhackStep.Items.Add("0.5");
            FFNxSpeedhackStep.Items.Add("1.0");
            FFNxSpeedhackStep.Items.Add("1.5");
            FFNxSpeedhackStep.Items.Add("2.0");
            FFNxSpeedhackStep.Items.Add("2.5");
            FFNxSpeedhackStep.Items.Add("3.0");
            FFNxSpeedhackStep.Text = ("1.0");

            FFNxSpeedhackMin.Items.Add("1.0");
            FFNxSpeedhackMin.Items.Add("1.5");
            FFNxSpeedhackMin.Items.Add("2.0");
            FFNxSpeedhackMin.Items.Add("2.5");
            FFNxSpeedhackMin.Items.Add("3.0");
            FFNxSpeedhackMin.Text = ("1.0");

            FFNxSpeedhackMax.Items.Add("1.5");
            FFNxSpeedhackMax.Items.Add("2.0");
            FFNxSpeedhackMax.Items.Add("3.0");
            FFNxSpeedhackMax.Items.Add("4.0");
            FFNxSpeedhackMax.Items.Add("5.0");
            FFNxSpeedhackMax.Items.Add("6.0");
            FFNxSpeedhackMax.Items.Add("7.0");
            FFNxSpeedhackMax.Items.Add("8.0");
            FFNxSpeedhackMax.Text = ("4.0");

            FFNxContolerDeathzoneStick.Items.Add("0.0");
            FFNxContolerDeathzoneStick.Items.Add("0.1");
            FFNxContolerDeathzoneStick.Items.Add("0.2");
            FFNxContolerDeathzoneStick.Items.Add("0.3");
            FFNxContolerDeathzoneStick.Items.Add("0.4");
            FFNxContolerDeathzoneStick.Items.Add("0.5");
            FFNxContolerDeathzoneStick.Items.Add("0.6");
            FFNxContolerDeathzoneStick.Items.Add("0.7");
            FFNxContolerDeathzoneStick.Items.Add("0.8");
            FFNxContolerDeathzoneStick.Items.Add("0.9");
            FFNxContolerDeathzoneStick.Items.Add("1.0");
            FFNxContolerDeathzoneStick.Text = "0.1";

            FFNxContolerDeathzoneLT.Items.Add("0.0");
            FFNxContolerDeathzoneLT.Items.Add("0.1");
            FFNxContolerDeathzoneLT.Items.Add("0.2");
            FFNxContolerDeathzoneLT.Items.Add("0.3");
            FFNxContolerDeathzoneLT.Items.Add("0.4");
            FFNxContolerDeathzoneLT.Items.Add("0.5");
            FFNxContolerDeathzoneLT.Items.Add("0.6");
            FFNxContolerDeathzoneLT.Items.Add("0.7");
            FFNxContolerDeathzoneLT.Items.Add("0.8");
            FFNxContolerDeathzoneLT.Items.Add("0.9");
            FFNxContolerDeathzoneLT.Items.Add("1.0");
            FFNxContolerDeathzoneLT.Text = "0.1";

            FFNxContolerDeathzoneRT.Items.Add("0.0");
            FFNxContolerDeathzoneRT.Items.Add("0.1");
            FFNxContolerDeathzoneRT.Items.Add("0.2");
            FFNxContolerDeathzoneRT.Items.Add("0.3");
            FFNxContolerDeathzoneRT.Items.Add("0.4");
            FFNxContolerDeathzoneRT.Items.Add("0.5");
            FFNxContolerDeathzoneRT.Items.Add("0.6");
            FFNxContolerDeathzoneRT.Items.Add("0.7");
            FFNxContolerDeathzoneRT.Items.Add("0.8");
            FFNxContolerDeathzoneRT.Items.Add("0.9");
            FFNxContolerDeathzoneRT.Items.Add("1.0");
            FFNxContolerDeathzoneRT.Text = "0.1";

            FFNxFps.Items.Add(translate("vanilla", Globals.translateUI));
            FFNxFps.Items.Add(translate("gamefpsbattle30", Globals.translateUI));
            FFNxFps.Items.Add(translate("gamefull60fps", Globals.translateUI));
            FFNxFps.Text = translate("vanilla", Globals.translateUI);

            FFNxAudioChannels.Items.Add(translate("auto", Globals.translateUI));
            FFNxAudioChannels.Items.Add("1.0");
            FFNxAudioChannels.Items.Add("2.0");
            FFNxAudioChannels.Items.Add("2.1");
            FFNxAudioChannels.Items.Add("3.0");
            FFNxAudioChannels.Items.Add("3.1");
            FFNxAudioChannels.Items.Add("4.0");
            FFNxAudioChannels.Items.Add("4.1");
            FFNxAudioChannels.Items.Add("5.0");
            FFNxAudioChannels.Items.Add("5.1");
            FFNxAudioChannels.Items.Add("6.0");
            FFNxAudioChannels.Items.Add("6.1");
            FFNxAudioChannels.Items.Add("7.0");
            FFNxAudioChannels.Items.Add("7.1");
            FFNxAudioChannels.Text = "2.0";

            FFNxAudioSample.Items.Add(translate("auto", Globals.translateUI));
            FFNxAudioSample.Items.Add("8000");
            FFNxAudioSample.Items.Add("11025");
            FFNxAudioSample.Items.Add("22050");
            FFNxAudioSample.Items.Add("32000");
            FFNxAudioSample.Items.Add("44100");
            FFNxAudioSample.Items.Add("48000");
            FFNxAudioSample.Items.Add("88200");
            FFNxAudioSample.Items.Add("96000");
            FFNxAudioSample.Items.Add("174000");
            FFNxAudioSample.Items.Add("192000");
            FFNxAudioSample.Text = "44100";

            setModsItems(FFNxComboPatchs, @"Patchs\");
            foreach (var item in FFNxComboPatchs.Items)
            {
                FFNxPatchsList.Items.Add(item);
            }
        }



        private void FFNxPatchsList_MouseMove(object sender, MouseEventArgs e)
        {

            Point pos = FFNxPatchsList.PointToClient(MousePosition);

            int index = FFNxPatchsList.IndexFromPoint(pos);

            if (index > -1)
            {
                FFNxComboPatchs.Text = FFNxPatchsList.Items[index].ToString();
                modShowCustom(FFNxComboPatchs, @"Patchs\", FFNxHelp, FFNxHelpAuthor);
                setModFlags(FFNxFrame1);
            }

            // use 25 ms sleep to avoid overkill cpu usage with the mousemove check
            Thread.Sleep(25);

        }



        private void FFNxAnalogController_CheckedChanged(object sender, EventArgs e)
        {
            if(Globals.formSettingsLoaded == true)
            {
                if (FFNxAnalogController.Checked == false)
                {
                    FFNxAnalogControllerArun.Checked = false;
                    graphicsCosmosGaia.Checked = false;
                }
            }
        }


        private void FFNxAnalogControllerArun_CheckedChanged(object sender, EventArgs e)
        {
            if (Globals.formSettingsLoaded == true)
            {
                if (FFNxAnalogController.Checked == false)
                {
                    FFNxAnalogControllerArun.Checked = false;
                }
            }
        }



        private void applyPatchs()
        {

            loadingLog(FFNxFrame1.Text);

            int i;

            for (i = 0; i <= (FFNxPatchsList.Items.Count - 1); i++)
            {
                if (FFNxPatchsList.GetItemChecked(i))
                {
                    string[] dirs = Directory.GetDirectories(Application.StartupPath + @"mods\Patchs", "*", SearchOption.TopDirectoryOnly);
                    folderModCopy(dirs[i]);
                }
            }


            if (FFNxalphaValue.Text != "0 %" && (FFNxAlphaDiag.Checked || FFNxAlphaBattle.Checked))
            {
                int alphaValue = 255 - (int)Math.Round(double.Parse(FFNxalphaValue.Text.TrimEnd('%')) * 2.55);
                if (alphaValue < 0) { alphaValue = 0; }
                string alphaPatchValue = alphaValue.ToString("X");

                string lastLine = "6E6C53 = " + alphaPatchValue;
                string hextLang = "";

                if(Globals.gameLang == "F") {hextLang="fr";}
                if(Globals.gameLang == "E") {hextLang="en";}
                if(Globals.gameLang == "G") {hextLang="es";}
                if(Globals.gameLang == "S") {hextLang="de";}

                string hextLangFile = Application.StartupPath + @"mods\SYW\Alphadiag\Common\Files\Hext\ff7\" + hextLang + @"\FFNx._GLOBALS.txt";

                var lignes = File.ReadAllLines(hextLangFile).ToList();
                lignes[lignes.Count - 1] = lastLine;
                File.WriteAllLines(hextLangFile, lignes);

                folderModCopy(Application.StartupPath + @"mods\SYW\Alphadiag\Common");
                if (FFNxAlphaDiag.Checked) { folderModCopy(Application.StartupPath + @"mods\SYW\Alphadiag\Dialogs");}
                if (FFNxAlphaBattle.Checked) { folderModCopy(Application.StartupPath + @"mods\SYW\Alphadiag\Battle");}
            }

            if(graphicsCosmosGaia.Checked && FFNxAnalogController.Checked)
            {
                folderModCopy(Application.StartupPath + @"mods\SYW\Gaia");
            }

            if(FFNxRatio.SelectedIndex == 2 || FFNxRatio.SelectedIndex == 3)
            {
                Directory.Move(Application.StartupPath + @"Game\widescreen_u", Application.StartupPath + @"Game\widescreen");
                Directory.Move(Application.StartupPath + @"Mods\SYW\Textures\field", Application.StartupPath + @"Mods\SYW\Textures\field_origin");
                Directory.Move(Application.StartupPath + @"Mods\SYW\Textures\field_limitb", Application.StartupPath + @"Mods\SYW\Textures\field");
                folderModCopy(Application.StartupPath + @"mods\SYW\LimitBreak");
            }
        }



        private void FFNxGroupFps_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupFps", FFNxHelp, FFNxHelpAuthor,false); }
        private void FFNxShowStats_MouseEnter(object sender, EventArgs e) { modShow("FFNxShowStats", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxDebugTool_MouseEnter(object sender, EventArgs e) { modShow("FFNxDebugTool", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxFootSteps_MouseEnter(object sender, EventArgs e) { modShow("FFNxFootSteps", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxLogs_MouseEnter(object sender, EventArgs e) { modShow("FFNxLogs", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxGroupSpeedhack_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupSpeedhack", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxGroupControllerDeathzones_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupControllerDeathzones", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxGroupAudioSample_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupAudioSample", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxGroupIR_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupIR", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxGroupAudioChannels_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupAudioChannels", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxGroupAA_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupAA", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxGroupResolution_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupResolution", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxGroupHDR_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupHDR", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxGroupRatio_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupRatio", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxGroupScreen_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupScreen", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxVsync_MouseEnter(object sender, EventArgs e) { modShow("FFNxVsync", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNXMusicResume_MouseEnter(object sender, EventArgs e) { modShow("FFNXMusicResume", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxAnisotropic_MouseEnter(object sender, EventArgs e) { modShow("FFNxAnisotropic", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxAnalogController_MouseEnter(object sender, EventArgs e) { modShow("FFNxAnalogController", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxAnalogControllerArun_MouseEnter(object sender, EventArgs e) { modShow("FFNxAnalogControllerArun", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNXSteamSucces_MouseEnter(object sender, EventArgs e) { modShow("FFNXSteamSucces", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxGroup3dEngine_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroup3dEngine", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxNoCd_MouseEnter(object sender, EventArgs e) { modShow("FFNxNoCd", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxGroupAlphaDiag_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupAlphaDiag", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxalphaValue_MouseEnter(object sender, EventArgs e) { modShow("FFNxalphaValue", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxAlphaDiag_MouseEnter(object sender, EventArgs e) { modShow("FFNxAlphaDiag", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxAlphaBattle_MouseEnter(object sender, EventArgs e) { modShow("FFNxAlphaBattle", FFNxHelp, FFNxHelpAuthor, false); }
        private void FFNxGamutNtsc_MouseEnter(object sender, EventArgs e) { modShow("FFNxGamutNtsc", FFNxHelp, FFNxHelpAuthor, false); }

        //generate FFNx config file
        private void ffnxTomlGenerate()
        {
            loadingLog(translate("ffnxConfigFile", Globals.translateUI));

            string soundsFolder;
            string quote = "\"";
            string soundsExts = getSoundExts(Application.StartupPath + @"\Mods\Audio\exts");

            TextWriter twx = new StreamWriter(Application.StartupPath + @"\Game\FFNx.toml", false);

            twx.WriteLine("renderer_backend = " + FFNx3dEngine.SelectedIndex.ToString());
            twx.WriteLine("mod_path = " + quote + @"..\Mods\SYW\Textures" + quote);
            twx.WriteLine("mod_ext = " + quote + "dds" + quote);
            twx.WriteLine("hext_patching_path = " + quote + @"current\Hext" + quote);
            twx.WriteLine("direct_mode_path = " + quote + @"current\Direct" + quote);
            twx.WriteLine("override_path = " + quote + @"current\Data" + quote);
            twx.WriteLine("override_mod_path = " + quote + @"current\Textures" + quote);
            if (graphicsCosmosGaia.Checked && FFNxAnalogController.Checked)
            {
                twx.WriteLine("external_mesh_path = " + quote + @"..\Mods\SYW\Gaia\mesh" + quote);
                twx.WriteLine("enable_worldmap_external_mesh = true"); 
            }
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
            if (FFNxAnalogControllerArun.Checked) { twx.WriteLine("enable_auto_run = true"); } else { twx.WriteLine("enable_auto_run = false"); }
            if (graphicsAnimations.Checked) { twx.WriteLine("enable_animated_textures = true"); } else { twx.WriteLine("enable_animated_textures = false"); }
            if (FFNxGamutNtsc.Checked) { twx.WriteLine("enable_ntscj_gamut_mode = true"); } else { twx.WriteLine("enable_ntscj_gamut_mode = false"); }
            twx.WriteLine("save_path = " + quote + @"..\" + (getModCustomFolder(gameplayMods, @"gameplay\")).Remove(0, Application.StartupPath.Length) + @"\save" + quote);

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
                twx.WriteLine("use_external_music = true");
                twx.WriteLine("external_music_ext = " + soundsExts);
                twx.WriteLine("external_music_path = " + quote + @"current\musics" + quote);
                twx.WriteLine("he_bios_path = " + quote + @"current\musics\hebios.bin" + quote);
            }

            if (soundsSfx.SelectedIndex == 0)
            {
                twx.WriteLine("use_external_sfx = false");
            }
            else
            {
                twx.WriteLine("use_external_sfx = true");
                twx.WriteLine("external_sfx_ext = " + soundsExts);
                twx.WriteLine("external_sfx_path = " + quote + @"current\sfxs" + quote);
            }

            if (soundsVoices.SelectedIndex != 0)
            {
                twx.WriteLine("external_voice_ext = " + soundsExts);
                twx.WriteLine("external_voice_path = " + quote + @"current\voices" + quote);
            }

            if (soundsAmbients.SelectedIndex != 0)
            {
                twx.WriteLine("external_ambient_ext = " + soundsExts);
                twx.WriteLine("external_ambient_path = " + quote + @"current\ambiants" + quote);
            }

            if (soundsFMV.SelectedIndex != 0)
            {
                twx.WriteLine("external_movie_audio_ext = " + soundsExts);
                twx.WriteLine("ff7_external_opening_music = false "); //disabled for now, need a driver evolution or it'll need several opening fmv version
            }
            twx.Close();

            //convert '\' in '/' for  FFNx use
            string tomlFile = File.ReadAllText(Application.StartupPath + @"\Game\FFNx.toml");
            tomlFile = tomlFile.Replace(@"\", "/");
            File.WriteAllText(Application.StartupPath + @"\Game\FFNx.toml", tomlFile);
        }
    }
}
