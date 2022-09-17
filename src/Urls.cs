using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FF7_SYW_Unified
{
    partial class Form1
    {
        public void openUrl(string url) 
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        //call url for each author
        private void authorUrl1_Click(object sender, EventArgs e) { openUrl("https://ff7.fr/forum/index.php?page=post&ids=445353");}
        private void authorUrl1b_Click(object sender, EventArgs e) { openUrl("https://forums.qhimm.com/index.php?topic=20331.0");}
        private void authorUrl2_Click(object sender, EventArgs e) { openUrl("https://ff7.fr/neo-midgar/");}
        private void donation1_Click(object sender, EventArgs e) { openUrl("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=2L3TQKPJ2V2WU");}
        private void authorUrl3_Click(object sender, EventArgs e) { openUrl("https://ff7.fr/forum/index.php?page=post&ids=378595");}
        private void donation2_Click(object sender, EventArgs e) { openUrl("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=M5RWMESJQ8J5E");}
        private void authorUrl4_Click(object sender, EventArgs e) { openUrl("https://forums.qhimm.com/index.php?topic=20475.0");}
        private void donation4_Click(object sender, EventArgs e) { openUrl("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=77DA5WPWUWHCJ&currency_code=USD&source=url");}
        private void authorUrl5_Click(object sender, EventArgs e) { openUrl("https://forums.qhimm.com/index.php?topic=14541.0");}
        private void donation5_Click(object sender, EventArgs e) { openUrl("https://www.patreon.com/symphonicremasters");}
        private void authorUrl6_Click(object sender, EventArgs e) { openUrl("https://forums.qhimm.com/index.php?topic=19120.0");}
        private void donation6_Click(object sender, EventArgs e) { openUrl("https://www.paypal.com/donate?hosted_button_id=D5H3XR53CZ3WY");}
        private void authoUrl7_Click(object sender, EventArgs e) { openUrl("https://forums.qhimm.com/index.php?topic=20612.0");}
        private void authorUrl8_Click(object sender, EventArgs e) { openUrl("https://forums.qhimm.com/index.php?topic=13960.0");}
        private void authorUrl10_Click(object sender, EventArgs e) { openUrl("https://forums.qhimm.com/index.php?topic=20418.0");}
        private void authorUrl11_Click(object sender, EventArgs e) { openUrl("https://forums.qhimm.com/index.php?topic=16847.0");}
        private void authorUrl11b_Click(object sender, EventArgs e) { openUrl("https://forums.qhimm.com/index.php?topic=16847.0");}
        private void authorUrl13_Click(object sender, EventArgs e) { openUrl("https://www.nexusmods.com/finalfantasy7/mods/4?tab=files");}
        private void donation13_Click(object sender, EventArgs e) { openUrl("https://www.nexusmods.com/Core/Libs/Common/Widgets/DonatePopUp?user=6598180");}
        private void authorUrl16_Click(object sender, EventArgs e) { openUrl("https://forums.qhimm.com/index.php?topic=14938.0");}
        private void donation16_Click(object sender, EventArgs e) { openUrl("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=4NQDGBN7KYLLW");}
        private void authorUrl42_Click(object sender, EventArgs e) { openUrl("https://ff7.fr/forum/index.php?page=forum&idf=40");}
        private void authorUrl42b_Click(object sender, EventArgs e) { openUrl("https://forums.qhimm.com/index.php?topic=20434.0");}
        private void donation42_Click(object sender, EventArgs e) { openUrl("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=satsuki_yatoshi%40hotmail%2ecom&item_name=FF7%20SYW%20%28Merci%29&no_shipping=0&no_note=1&tax=0&currency_code=EUR&lc=FR&bn=PP%2dDonationsBF&charset=UTF%2d8");}
        private void author42urlD_Click(object sender, EventArgs e) { openUrl("https://discord.gg/48V6C9p");}
        private void author42UrlD2_Click(object sender, EventArgs e) { openUrl("https://discord.gg/YaFBdktRjt");}
        private void officialFf7_Click(object sender, EventArgs e) { openUrl("https://finalfantasyviipc.square-enix-games.com/");}
        private void authorUrl12b_Click(object sender, EventArgs e) { openUrl("https://forums.qhimm.com/index.php?topic=19967.0/");}
        private void authorUrl12_Click(object sender, EventArgs e) { openUrl("https://ff7.fr/forum/index.php?page=post&ids=38303");}

    }
}
