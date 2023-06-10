
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
            GeneralHelp.LoadFile(Application.StartupPath + @"\Translations\Help\" + langInterface.Text + @"\" + HelpList.Text + ".rtf", RichTextBoxStreamType.RichText);
            chooseHelp.Visible = false;
        }
    }
}
