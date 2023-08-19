
using System.Diagnostics;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {
        private void controleRestoreKb_Click(object sender, EventArgs e)
        {
            DialogResult resultat = MessageBox.Show(translate("restorekb", Globals.translateUI), "", MessageBoxButtons.YesNo);

            if (resultat == DialogResult.Yes)
            {
                File.Copy(Application.StartupPath + @"Tools\Controls\cl\ff7input.cfg", Application.StartupPath + @"Game\ff7input.cfg", true);
            }

            
        }

        private void controleRestoreNp_Click(object sender, EventArgs e)
        {
            DialogResult resultat = MessageBox.Show(translate("restorenp", Globals.translateUI), "", MessageBoxButtons.YesNo);

            if (resultat == DialogResult.Yes)
            {
                File.Copy(Application.StartupPath + @"Tools\Controls\lap\ff7input.cfg", Application.StartupPath + @"Game\ff7input.cfg", true);
            }
        }

        private void controleRestoreKb_MouseEnter(object sender, EventArgs e) { controleRestoreKb.BackColor = Globals.activButtonBolor; }
        private void controleRestoreKb_MouseLeave(object sender, EventArgs e) { controleRestoreKb.BackColor = Globals.inactivButtonBolor; }
        private void controleRestoreNp_MouseEnter(object sender, EventArgs e) { controleRestoreNp.BackColor = Globals.activButtonBolor; }
        private void controleRestoreNp_MouseLeave(object sender, EventArgs e) { controleRestoreNp.BackColor = Globals.inactivButtonBolor; }
    }
}