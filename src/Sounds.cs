﻿
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
            setModsItems(soundsMusics, @"audio\musics\");
            setModsItems(soundsAmbients, @"audio\ambients\");
            setModsItems(soundsSfx, @"audio\sfxs\");
            setModsItems(soundsFMV, @"audio\movies\");
            setModsItems(soundsVoices, @"audio\voices\");

            soundsMusics.Text = soundsMusics.Items[0].ToString();
            soundsAmbients.Text = soundsAmbients.Items[0].ToString();
            soundsSfx.Text = soundsSfx.Items[0].ToString();
            soundsFMV.Text = soundsFMV.Items[0].ToString();
            soundsVoices.Text = soundsVoices.Items[0].ToString();
        }



        //play audio on click in list
        private void soundsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            playAudio(Globals.actualModFolder + soundsList.Items[soundsList.SelectedIndex]);
        }



        //stop playing of a previews audio file then launch the audio file
        static void playAudio(string audioFile)
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
        static void playAudioClose()
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

            string[] extensions = new[] { ".ini", ".psflib", ".bin", ".dll", ".txt", ".xml", ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".toml" };
            DirectoryInfo dInfo = new DirectoryInfo(Folder);

            FileInfo[] files = dInfo.GetFiles().Where(f => !extensions.Contains(f.Extension.ToLower())).ToArray();

            foreach (FileInfo file in files)
            {
                soundsList.Items.Add(file.Name);
            }
        }



        //list audio files when changing audio mod
        private void soundsChange(ComboBox soundCombo, string modFolder)
        {
            string currentModFOlder = getModCustomFolder(soundCombo, modFolder) + @"\files\";

            if (!Directory.Exists(currentModFOlder))
            {
                System.IO.Directory.CreateDirectory(currentModFOlder);
            }

            if (Globals.actualModFolder != currentModFOlder)
            {
                modShowCustom(soundCombo, modFolder, soundsHelp, soundsHelpAuthor, soundPrevPic);
                Globals.actualModFolder = currentModFOlder;
                
                listAudioFiles(Globals.actualModFolder);
            }
            
        }



        //get sound extention(s) of the current audio mod
        private string getSoundExts(string modFolder)
        {
            string soundsExt = "[\"minipsf\",\"ogg\",\"wav\",\"mp3\",\"aac\",\"mp4\",\"flac\"]";

            if (File.Exists(modFolder + @"\exts.ini"))
            {
                if (File.ReadLines(modFolder + @"\exts.ini").Count() > 0)
                {
                    soundsExt = "[";
                    foreach (string line in System.IO.File.ReadLines(modFolder + @"\exts.ini"))
                    {
                        soundsExt = soundsExt + "\"" + line + "\",";
                    }
                    soundsExt = soundsExt.Trim(',');
                    soundsExt = soundsExt + "]";

                    return soundsExt;
                }
            }

            return soundsExt;
        }



        private void soundFrame4_MouseLeave(object sender, EventArgs e){playAudioClose();}   
        private void soundsMusicsChange(object sender, EventArgs e) { soundsChange(soundsMusics, @"audio\musics"); }
        private void soundsAmbiantChange(object sender, EventArgs e) { soundsChange(soundsAmbients, @"audio\ambients"); }
        private void soundsSfxChange(object sender, EventArgs e) { soundsChange(soundsSfx, @"audio\sfxs"); }
        private void soundsFMVChange(object sender, EventArgs e) { soundsChange(soundsFMV, @"audio\movies"); }
        private void soundsVoicesChange(object sender, EventArgs e) { soundsChange(soundsVoices, @"audio\voices"); }

    }
}
