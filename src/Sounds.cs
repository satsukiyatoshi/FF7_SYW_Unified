
namespace FF7_SYW_Unified
{
    partial class FF7U
    {

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
