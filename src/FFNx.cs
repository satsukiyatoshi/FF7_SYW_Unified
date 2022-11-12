
using System.Windows.Forms;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {

        private void FFNxHelpAuthor_Click(object sender, EventArgs e) { openUrlMod(); }



        private void FFNxClear()
        {
            FFNxComboPatchs.Items.Clear();
            FFNxPatchsList.Items.Clear();
        }



        private void FFNxSetDefaults()
        {
            setModsItems(FFNxComboPatchs, @"Hacks\");
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
                modShowCustom(FFNxComboPatchs, @"Hacks\", FFNxHelp, FFNxHelpAuthor, FFNxPrevPic);
                setModFlags(FFNxFrame1);
            }

            // use 25 ms sleep to avoid overkill cpu usage with the mousemove check
            Thread.Sleep(25);

        }



        private void FFNxGroupFps_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupFps", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxShowStats_MouseEnter(object sender, EventArgs e) { modShow("FFNxShowStats", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxDebugTool_MouseEnter(object sender, EventArgs e) { modShow("FFNxDebugTool", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxFootSteps_MouseEnter(object sender, EventArgs e) { modShow("FFNxFootSteps", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxLogs_MouseEnter(object sender, EventArgs e) { modShow("FFNxLogs", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxGroupSpeedhack_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupSpeedhack", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxGroupControllerDeathzones_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupControllerDeathzones", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxGroupAudioSample_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupAudioSample", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxGroupIR_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupIR", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxGroupAudioChannels_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupAudioChannels", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxGroupAA_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupAA", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxGroupResolution_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupResolution", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxGroupHDR_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupHDR", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxGroupRatio_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupRatio", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxGroupScreen_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroupScreen", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxVsync_MouseEnter(object sender, EventArgs e) { modShow("FFNxVsync", FFNxHelp, FFNxHelpAuthor); }
        private void FFNXMusicResume_MouseEnter(object sender, EventArgs e) { modShow("FFNXMusicResume", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxAnisotropic_MouseEnter(object sender, EventArgs e) { modShow("FFNxAnisotropic", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxAnalogController_MouseEnter(object sender, EventArgs e) { modShow("FFNxAnalogController", FFNxHelp, FFNxHelpAuthor); }
        private void FFNXSteamSucces_MouseEnter(object sender, EventArgs e) { modShow("FFNXSteamSucces", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxGroup3dEngine_MouseEnter(object sender, EventArgs e) { modShow("FFNxGroup3dEngine", FFNxHelp, FFNxHelpAuthor); }
        private void FFNxLighting_MouseEnter(object sender, EventArgs e) { modShow("FFNxLighting", FFNxHelp, FFNxHelpAuthor); }



        //generate FFNx config file
        private void ffnxTomlGenerate()
        {
            string soundsFolder;

            TextWriter twx = new StreamWriter(Application.StartupPath + @"\Game\FFNx.toml", false);

            twx.WriteLine("renderer_backend = " + FFNx3dEngine.SelectedIndex.ToString());
            twx.WriteLine(@"mod_path = Mods\SYW\Textures");
            twx.WriteLine(@"mod_ext = dds");
            twx.WriteLine(@"hext_patching_path = Mods\Current\Hext");
            twx.WriteLine(@"direct_mode_path = Mods\Current\Direct");
            twx.WriteLine(@"override_path = Mods\Current\Data");
            twx.WriteLine(@"override_mod_path = Mods\Current\Textures");
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
            // save_path = "save" pour mod gameplay
            twx.Close();
        }
    }
}
