
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

    }
}
