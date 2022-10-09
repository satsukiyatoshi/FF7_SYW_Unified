
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
            setModsItems(graphicsModels3Dc, @"models\battles\");
            setModsItems(graphicsModels3Df, @"models\fields\");
            setModsItems(graphicsModels3Dw, @"models\worldmap\");
            setModsItems(graphicsModels3Dm, @"models\minigames\");
            setModsItems(graphicsFMV, @"movies\");
            setModsItems(graphicsMenu, @"uis\");

            graphicsModels3Df.Text = graphicsModels3Df.Items[0].ToString();
            graphicsModels3Dc.Text = graphicsModels3Dc.Items[0].ToString();
            graphicsModels3Dw.Text = graphicsModels3Dw.Items[0].ToString();
            graphicsModels3Dm.Text = graphicsModels3Dm.Items[0].ToString();
            graphicsFMV.Text = graphicsFMV.Items[0].ToString();
            graphicsMenu.Text = graphicsMenu.Items[0].ToString();
        }


        private void graphicsFields_MouseEnter(object sender, EventArgs e) { modShow("graphicsFields", graphicsHelp, graphicsHelpAuthor); }
        private void graphicsAnimations_MouseEnter(object sender, EventArgs e) { modShow("graphicsAnimations", graphicsHelp, graphicsHelpAuthor); }
        private void graphicsBattles_MouseEnter(object sender, EventArgs e) { modShow("graphicsBattles", graphicsHelp, graphicsHelpAuthor); }
        private void graphicsMagics_MouseEnter(object sender, EventArgs e) { modShow("graphicsMagics", graphicsHelp, graphicsHelpAuthor); }
        private void graphicsWorldMap_MouseEnter(object sender, EventArgs e) { modShow("graphicsWorldMap", graphicsHelp, graphicsHelpAuthor); }
        private void graphicsMiniGames_MouseEnter(object sender, EventArgs e) { modShow("graphicsMiniGames", graphicsHelp, graphicsHelpAuthor); }


        private void graphicsModels3DfChange(object sender, EventArgs e) { modShowCustom(graphicsModels3Df, @"models\fields\", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }
        private void graphicsModels3DcChange(object sender, EventArgs e) { modShowCustom(graphicsModels3Dc, @"models\battles\", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }
        private void graphicsModels3DwChange(object sender, EventArgs e) { modShowCustom(graphicsModels3Dw, @"models\worldmap\", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }
        private void graphicsModels3DmChange(object sender, EventArgs e) { modShowCustom(graphicsModels3Dm, @"models\minigames\", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); }
        private void graphicsMenuChange(object sender, EventArgs e) { modShowCustom(graphicsMenu, @"uis\", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); setModFlags(graphicsGroupMenu); }
        private void graphicsFMVChange(object sender, EventArgs e) { modShowCustom(graphicsFMV, @"movies\", graphicsHelp, graphicsHelpAuthor, graphicPrevPic); setModFlags(graphicsGroupFMV); }

    }
}
