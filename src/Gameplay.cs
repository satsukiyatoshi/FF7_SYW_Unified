namespace FF7_SYW_Unified
{
    partial class FF7U
    {
        private void gameplayHelpAuthor_Click(object sender, EventArgs e) { openUrlMod(); }

        private void gameplayClear()
        {
            gameplayMods.Items.Clear();
        }

        private void gameplaySetDefaults()
        {
            setModsItems(gameplayMods, @"gameplay\", "gameplay");
            gameplayMods.Text = gameplayMods.Items[0].ToString();
        }

        private void gameplayModsChange(object sender, EventArgs e)
        {
            modShowCustom(gameplayMods, @"gameplay\", "gameplay", gameplayHelp, gameplayHelpAuthor, gameplayPrevPic);
            setModFlags();
        }

    }

}
