
namespace FF7_SYW_Unified
{
    partial class Form1
    {
        //display preview picture and description
        private void modShow(string path, string name)
        {
            graphicPrevPic.ImageLocation = Application.StartupPath + @"Prev\Mods\" + path + @"\" + name + ".jpg";
            graphicsHelp.Text = translate(name, Globals.translateUI);
            graphicsHelpAuthor.Text = translate(name+" author", Globals.translateUI);
        }


        private void graphicsFields_MouseEnter(object sender, EventArgs e) { modShow("SYW","fields"); }
        private void graphicsAnimations_MouseEnter(object sender, EventArgs e) { modShow("SYW", "animations"); }
        private void graphicsBattles_MouseEnter(object sender, EventArgs e) { modShow("SYW", "battles"); }
        private void graphicsMagics_MouseEnter(object sender, EventArgs e) { modShow("SYW", "magics"); }
        private void graphicsWorldMap_MouseEnter(object sender, EventArgs e) { modShow("SYW", "worldmap"); }
        private void graphicsMiniGames_MouseEnter(object sender, EventArgs e) { modShow("SYW", "minigames"); }
        private void graphicsAlphaDialogs_MouseEnter(object sender, EventArgs e) { modShow("SYW", "alphadialogs"); }
        private void graphicsAlphaBattles_MouseEnter(object sender, EventArgs e) { modShow("SYW", "alphabattles"); }

    }
}
