
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
        }

        /*
        private void FFNxHacksChange(object sender, EventArgs e)
        {
            modShowCustom(FFNxComboPatchs, @"Hacks\", FFNxHelp, FFNxHelpAuthor, gameplayPrevPic);
            setModFlags(FFNxFrame2);
        }
        */


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


    }
}
