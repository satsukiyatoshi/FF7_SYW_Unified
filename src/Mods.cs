using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System;
using System.IO;
using System.Collections.Generic;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {

        //set items of combos mods option and put their translation to Globals.translateMod
        private void setModsItems(ComboBox combo, string folderwSource)
        {
            string translationFile = "";
            string modDir = "";

            folderwSource = Application.StartupPath + @"mods\" + folderwSource;

            string[] dirs = Directory.GetDirectories(folderwSource, "*", SearchOption.TopDirectoryOnly);

            foreach (string dir in dirs)
            {
                if (File.Exists(dir + @"\translations\" + langInterface.Text + ".xml"))
                {
                    translationFile = dir + @"\translations\" + langInterface.Text + ".xml";
                }
                else if (File.Exists(dir + @"\translations\english.xml"))
                {
                    translationFile = dir + @"\translations\english.xml";
                }
                else
                {
                    string[] translations = Directory.GetFiles(dir + @"\Translations\", "*.xml");
                    if (translations.Length > 0)
                    {
                        translationFile = dir + @"\Translations\" + Path.GetFileName(translations[0]);
                    } else
                    {
                        MessageBox.Show(translate("errorloadingmod", Globals.translateUI) + dir);
                        Process.GetCurrentProcess().Kill();
                    }
                }

                modDir = Path.GetFileName(dir);

                getTranslationXml(translationFile, Globals.translateMod, combo.Name + "." + modDir);
                combo.Items.Add(translate(combo.Name + "." + modDir, Globals.translateMod));

            }

        }



        //display preview picture and description for SYW mods and FFNx options
        private void modShow(string name, TextBox help, Label author, Boolean showPrev = true)
        {
            if (showPrev)
            {
                graphicPrevPic.ImageLocation = Application.StartupPath + @"Mods\SYW\Prev\" + name + ".jpg";
            }

            help.Text = translate(name + "help", Globals.translateUI).ReplaceLineEndings();
            author.Text = translate(name + "author", Globals.translateUI);
            Globals.actualModUrl = translate(name + "url", Globals.translateUI);

            scrollHelper(help);
        }



        //display preview picture and description for combobox custom mods
        private void modShowCustom(ComboBox combo, string folderwSource, TextBox help, Label authorLabel, PictureBox prevPic = null)
        {
            string folderMod = "";
            string modDir = "";

            //TODO check if possible to use setMousePos ?//
            if (Globals.mouseY != 0)
            {
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X, Globals.mouseY);
                Globals.mouseY = 0;
            }

            folderMod = getModCustomFolder(combo, folderwSource);

            if (prevPic != null) { prevPic.ImageLocation = folderMod + @"\prev.jpg"; }

            modDir = Path.GetFileName(folderMod);

            help.Text = translate(combo.Name + "." + modDir + "help", Globals.translateMod).ReplaceLineEndings();
            authorLabel.Text = translate(combo.Name + "." + modDir + "author", Globals.translateMod);
            Globals.actualModUrl = translate(combo.Name + "." + modDir + "url", Globals.translateMod);
            Globals.actualModFlags = translate(combo.Name + "." + modDir + "compatibily", Globals.translateMod);

            scrollHelper(help);
        }



        //get selected mod folder
        static string getModCustomFolder(ComboBox combo, string folderwSource)
        {
            try
            {
                folderwSource = Application.StartupPath + @"mods\" + folderwSource;
                string[] dirs = Directory.GetDirectories(folderwSource, "*", SearchOption.TopDirectoryOnly);
                return dirs[combo.SelectedIndex];
            }

            catch
            {
                MessageBox.Show(translate("errorloadingmod", Globals.translateUI) + folderwSource);
                Process.GetCurrentProcess().Kill();
                return "";
            }
        }



        //set flag depending mod compatibility
        static void setModFlags(Control modgroup)
        {
            string flagFsource = Globals.actualModFlags.ToLower().Contains("f") ? Application.StartupPath + @"\Ressources\french.png" : Application.StartupPath + @"\Ressources\french-off.png";
            string flagEsource = Globals.actualModFlags.ToLower().Contains("e") ? Application.StartupPath + @"\Ressources\english.png" : Application.StartupPath + @"\Ressources\english-off.png";
            string flagGsource = Globals.actualModFlags.ToLower().Contains("g") ? Application.StartupPath + @"\Ressources\german.png" : Application.StartupPath + @"\Ressources\german-off.png";
            string flagSsource = Globals.actualModFlags.ToLower().Contains("s") ? Application.StartupPath + @"\Ressources\spain.png" : Application.StartupPath + @"\Ressources\spain-off.png";

            foreach (PictureBox pict in modgroup.Controls.OfType<PictureBox>())
            {
                if (pict.Name.Contains("flagF")) { pict.ImageLocation = flagFsource; }
                if (pict.Name.Contains("flagE")) { pict.ImageLocation = flagEsource; }
                if (pict.Name.Contains("flagG")) { pict.ImageLocation = flagGsource; }
                if (pict.Name.Contains("flagS")) { pict.ImageLocation = flagSsource; }
            }

        }



        //copy mod folder content to current mod folder recusively and overwrite
        public void folderModCopy(string modFolder)
        {
            string current_mod_folder = "";

            if (!(modFolder.Length - 1).Equals(@"\"))
            {
                modFolder = modFolder + @"\";
            }

            if (File.Exists(modFolder + @"Trainers\Config.xml"))
            {
                Globals.isTrainer = true;

                using (StreamWriter writer = new StreamWriter(Application.StartupPath + @"\Mods\SYW\Trainer\config.xml", true))
                {

                    string xmlContent = File.ReadAllText(modFolder + @"Trainers\Config.xml");

                    if (xmlContent.Contains("<action_condition>use_files</action_condition>"))
                    {
                        int index = xmlContent.IndexOf("<action_condition>use_files</action_condition>") +
                                    "<action_condition>use_files</action_condition>".Length;

                        xmlContent = xmlContent.Insert(index, "<action_condition_folder>"+ modFolder + @"Trainers" + "</action_condition_folder>");
                    }

                    if (xmlContent.Contains("<action_condition>change_value</action_condition>"))
                    {
                        int index = xmlContent.IndexOf("<action_condition>change_value</action_condition>") +
                                    "<action_condition>change_value</action_condition>".Length;

                        xmlContent = xmlContent.Insert(index, "<action_condition_folder></action_condition_folder>");
                    }

                    writer.WriteLine(xmlContent);
                }
            }

            if (Directory.Exists(modFolder + @"Files"))
            {
                folderCopyAll(new DirectoryInfo(modFolder + @"Files"), new DirectoryInfo(Application.StartupPath + @"\Game\current"));
            }

            //if language specific mod files exists then copy then overwriting default mod files
            //Globals.gameLang
            if (Directory.Exists(modFolder + @"FilesLang\" + Globals.gameLang))
            {
                folderCopyAll(new DirectoryInfo(modFolder + @"FilesLang\" + Globals.gameLang), new DirectoryInfo(Application.StartupPath + @"\Game\current"));
            }

            //if 30fps mod is activated then copy 30 fps file of the mod too
            if (FFNxFps.SelectedIndex == 1 && Directory.Exists(modFolder + @"Files30fps"))
            {
                folderCopyAll(new DirectoryInfo(modFolder + @"Files30fps"), new DirectoryInfo(Application.StartupPath + @"\Game\current"));
            }

            //if 30fps mod is activated and specific langauge file exists then copy localised 30 fps file of the mod too
            if (FFNxFps.SelectedIndex == 1 && Directory.Exists(modFolder + @"FilesLang30fps\" + Globals.gameLang))
            {
                folderCopyAll(new DirectoryInfo(modFolder + @"FilesLang30fps\" + Globals.gameLang), new DirectoryInfo(Application.StartupPath + @"\Game\current"));
            }

            //if 60fps mod is activated then copy 60 fps file of the mod too
            if (FFNxFps.SelectedIndex == 2 && Directory.Exists(modFolder + @"Files60fps"))
            {
                folderCopyAll(new DirectoryInfo(modFolder + @"Files60fps"), new DirectoryInfo(Application.StartupPath + @"\Game\current"));
            }

            //if 60fps mod is activated and specific langauge file exists then copy localised 60 fps file of the mod too
            if (FFNxFps.SelectedIndex == 2 && Directory.Exists(modFolder + @"FilesLang60fps\" + Globals.gameLang))
            {
                folderCopyAll(new DirectoryInfo(modFolder + @"FilesLang60fps\" + Globals.gameLang), new DirectoryInfo(Application.StartupPath + @"\Game\current"));
            }

            //apply ratio specific files
            if (Directory.Exists(modFolder + @"FilesWS\43") && FFNxRatio.SelectedIndex == 0)
            {
                folderCopyAll(new DirectoryInfo(modFolder + @"FilesWS\43"), new DirectoryInfo(Application.StartupPath + @"\Game\current"));
            }

            if (Directory.Exists(modFolder + @"FilesWS\169st") && FFNxRatio.SelectedIndex == 1)
            {
                folderCopyAll(new DirectoryInfo(modFolder + @"FilesWS\169st"), new DirectoryInfo(Application.StartupPath + @"\Game\current"));
            }

            if (Directory.Exists(modFolder + @"FilesWS\169") && FFNxRatio.SelectedIndex == 2)
            {
                folderCopyAll(new DirectoryInfo(modFolder + @"FilesWS\169"), new DirectoryInfo(Application.StartupPath + @"\Game\current"));
            }

            if (Directory.Exists(modFolder + @"FilesWS\1610") && FFNxRatio.SelectedIndex == 3)
            {
                folderCopyAll(new DirectoryInfo(modFolder + @"FilesWS\1610"), new DirectoryInfo(Application.StartupPath + @"\Game\current"));
            }

            //replace ff7.exe with the gameplay's ff7 mod (used with vanilla exe option too)
            if (File.Exists(Application.StartupPath + @"Game\current\ff7.exe"))
            {
                File.Copy(Application.StartupPath + @"Game\current\ff7.exe", Application.StartupPath + @"Game\ff7.exe", true);
            }

            current_mod_folder = Path.GetFileName(modFolder.Remove(modFolder.Length - 1));
            if (!current_mod_folder.Contains("Vanilla") && current_mod_folder != "")
            {
                Globals.modApplied.Add(Path.GetFileName(current_mod_folder));
            }
            
        }


        //restore all dds files and delete the currently used mods file
        private void restoreFiles()
        {
            loadingLog(translate("restoreFiles", Globals.translateUI));

            List<string> disabledFiles = Directory.GetFiles(Application.StartupPath + @"mods\SYW\Textures", "*.SYWT", SearchOption.AllDirectories).ToList();
            List<string> disabledFolders = Directory.GetDirectories(Application.StartupPath + @"mods\SYW\Textures", "*SYWF", SearchOption.AllDirectories).ToList();
            List<string> currentFiles = Directory.GetFiles(Application.StartupPath + @"Game\current", "*", SearchOption.AllDirectories).ToList();

            foreach (string fichier in Directory.GetFiles(Application.StartupPath + @"Game\data\movies"))
            {
                //remove files from movies game folder - to deal with external audio fmv file witch MUST be in OG folder, no possible overide
                if (Path.GetExtension(fichier) != ".avi" && Path.GetExtension(fichier) != ".lgp")
                {
                    File.Delete(fichier);
                }
            }

            foreach (string file in disabledFiles)
            {
                File.Move(file, Path.ChangeExtension(file, ".dds"));
                Application.DoEvents();
            }

            foreach (string folder in disabledFolders)
            {
                Directory.Move(folder, folder.Remove(folder.Length - 4));
                Application.DoEvents();
            }

            foreach (string file in currentFiles)
            {
                File.Delete(file);
            }

            if (Directory.Exists(Application.StartupPath + @"Game\widescreen"))
            {
                Directory.Move(Application.StartupPath + @"Game\widescreen", Application.StartupPath + @"Game\widescreen_u");
            }

            if (Directory.Exists(Application.StartupPath + @"Mods\SYW\Textures\field_origin"))
            {
                Directory.Move(Application.StartupPath + @"Mods\SYW\Textures\field", Application.StartupPath + @"Mods\SYW\Textures\field_limitb");
                Directory.Move(Application.StartupPath + @"Mods\SYW\Textures\field_origin", Application.StartupPath + @"Mods\SYW\Textures\field");
            }
        }



        //disable texture file by renaming them to SYWT extention
        private void disableFiles(string textureFolder, Boolean subfolder = false)
        {
            List<string> files = Directory.GetFiles(Application.StartupPath + textureFolder, "*.dds", subfolder ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).ToList();

            foreach (string file in files)
            {
                File.Move(file, Path.ChangeExtension(file, ".SYWT"));
                Application.DoEvents();
            }
        }



        //disable folder by renaming it to SYWF extention
        private void disableFolder(string folder)
        {
            Directory.Move(folder, folder + ".SYWF");
        }



        private void loadingLog(string modDescription)
        {
            translateCtrl(loadingWaitDetails);
            loadingWaitDetails.Text = loadingWaitDetails.Text + " : " + modDescription;
            Application.DoEvents();
        }



        //apply SYW specific language textures 
        private void applySywLangTextures(string texFolder)
        {
            string sourceFolderd = Application.StartupPath + @"Mods\SYW\FilesLang\" + Globals.gameLang + @"\" + texFolder;

            if (Directory.Exists(sourceFolderd))
            {
               folderCopyAll(new DirectoryInfo(sourceFolderd), new DirectoryInfo(Application.StartupPath + @"\Mods\SYW\Textures\" + texFolder));
            }
        }



        //disable SYW textures depending choosen options
        private void applySywTextures()
        {

            loadingLog(graphicsFields.Text);
            if (!graphicsFields.Checked)
            {
                disableFolder(@"mods\SYW\Textures\char");
                disableFolder(@"mods\SYW\Textures\field");
                disableFolder(@"mods\SYW\Textures\flevel");
            } else
            {
                applySywLangTextures("char");
                applySywLangTextures("field");
                applySywLangTextures("flevel");
            }

            loadingLog(graphicsBattles.Text);
            if (!graphicsBattles.Checked)
            {
                disableFolder(@"mods\SYW\Textures\battle");
            }
            else
            {
                applySywLangTextures("battle");
            }

            loadingLog(graphicsMagics.Text);
            if (!graphicsMagics.Checked)
            {
                disableFolder(@"mods\SYW\Textures\magic");
                disableFiles(@"mods\SYW\Textures");
            }
            else
            {
                applySywLangTextures("magic");
            }

            loadingLog(graphicsWorldMap.Text);
            if (!graphicsWorldMap.Checked)
            {
                disableFolder(@"mods\SYW\Textures\world");
            }
            else
            {
                applySywLangTextures("world");
            }

            loadingLog(graphicsMiniGames.Text);
            if (!graphicsMiniGames.Checked)
            {
                disableFolder(@"mods\SYW\Textures\Chocobo");
                disableFolder(@"mods\SYW\Textures\coaster");
                disableFolder(@"mods\SYW\Textures\condor");
                disableFolder(@"mods\SYW\Textures\high");
                disableFolder(@"mods\SYW\Textures\snowboard");
                disableFolder(@"mods\SYW\Textures\sub");
            }
            else
            {
                applySywLangTextures("Chocobo");
                applySywLangTextures("coaster");
                applySywLangTextures("condor");
                applySywLangTextures("high");
                applySywLangTextures("snowboard");
                applySywLangTextures("sub");
            }

            //disable some texture files if no animation used to avoid bug in certains fields
            loadingLog(graphicsAnimations.Text);
            if (!graphicsAnimations.Checked && graphicsFields.Checked)
            {
                string file = "";

                var lines = File.ReadLines(Application.StartupPath + @"\Mods\SYW\disable.for.animation");
                foreach (var line in lines)
                {
                    file = Application.StartupPath + @"\Mods\SYW\Textures\field\" + line;
                    File.Move(file, Path.ChangeExtension(file, ".SYWT"));
                }
            }

            if (axl3dbattle.Checked)
            {
                loadingLog(axl3dbattle.Text);
                folderModCopy(Application.StartupPath + @"Mods\SYW\3DBattleBackgroundAxl\");
            }
        }



        //apply current mods of a groupbox's comboboxs
        private void applyMods()
        {
            loadingLog(graphicsModels3Df.Text);
            folderModCopy(getModCustomFolder(graphicsModels3Df, @"models\fields\"));

            loadingLog(graphicsModels3Dc.Text);
            folderModCopy(getModCustomFolder(graphicsModels3Dc, @"models\battles\"));

            loadingLog(graphicsModels3Dw.Text);
            folderModCopy(getModCustomFolder(graphicsModels3Dw, @"models\worldmap\"));

            loadingLog(graphicsModels3Dm.Text);
            folderModCopy(getModCustomFolder(graphicsModels3Dm, @"models\minigames\"));

            loadingLog(graphicsMenu.Text);
            folderModCopy(getModCustomFolder(graphicsMenu, @"uis\"));

            loadingLog(graphicsFMV.Text);
            folderModCopy(getModCustomFolder(graphicsFMV, @"movies\"));

            loadingLog(gameplayMods.Text);
            folderModCopy(getModCustomFolder(gameplayMods, @"gameplay\"));

            loadingLog(graphicsAddTextures.Text);
            folderModCopy(getModCustomFolder(graphicsAddTextures, @"textures\"));

            loadingLog(soundsFMV.Text);
            CopyUniqueFiles(getModCustomFolder(soundsFMV, @"audio\movies") + @"\Files\data\movies", Application.StartupPath + @"\game\data\movies", Application.StartupPath + @"\game\current\Data\movies");

            loadingLog(soundsAmbients.Text);
            folderModCopy(getModCustomFolder(soundsAmbients, @"audio\ambiants"));

            loadingLog(soundsMusics.Text);
            folderModCopy(getModCustomFolder(soundsMusics, @"audio\musics"));

            loadingLog(soundsSfx.Text);
            folderModCopy(getModCustomFolder(soundsSfx, @"audio\sfxs"));

            loadingLog(soundsVoices.Text);
            folderModCopy(getModCustomFolder(soundsVoices, @"audio\voices"));
        }


        private void CopyUniqueFiles(string sourceDirectory, string moviesDirectory, string overideDirectory)
        {
            //specific function for fmv music's mod, if file is unique, then copy it to one folder (data\movies) if 2 files with the same name then it's movie + audio then copy them to the overide folder

            if (Directory.Exists(sourceDirectory) && Directory.Exists(moviesDirectory) && Directory.Exists(overideDirectory))
            {
                Dictionary<string, List<string>> fileDictionary = new Dictionary<string, List<string>>();

                foreach (string filePath in Directory.GetFiles(sourceDirectory))
                {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    string fileExtension = Path.GetExtension(filePath);

                    if (!fileDictionary.ContainsKey(fileName))
                    {
                        fileDictionary[fileName] = new List<string>();
                    }

                    fileDictionary[fileName].Add(filePath);
                }

                foreach (var pair in fileDictionary)
                {
                    if (pair.Value.Count == 1)
                    {
                        string destinationFilePath = Path.Combine(moviesDirectory, Path.GetFileName(pair.Value[0]));
                        File.Copy(pair.Value[0], destinationFilePath, true);
                    }

                    else
                    {
                        foreach (string filePath in pair.Value)
                        {
                            string destinationFilePath = Path.Combine(overideDirectory, Path.GetFileName(filePath));
                            File.Copy(filePath, destinationFilePath, true);
                        }
                    }
                }
            }
        }

    }
}