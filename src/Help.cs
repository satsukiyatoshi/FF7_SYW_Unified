
using System.Windows.Forms;

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
            /*
            string helpFile = Application.StartupPath + @"\Translations\Help\" + langInterface.Text + @"\" + HelpList.Text + ".rtf";

            try
            {
                GeneralHelp.LoadFile(helpFile, RichTextBoxStreamType.RichText);
                chooseHelp.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(translate("errorFile", Globals.translateUI) + Environment.NewLine + Environment.NewLine + helpFile + Environment.NewLine + Environment.NewLine + ex.Message);
                chooseHelp.Visible = true;
                HelpList.Text = "";
            }
            */

            if(loadRtf(Application.StartupPath + @"\Translations\Help\" + langInterface.Text + @"\" + HelpList.Text + ".rtf", GeneralHelp))
            {
                chooseHelp.Visible = false;
            } else
            {
                chooseHelp.Visible = true;
                HelpList.Text = "";
            }
            
        }

        /*
        private void shortcutsHelp()
        {
            string helpFile = Application.StartupPath + @"\Translations\Shortcuts\" + langInterface.Text + ".rtf";

            try
            {
                specialShortcutHelp.LoadFile(helpFile, RichTextBoxStreamType.RichText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(translate("errorFile", Globals.translateUI) + Environment.NewLine + Environment.NewLine + helpFile + Environment.NewLine + Environment.NewLine + ex.Message);
            }
        }
        */


        private Boolean loadRtf(string rtfFile, RichTextBox richText)
        {
            try
            {
                richText.LoadFile(rtfFile, RichTextBoxStreamType.RichText);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(translate("errorFile", Globals.translateUI) + Environment.NewLine + Environment.NewLine + rtfFile + Environment.NewLine + Environment.NewLine + ex.Message);
                return false;
            }
        }

    }
}
