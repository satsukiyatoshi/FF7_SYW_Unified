
using System.Reflection.Metadata.Ecma335;

namespace FF7_SYW_Unified
{
    partial class Form1
    {

        //call translation on lang selection
        private void langInterface_SelectedIndexChanged(object sender, EventArgs e) { translation(langInterface.Text); }


        //menu buttons toogle
        private void menutoogle(int menu)
        {
            Globals.isMenuAbout = false;
            Globals.isMenuGraphic = false;
            Globals.ismenuFFNx = false;
            Globals.ismenuSound = false;
            Globals.ismenuGameplay = false;
            menuAbout.BackColor = Globals.inactivButtonBolor;
            menuGraphic.BackColor = Globals.inactivButtonBolor;
            menuSound.BackColor = Globals.inactivButtonBolor;
            menuGameplay.BackColor = Globals.inactivButtonBolor;
            menuFFNx.BackColor = Globals.inactivButtonBolor;

            if (menu == 1)
            {
                Globals.isMenuAbout = true;
                menuAbout.BackColor = Globals.activButtonBolor;
                showFrame(aboutFrame1);
                showFrame(aboutFrame2);
                showFrame(graphicFrame1, false);
                showFrame(graphicFrame2, false);
            }

            if (menu == 2)
            {
                Globals.isMenuGraphic = true;
                menuGraphic.BackColor = Globals.activButtonBolor;
                showFrame(aboutFrame1,false);
                showFrame(aboutFrame2,false);
                showFrame(graphicFrame1);
                showFrame(graphicFrame2);
            }

            if (menu == 3)
            {
                Globals.ismenuSound = true;
                menuSound.BackColor = Globals.activButtonBolor;
                showFrame(aboutFrame1, false);
                showFrame(aboutFrame2, false);
                showFrame(graphicFrame1, false);
                showFrame(graphicFrame2, false);
            }

            if (menu == 4)
            {
                Globals.ismenuGameplay = true;
                menuGameplay.BackColor = Globals.activButtonBolor;
                showFrame(aboutFrame1, false);
                showFrame(aboutFrame2, false);
                showFrame(graphicFrame1, false);
                showFrame(graphicFrame2, false);
            }

            if (menu == 5)
            {
                Globals.ismenuFFNx = true;
                menuFFNx.BackColor = Globals.activButtonBolor;
                showFrame(aboutFrame1, false);
                showFrame(aboutFrame2, false);
                showFrame(graphicFrame1, false);
                showFrame(graphicFrame2, false);
            }

        }


        private void showFrame (Control c, bool isShow = true)
        {
            if(isShow == false)
            {
                c.Location = new Point(1600, c.Location.Y);
                c.Visible = false;
                return;
            }

            c.Location = new Point(Globals.optionsFramesLeft, c.Location.Y);
            c.Visible = true;

        }


        //textbox "buttons" colors
        private void launchGame_MouseEnter(object sender, EventArgs e) { launchGame.BackColor = Globals.activButtonBolor; }
        private void launchGame_MouseLeave(object sender, EventArgs e) { launchGame.BackColor = Globals.inactivButtonBolor; }

        private void menuAbout_MouseEnter(object sender, EventArgs e) { menuAbout.BackColor = Globals.activButtonBolor; }
        private void menuAbout_MouseLeave(object sender, EventArgs e) { if (Globals.isMenuAbout == false) { menuAbout.BackColor = Globals.inactivButtonBolor; } }
        private void menuGraphic_MouseEnter(object sender, EventArgs e) { menuGraphic.BackColor = Globals.activButtonBolor; }
        private void menuGraphic_MouseLeave(object sender, EventArgs e) { if (Globals.isMenuGraphic == false) { menuGraphic.BackColor = Globals.inactivButtonBolor; } }
        private void menuSound_MouseEnter(object sender, EventArgs e) { menuSound.BackColor = Globals.activButtonBolor; }
        private void menuSound_MouseLeave(object sender, EventArgs e) { if (Globals.ismenuSound == false) { menuSound.BackColor = Globals.inactivButtonBolor; } }
        private void menuGameplay_MouseEnter(object sender, EventArgs e) { menuGameplay.BackColor = Globals.activButtonBolor; }
        private void menuGameplay_MouseLeave(object sender, EventArgs e) { if (Globals.ismenuGameplay == false) { menuGameplay.BackColor = Globals.inactivButtonBolor; } }
        private void menuFFNx_MouseEnter(object sender, EventArgs e) { menuFFNx.BackColor = Globals.activButtonBolor; }
        private void menuFFNx_MouseLeave(object sender, EventArgs e) { if (Globals.ismenuFFNx == false) { menuFFNx.BackColor = Globals.inactivButtonBolor; } }

        private void menuAbout_Click(object sender, EventArgs e) { menutoogle(1); }
        private void menuGraphic_Click(object sender, EventArgs e) { menutoogle(2); }
        private void menuSound_Click(object sender, EventArgs e) { menutoogle(3); }
        private void menuGameplay_Click(object sender, EventArgs e) { menutoogle(4); }
        private void menuFFNx_Click(object sender, EventArgs e) { menutoogle(5); }


    }
}
