

using System;
using static FF7_SYW_Unified.FF7U;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {

        //call translation on menu lang selection
        private void langInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            Globals.formIsLoaded = false;
            Globals.translateUI.Clear();
            Globals.translateMod.Clear();
            graphicsClear();
            soundsClear();
            gameplayClear();
            presetsClear();

            getTranslationXml(Application.StartupPath + @"\Translations\" + langInterface.Text + ".xml", Globals.translateUI);

            string nonePreset = translate("none", Globals.translateUI);
            presetsClear();
            presets.Items.Add(nonePreset);
            presetsLoad();
            presets.Text = presets.Items[Globals.presetNumber].ToString(); 

            translateAll();
            helpList();
            loadRtf(Application.StartupPath + @"\Translations\About\" + langInterface.Text + ".rtf", aboutContributors);
            loadRtf(Application.StartupPath + @"\Translations\Shortcuts\" + langInterface.Text + ".rtf", specialShortcutHelp);

            graphicsSetDefaults();
            soundsSetDefaults();
            gameplaySetDefaults();
            setDefaultFFNxValues();
            Globals.formIsLoaded = true;
        }



        private void presets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Globals.formIsLoaded && presets.SelectedIndex != Globals.presetNumber && presets.SelectedIndex != 0)
            {
                var reponse = MessageBox.Show(translate("presetchange", Globals.translateUI), "FF7_SYW_Unified", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (reponse == DialogResult.Yes)
                {
                    Globals.formIsLoaded = false;
                    File.Copy(Application.StartupPath + @"\Presets\" + langInterface.Text + @"\" + presets.SelectedIndex.ToString("00") + "-" + presets.Text + ".ini", Application.StartupPath + @"\settings.ini", true);
                    graphicsClear();
                    graphicsSetDefaults();
                    graphicsFields.Checked = false;
                    graphicsAnimations.Checked = false;
                    graphicsMiniGames.Checked = false;
                    graphicsBattles.Checked = false;
                    axl3dbattle.Checked = false;
                    graphicsMagics.Checked = false;
                    graphicsWorldMap.Checked = false;
                    FFNxLighting.Checked = false;
                    setDefaultFFNxValues();

                    loadValues(Application.StartupPath + @"\settings.ini");
                    Globals.presetNumber = presets.SelectedIndex;
                    Globals.formIsLoaded = true;
                }
            }
        }



        private void presetsLoad()
        {
            string presetsFolder = (Application.StartupPath + @"\Presets\" + langInterface.Text);
            string[] presetFiles = Directory.GetFiles(presetsFolder, "*.ini");

            foreach (string presetName in presetFiles)
            {
                presets.Items.Add(Path.GetFileName(Path.GetFileNameWithoutExtension(presetName).Substring(3)));
            }
        }



        private void presetsClear()
        {
            presets.Items.Clear();
        }



        /*
         *close audio preview
         *Set menu button color on click
         *Set the matching options pannel visible
         */
        private void menuClick(Control btn)
        {
            playAudioClose();
            soundsList.Items.Clear();

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
                    }
                    else
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
        private void menuHelp_MouseEnter(object sender, EventArgs e) { menuMouseOver(menuHelp); }
        private void menuHelp_MouseLeave(object sender, EventArgs e) { menuMouseOver(menuHelp, false); }
        private void menuControls_MouseEnter(object sender, EventArgs e) { menuMouseOver(menuControls); }
        private void menuControls_MouseLeave(object sender, EventArgs e) { menuMouseOver(menuControls, false); }


        private void menuAbout_Click(object sender, EventArgs e) { menuClick(menuAbout); }
        private void menuGraphic_Click(object sender, EventArgs e) { menuClick(menuGraphic); }
        private void menuSound_Click(object sender, EventArgs e) { menuClick(menuSound); }
        private void menuGameplay_Click(object sender, EventArgs e) { menuClick(menuGameplay); }
        private void menuFFNx_Click(object sender, EventArgs e) { menuClick(menuFFNx); }
        private void menuHelp_Click(object sender, EventArgs e) { menuClick(menuHelp); }
        private void menuControls_Click(object sender, EventArgs e) { menuClick(menuControls); }


        private void menuLaunchGame_MouseEnter(object sender, EventArgs e) { menuLaunchGame.BackColor = Globals.activButtonBolor; }
        private void menuLaunchGame_MouseLeave(object sender, EventArgs e) { menuLaunchGame.BackColor = Globals.inactivButtonBolor; }
    }
}
