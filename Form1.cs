using FF7_SYW_Unified.Properties;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.AccessControl;
using static System.Windows.Forms.LinkLabel;

namespace FF7_SYW_Unified
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //get translations list
            string[] translations = Directory.GetFiles(Application.StartupPath + @"\Translations\", "*.lang");
            for (var i = 0; i < translations.Length; i += 1)
            {
                langInterface.Items.Add(Path.GetFileName(translations[i]).Replace(".lang", ""));
            }

            string[] langs = Directory.GetDirectories(Application.StartupPath + @"\Langs\");
            for (var i = 0; i < langs.Length; i += 1)
            {
                langGame.Items.Add(Path.GetFileName(langs[i]).Replace(".lang", ""));
            }

            langInterface.Text = langInterface.GetItemText(langInterface.Items[0]);

            //set default menu status
            menutoogle(1);

        }


        private void launchGame_Click(object sender, EventArgs e)
        {

        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {

        }
    }

  }