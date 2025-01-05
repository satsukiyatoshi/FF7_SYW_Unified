
namespace FF7_SYW_Unified
{
    partial class FF7U
    {
        private void graphicsHelpAuthor_Click(object sender, EventArgs e) { openUrlMod(); }



        private void graphicsClear()
        {
            graphicsModels3Df.Items.Clear();
            graphicsModels3Dc.Items.Clear();
            graphicsModels3Dw.Items.Clear();
            graphicsModels3Dm.Items.Clear();
            graphicsAddTextures.Items.Clear();
            graphicsFMV.Items.Clear();
            graphicsMenu.Items.Clear();
        }



        private void graphicsSetDefaults()
        {
            setModsItems(graphicsModels3Dc, @"models\battles\");
            setModsItems(graphicsModels3Df, @"models\fields\");
            setModsItems(graphicsModels3Dw, @"models\worldmap\");
            setModsItems(graphicsModels3Dm, @"models\minigames\");
            setModsItems(graphicsFMV, @"movies\");
            setModsItems(graphicsMenu, @"uis\");
            setModsItems(graphicsAddTextures, @"textures\");

            graphicsModels3Df.Text = graphicsModels3Df.Items[0].ToString();
            graphicsModels3Dc.Text = graphicsModels3Dc.Items[0].ToString();
            graphicsModels3Dw.Text = graphicsModels3Dw.Items[0].ToString();
            graphicsModels3Dm.Text = graphicsModels3Dm.Items[0].ToString();
            graphicsFMV.Text = graphicsFMV.Items[0].ToString();
            graphicsMenu.Text = graphicsMenu.Items[1].ToString();
            graphicsAddTextures.Text = graphicsAddTextures.Items[0].ToString();
        }



        private void graphicsFields_CheckedChanged(object sender, EventArgs e)
        {
            if (Globals.formSettingsLoaded == true)
            {
                if (graphicsFields.Checked == false && graphicsLb.Checked == false)
                {
                    graphicsAnimations.Checked = false;
                }

                if (graphicsFields.Checked == true && graphicsLb.Checked == true)
                {
                    graphicsLb.Checked = false;
                }
            }
        }



        private void graphicsAnimations_CheckedChanged(object sender, EventArgs e)
        {
            if (Globals.formSettingsLoaded == true)
            {
                if (graphicsFields.Checked == false && graphicsLb.Checked == false)
                {
                    graphicsAnimations.Checked = false;
                }
            }
        }



        private void graphicsLb_CheckedChanged(object sender, EventArgs e)
        {
            if (Globals.formSettingsLoaded == true)
            {
                if (graphicsFields.Checked == false && graphicsLb.Checked == false)
                {
                    graphicsAnimations.Checked = false;
                }

                if (graphicsFields.Checked == true && graphicsLb.Checked == true)
                {
                    graphicsFields.Checked = false;
                }

                if (graphicsLb.Checked == false && (FFNxRatio.SelectedIndex == 2 || FFNxRatio.SelectedIndex == 3))
                {
                    FFNxRatio.SelectedIndex = 0;
                }
            }
        }


        private void graphicsCosmosGaia_CheckedChanged(object sender, EventArgs e)
        {
            if (Globals.formSettingsLoaded == true)
            {
                if (FFNxAnalogController.Checked == false)
                {
                    graphicsCosmosGaia.Checked = false;
                }
            }
        }



        private void graphicsFields_MouseEnter(object sender, EventArgs e) { modShow("graphicsFields", graphicsHelp, graphicsHelpAuthor); }
        private void graphicsAnimations_MouseEnter(object sender, EventArgs e) { modShow("graphicsAnimations", graphicsHelp, graphicsHelpAuthor); }
        private void graphicsLb_MouseEnter(object sender, EventArgs e) { modShow("graphicsLb", graphicsHelp, graphicsHelpAuthor); }
        private void graphicsBattles_MouseEnter(object sender, EventArgs e) { modShow("graphicsBattles", graphicsHelp, graphicsHelpAuthor); }
        private void graphicsMagics_MouseEnter(object sender, EventArgs e) { modShow("graphicsMagics", graphicsHelp, graphicsHelpAuthor); }
        private void graphicsWorldMap_MouseEnter(object sender, EventArgs e) { modShow("graphicsWorldMap", graphicsHelp, graphicsHelpAuthor); }
        private void graphicsMiniGames_MouseEnter(object sender, EventArgs e) { modShow("graphicsMiniGames", graphicsHelp, graphicsHelpAuthor); }
        private void graphicsModels3DfChange(object sender, EventArgs e) { modShowCustom(graphicsModels3Df, @"models\fields\", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }
        private void graphicsModels3DcChange(object sender, EventArgs e) { modShowCustom(graphicsModels3Dc, @"models\battles\", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }
        private void graphicsModels3DwChange(object sender, EventArgs e) { modShowCustom(graphicsModels3Dw, @"models\worldmap\", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }
        private void graphicsModels3DmChange(object sender, EventArgs e) { modShowCustom(graphicsModels3Dm, @"models\minigames\", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }
        private void graphicsMenuChange(object sender, EventArgs e) { modShowCustom(graphicsMenu, @"uis\", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); setModFlags(graphicsGroupMenu); }
        private void graphicsFMVChange(object sender, EventArgs e) { modShowCustom(graphicsFMV, @"movies\", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }
        private void graphicsAddTexturesChange(object sender, EventArgs e) { modShowCustom(graphicsAddTextures, @"textures\", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }
        private void FFNxLighting_MouseEnter(object sender, EventArgs e) { modShow("FFNxLighting", graphicsHelp, graphicsHelpAuthor); }
        private void axl3dbattle_MouseEnter(object sender, EventArgs e) { modShow("axl3dbattle", graphicsHelp, graphicsHelpAuthor); }

        private void graphicsCosmosGaia_MouseEnter(object sender, EventArgs e) { modShow("graphicsCosmosGaia", graphicsHelp, graphicsHelpAuthor); }

    }
}
