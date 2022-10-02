
namespace FF7_SYW_Unified
{
    partial class FF7U
    {
        private void soundsHelpAuthor_Click(object sender, EventArgs e) { openUrlMod(); }


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
        private void soundsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            playAudio(Globals.actualModFolder + soundsList.Items[soundsList.SelectedIndex]);
        }


        //stop playing of a previews audio file then launch the audio file
        private void playAudio(string audioFile)
        {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = Application.StartupPath + @"tools\f2k\foobar2000.exe";
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = false;

            if (Globals.isFoobarRunning)
            {
                pProcess.StartInfo.Arguments = "/stop";
                pProcess.Start();
                pProcess.WaitForExit();
            }

            pProcess.StartInfo.Arguments = "/nogui " + "\"" + audioFile + "\"";
            pProcess.Start();
            Globals.isFoobarRunning = true;
        }


        //exit the audio player engine
        private void playAudioClose()
        {
            if (Globals.isFoobarRunning)
            {
                System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
                pProcess.StartInfo.FileName = Application.StartupPath + @"tools\f2k\foobar2000.exe";
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = false;
                pProcess.StartInfo.Arguments = "/exit";
                pProcess.Start();
                pProcess.WaitForExit();
                Globals.isFoobarRunning = false;
            }
        }


        //list audio files for the mod
        private void listAudioFiles(string Folder)
        {
            soundsList.Items.Clear();

            string[] extensions = new[] { ".mp3", ".ogg", ".minipsf", ".aac", ".wav", ".flac" };
            DirectoryInfo dInfo = new DirectoryInfo(Folder);

            FileInfo[] files = dInfo.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();

            foreach (FileInfo file in files)
            {
                soundsList.Items.Add(file.Name);
            }
        }


        private void soundsChange(ComboBox soundCombo, string modFolder, string modIndex)
        {
            if (Globals.actualModFolder != getModCustomFolder(soundCombo, modFolder) + @"\files\")
            {
                modShowCustom(soundsMusics, modFolder, modIndex, soundsHelp, soundsHelpAuthor, soundPrevPic);
                Globals.actualModFolder = getModCustomFolder(soundCombo, modFolder) + @"\files\";
                listAudioFiles(Globals.actualModFolder);
            }
        }


        private void soundsMusicsChange(object sender, EventArgs e) { soundsChange(soundsMusics, @"audio\musics\", "audio.musics"); }
        private void soundsAmbiantChange(object sender, EventArgs e) { soundsChange(soundsAmbients, @"audio\ambients\", "audio.ambients"); }
        private void soundsSfxChange(object sender, EventArgs e) { soundsChange(soundsSfx, @"audio\sfxs\", @"audio.sfxs"); }
        private void soundsFMVChange(object sender, EventArgs e) { soundsChange(soundsFMV, @"audio\movies\", "audio.movies"); }
        private void soundsVoicesChange(object sender, EventArgs e) { soundsChange(soundsVoices, @"audio\voices\", "audio.voices"); }

    }
}
