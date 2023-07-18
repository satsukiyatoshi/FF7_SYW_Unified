
using System.Diagnostics;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {

        public static void openUrl(string url)
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }



        public static void openUrlMod()
        {
            if (Globals.actualModUrl != "")
            {
                openUrl(Globals.actualModUrl);
            }
            else
            {
                MessageBox.Show(translate("norulmod", Globals.translateUI));
            }
        }



        private void aboutContributors_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            openUrl(e.LinkText);
        }

    }
}
