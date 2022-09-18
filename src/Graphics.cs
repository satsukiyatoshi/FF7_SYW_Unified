﻿
namespace FF7_SYW_Unified
{
    partial class Form1
    {
        //display preview and description
        private void modShow(string path, string name)
        {
            getTranslationXml(@"mods\" + path + @"\" + langInterface.Text);
            graphicPrevPic.ImageLocation = Application.StartupPath + @"Prev\Mods\" + path + @"\" + name + ".jpg";
            graphicsHelp.Text = translate(name);
            graphicsHelpAuthor.Text = translate(name+"author");
        }


        private void graphicsFields_MouseEnter(object sender, EventArgs e) { modShow("SYW","fields"); }
    }
}
