
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
            graphicsFMV.Items.Clear();
            graphicsMenu.Items.Clear();
        }


        private void graphicsSetDefaults()
        {
            setModsItems(graphicsModels3Dc, @"models\battles\", "models.battles");
            setModsItems(graphicsModels3Df, @"models\fields\", "models.fields");
            setModsItems(graphicsModels3Dw, @"models\worldmap\", "models.worldmap");
            setModsItems(graphicsModels3Dm, @"models\minigames\", "models.minigames");
            setModsItems(graphicsFMV, @"movies\", "movies");
            setModsItems(graphicsMenu, @"uis\", "uis");

            graphicsModels3Df.Text = graphicsModels3Df.Items[0].ToString();
            graphicsModels3Dc.Text = graphicsModels3Dc.Items[0].ToString();
            graphicsModels3Dw.Text = graphicsModels3Dw.Items[0].ToString();
            graphicsModels3Dm.Text = graphicsModels3Dm.Items[0].ToString();
            graphicsFMV.Text = graphicsFMV.Items[0].ToString();
            graphicsMenu.Text = graphicsMenu.Items[0].ToString();
        }


        private void graphicsFields_MouseEnter(object sender, EventArgs e) { modShow("SYW","fields"); }
        private void graphicsAnimations_MouseEnter(object sender, EventArgs e) { modShow("SYW", "animations"); }
        private void graphicsBattles_MouseEnter(object sender, EventArgs e) { modShow("SYW", "battles"); }
        private void graphicsMagics_MouseEnter(object sender, EventArgs e) { modShow("SYW", "magics"); }
        private void graphicsWorldMap_MouseEnter(object sender, EventArgs e) { modShow("SYW", "worldmap"); }
        private void graphicsMiniGames_MouseEnter(object sender, EventArgs e) { modShow("SYW", "minigames"); }
       //private void graphicsAlphaDialogs_MouseEnter(object sender, EventArgs e) { modShow("SYW", "alphadialogs"); }
       //private void graphicsAlphaBattles_MouseEnter(object sender, EventArgs e) { modShow("SYW", "alphabattles"); }
       //private void graphicsLighting_MouseEnter(object sender, EventArgs e) { modShow("SYW", "lighting"); }


        private void graphicsModels3DfChange(object sender, EventArgs e) { modShowCustom(graphicsModels3Df, @"models\fields\", "models.fields", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }
        private void graphicsModels3DcChange(object sender, EventArgs e) { modShowCustom(graphicsModels3Dc, @"models\battles\", "models.battles", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }
        private void graphicsModels3DwChange(object sender, EventArgs e) { modShowCustom(graphicsModels3Dw, @"models\worldmap\", "models.worldmap", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }
        private void graphicsModels3DmChange(object sender, EventArgs e) { modShowCustom(graphicsModels3Dm, @"models\minigames\", "models.minigames", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }
        private void graphicsMenuChange(object sender, EventArgs e) { modShowCustom(graphicsMenu, @"uis\", "uis", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }
        private void graphicsFMVChange(object sender, EventArgs e) { modShowCustom(graphicsFMV, @"movies\", "movies", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }

    }
}
