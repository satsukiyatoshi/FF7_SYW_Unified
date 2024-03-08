
using System.Windows.Forms;
using System.IO.Compression;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {
        private void helpList()
        {
            HelpList.Items.Clear();
            chooseHelp.Visible = true;

            string folderPath = Application.StartupPath + @"\Translations\Help\" + langInterface.Text;

            string[] rtfFiles = Directory.GetFiles(folderPath, "*.rtf");

            foreach (string rtfFile in rtfFiles)
            {
                string fileName = Path.GetFileName(rtfFile);
                HelpList.Items.Add(fileName.Substring(0, fileName.Length - 4));
            }
        }


        private void HelpList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (loadRtf(Application.StartupPath + @"\Translations\Help\" + langInterface.Text + @"\" + HelpList.Text + ".rtf", GeneralHelp))
            {
                chooseHelp.Visible = false;
            } else
            {
                chooseHelp.Visible = true;
                HelpList.Text = "";
            }
            
        }

        private Boolean loadRtf(string rtfFile, RichTextBox richText)
        {
            try
            {
                richText.LoadFile(rtfFile, RichTextBoxStreamType.RichText);
                richText.SelectionStart = 0;
                richText.ScrollToCaret();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(translate("errorFile", Globals.translateUI) + Environment.NewLine + Environment.NewLine + rtfFile + Environment.NewLine + Environment.NewLine + ex.Message);
                return false;
            }
        }



        private FolderBrowserDialog folderBrowserDialog;

        private void makeDebugPack_Click(object sender, EventArgs e)
        {
            folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string dossierDestination = folderBrowserDialog.SelectedPath;
                string archiveDestination = Path.Combine(dossierDestination, "SYW_Unified_Debug_Pack.zip");

                makeArchiv(archiveDestination, Path.Combine(getModCustomFolder(gameplayMods, @"gameplay\"),"save"), new string[] { Application.StartupPath + @"\settings.ini", Application.StartupPath + @"\lang.ini", Application.StartupPath + @"\game\ffnx.log" });

                MessageBox.Show(translate("dbgArchiv", Globals.translateUI));
            }
        }


        static void makeArchiv(string destinationArchive, string sourceFolder, string[] uniqueFiles)
        {
            using (FileStream fs = new FileStream(destinationArchive, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(fs, ZipArchiveMode.Create))
                {
                    foreach (string fichierUnique in uniqueFiles)
                    {
                        string nomFichier = Path.GetFileName(fichierUnique);
                        archive.CreateEntryFromFile(fichierUnique, nomFichier);
                    }

                    foreach (string fichier in Directory.GetFiles(sourceFolder))
                    {
                        string nomFichier = Path.GetFileName(fichier);
                        archive.CreateEntryFromFile(fichier, Path.Combine("save", nomFichier));
                    }
                }
            }
        }


        private void makeDebugPack_MouseEnter(object sender, EventArgs e) { menuMouseOver(makeDebugPack); }
        private void makeDebugPack_MouseLeave(object sender, EventArgs e) { menuMouseOver(makeDebugPack, false); }

    }
}
