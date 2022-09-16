
using System.Reflection.Metadata.Ecma335;
using static System.Windows.Forms.LinkLabel;

namespace FF7_SYW_Unified
{
    partial class Form1
    {

        //call translation on lang selection
        private void langInterface_SelectedIndexChanged(object sender, EventArgs e) { translation(langInterface.Text); }

        private void menuClick(Control btn)
        {
            btn.BackColor = Globals.activButtonBolor;
            Globals.activMenuName = btn.Name;

            foreach (Control c in settingsGroup.Controls)
            {
                if(c.Name != Globals.activMenuName) {c.BackColor = Globals.inactivButtonBolor; }
            }
        }

        private void menuMouseOver(Control menuBtn, bool isActiv = true)
        {
            if (Globals.activMenuName != menuBtn.Name && isActiv == false)
            {
                menuBtn.BackColor = Globals.inactivButtonBolor;
                return;
            }
            menuBtn.BackColor = Globals.activButtonBolor;
        }


        /*menu buttons toogle
        private void menutoogle(int menu)
        {
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
        */


        private void menuAbout_MouseEnter(object sender, EventArgs e) { menuMouseOver(menuAbout); }
        private void menuAbout_MouseLeave(object sender, EventArgs e) { menuMouseOver(menuAbout, false); }
        private void menuGraphic_MouseEnter(object sender, EventArgs e) { menuMouseOver(menuGraphic); }
        private void menuGraphic_MouseLeave(object sender, EventArgs e) { menuMouseOver(menuGraphic, false); }
        private void menuSound_MouseEnter(object sender, EventArgs e) { menuMouseOver(menuSound); }
        private void menuSound_MouseLeave(object sender, EventArgs e) { menuMouseOver(menuSound, false); }
        private void menuGameplay_MouseEnter(object sender, EventArgs e) { menuMouseOver(menuGameplay); ; }
        private void menuGameplay_MouseLeave(object sender, EventArgs e) { menuMouseOver(menuGameplay, false); }
        private void menuFFNx_MouseEnter(object sender, EventArgs e) { menuMouseOver(menuFFNx); }
        private void menuFFNx_MouseLeave(object sender, EventArgs e) { menuMouseOver(menuFFNx, false); }

        private void menuAbout_Click(object sender, EventArgs e) { menuClick(menuAbout); }
        private void menuGraphic_Click(object sender, EventArgs e) { menuClick(menuGraphic); }
        private void menuSound_Click(object sender, EventArgs e) { menuClick(menuSound); }
        private void menuGameplay_Click(object sender, EventArgs e) { menuClick(menuGameplay); }
        private void menuFFNx_Click(object sender, EventArgs e) { menuClick(menuFFNx); }

        private void launchGame_MouseEnter(object sender, EventArgs e) { launchGame.BackColor = Globals.activButtonBolor; }
        private void launchGame_MouseLeave(object sender, EventArgs e) { launchGame.BackColor = Globals.inactivButtonBolor; }
    }
}
