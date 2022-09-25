

using System;
using static FF7_SYW_Unified.FF7U;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {

        //call translation on menu lang selection
        private void langInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            Globals.translateUI.Clear();
            Globals.translateMod.Clear();
            graphicsModels3Df.Items.Clear();
            graphicsModels3Dc.Items.Clear();
            graphicsFMV.Items.Clear();
            graphicsMenu.Items.Clear();


            getTranslationXml(Application.StartupPath + @"\Translations\" + langInterface.Text + ".xml", Globals.translateUI);
            translateAll();

            setModsItems(graphicsModels3Dc, @"models\battle\", "models.battle");
            setModsItems(graphicsModels3Df, @"models\fields\", "models.fields");
            setModsItems(graphicsFMV, @"movies\", "movies");
            setModsItems(graphicsMenu, @"uis\", "uis");

            graphicsModels3Df.Text = graphicsModels3Df.Items[0].ToString();
            graphicsModels3Dc.Text = graphicsModels3Dc.Items[0].ToString();
            graphicsFMV.Text = graphicsFMV.Items[0].ToString();
            graphicsMenu.Text = graphicsMenu.Items[0].ToString();
        }



        /*
         *Set menu button color on click
         *Set the matching options pannel visible
         */
        private void menuClick(Control btn)
        {
            btn.BackColor = Globals.activButtonBolor;
            Globals.activMenuName = btn.Name;

            foreach (Control c in settingsGroup.Controls)
            {
                if(c.Name != Globals.activMenuName) {c.BackColor = Globals.inactivButtonBolor; }
            }

            foreach (Control cpanel in Controls)
            {
                if (cpanel is Panel)
                {
                    if (cpanel.Name.Contains(btn.Name)) {
                        cpanel.Location = new Point(327, 0);
                        cpanel.Visible = true;

                    } else
                    {
                        cpanel.Location = new Point(1600, 0);
                        cpanel.Visible = false;
                    }
                }
            }
        }



        //Change menu button color on mouse over
        private static void menuMouseOver(Control menuBtn, bool isActiv = true)
        {
            if (Globals.activMenuName != menuBtn.Name && !isActiv)
            {
                menuBtn.BackColor = Globals.inactivButtonBolor;
                return;
            }
            menuBtn.BackColor = Globals.activButtonBolor;
        }



        //menu buttons toogle call on mouve enter/leave
        private void menuAbout_MouseEnter(object sender, EventArgs e) { menuMouseOver(menuAbout); }
        private void menuAbout_MouseLeave(object sender, EventArgs e) { menuMouseOver(menuAbout, false); }
        private void menuGraphic_MouseEnter(object sender, EventArgs e) { menuMouseOver(menuGraphic); }
        private void menuGraphic_MouseLeave(object sender, EventArgs e) { menuMouseOver(menuGraphic, false); }
        private void menuSound_MouseEnter(object sender, EventArgs e) { menuMouseOver(menuSound); }
        private void menuSound_MouseLeave(object sender, EventArgs e) { menuMouseOver(menuSound, false); }
        private void menuGameplay_MouseEnter(object sender, EventArgs e) { menuMouseOver(menuGameplay); }
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
