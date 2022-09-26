
namespace FF7_SYW_Unified
{
    partial class FF7U
    {

        private void soundsClear()
        {
            soundsMusics.Items.Clear();
            soundsAmbients.Items.Clear();
            soundsSfx.Items.Clear();
            soundsFMV.Items.Clear();
            soundsVoices.Items.Clear();
        }

        private void soundsSetDefaults()
        {
            setModsItems(soundsMusics, @"audio\musics\", "audio.musics");
            setModsItems(soundsAmbients, @"audio\ambients\", "audio.ambients");
            setModsItems(soundsSfx, @"audio\sfxs\", "audio.sfxs");
            setModsItems(soundsFMV, @"audio\movies\", "audio.movies");
            setModsItems(soundsVoices, @"audio\voices\", "audio.voices");

            soundsMusics.Text = soundsMusics.Items[0].ToString();
            soundsAmbients.Text = soundsAmbients.Items[0].ToString();
            soundsSfx.Text = soundsSfx.Items[0].ToString();
            soundsFMV.Text = soundsFMV.Items[0].ToString();
            soundsVoices.Text = soundsVoices.Items[0].ToString();
        }

        private void soundsGroupMusics_MouseEnter(object sender, EventArgs e) { modShowCustom(soundsMusics, @"audio\musics\", "audio.musics", soundsHelp, soundsHelpAuthor); }
        private void soundsMusics_SelectedIndexChanged(object sender, EventArgs e) { modShowCustom(soundsMusics, @"audio\musics\", "audio.musics", soundsHelp, soundsHelpAuthor); }
        private void soundsGroupAmbients_MouseEnter(object sender, EventArgs e) { modShowCustom(soundsAmbients, @"audio\ambients\", "audio.ambients", soundsHelp, soundsHelpAuthor); }
        private void soundsAmbients_SelectedIndexChanged(object sender, EventArgs e) { modShowCustom(soundsAmbients, @"audio\ambients\", "audio.ambients", soundsHelp, soundsHelpAuthor); }
        private void soundsGroupSfx_MouseEnter(object sender, EventArgs e) { modShowCustom(soundsSfx, @"audio\sfxs\", "audio.sfxs", soundsHelp, soundsHelpAuthor); }
        private void soundsSfx_SelectedIndexChanged(object sender, EventArgs e) { modShowCustom(soundsSfx, @"audio\sfxs\", "audio.sfxs", soundsHelp, soundsHelpAuthor); }
        private void soundsGroupFMV_MouseEnter(object sender, EventArgs e) { modShowCustom(soundsFMV, @"audio\movies\", "audio.movies", soundsHelp, soundsHelpAuthor); }
        private void soundsFMV_SelectedIndexChanged(object sender, EventArgs e) { modShowCustom(soundsFMV, @"audio\movies\", "audio.movies", soundsHelp, soundsHelpAuthor); }
        private void soundsGroupVoices_MouseEnter(object sender, EventArgs e) { modShowCustom(soundsVoices, @"audio\voices\", "audio.voices", soundsHelp, soundsHelpAuthor); }
        private void soundsVoices_SelectedIndexChanged(object sender, EventArgs e) { modShowCustom(soundsVoices, @"audio\voices\", "audio.voices", soundsHelp, soundsHelpAuthor); }

    }

}
