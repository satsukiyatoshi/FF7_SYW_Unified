
using System.Diagnostics;
using System.Xml;
using static System.Windows.Forms.LinkLabel;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {

        //set items of combos mods option and put their translation to Globals.translateMod
        private void setModsItems(ComboBox combo, string folderwSource)
        {
            string translationFile = "";
            string modDir = "";

            folderwSource = Application.StartupPath + @"mods\" + folderwSource;

                string[] dirs = Directory.GetDirectories(folderwSource, "*", SearchOption.TopDirectoryOnly);

                foreach (string dir in dirs)
                {
                    if (File.Exists(dir + @"\translations\" + langInterface.Text + ".xml"))
                    {
                        translationFile = dir + @"\translations\" + langInterface.Text + ".xml";
                    }
                    else if (File.Exists(dir + @"\translations\english.xml"))
                    {
                        translationFile = dir + @"\translations\english.xml";
                    }
                    else
                    {
                        MessageBox.Show(translate("errorloadingmod", Globals.translateUI) + dir);
                        Process.GetCurrentProcess().Kill();
                    }

                    modDir = Path.GetFileName(dir);

                getTranslationXml(translationFile, Globals.translateMod, combo.Name + "." + modDir);
                combo.Items.Add(translate(combo.Name + "." + modDir, Globals.translateMod));

                }

        }


        //translate a text's control from its name
        static void translateCtrl(Control ctrl)
        {
            for (var i = 0; i < Globals.translateUI.Count; i += 1)
            {
                if (ctrl.Name.Contains("donation") && Globals.translateUI[i].name == ("donation"))
                {
                    ctrl.Text = Globals.translateUI[i].text;
                    break;
                }
                else
                {
                    if (ctrl.Name == Globals.translateUI[i].name)
                    {
                        ctrl.Text = Globals.translateUI[i].text;
                        break;
                    }
                }
            }
        }


        //translate a text's control from a specific label
        static string translate(string name, List<(string name, string text)> trans)
        {
            for (var i = 0; i < trans.Count; i += 1)
            {
                if (name == trans[i].name)
                {
                    return trans[i].text;
                }
            }
            return "";
        }


        //recusive control list
        static IEnumerable<Control> Flatten(Control c)
        {
            yield return c;

            foreach (Control o in c.Controls)
            {
                foreach (var oo in Flatten(o))
                    yield return oo;
            }
        }


        //translate all control of the UI
        private void translateAll()
        {
            //apply translation list to each controls
            foreach (Control x in Flatten(this))
            {
                translateCtrl(x);
            }

            //set game lang = interface lang if possible
            for (var i = 0; i < langGame.Items.Count; i += 1)
            {
                if (langGame.GetItemText(langGame.Items[i]) == langInterface.Text) { langGame.Text = langInterface.Text; }
            }

            //get default "vanila" value and get mods options
            Globals.vanilla = translate("vanilla", Globals.translateUI);
        }


        //Read translation file to a static list
        static void getTranslationXml(string fileLang, List<(string name, string text)> trans, string modName = "")
        {
            string ctrlName = "" ;
            string ctrlText = "" ;
            string ctrlHelp = "";
            string ctrlUrl = "";
            string ctrlAuthor = "";
            string ctrtCompatibility = "";

            if (!File.Exists(fileLang))
            {
                MessageBox.Show(translate("errorloadingtransfile", Globals.translateUI) + fileLang);
                Process.GetCurrentProcess().Kill();
            }

                using (XmlReader reader = XmlReader.Create(fileLang))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "name":
                                ctrlName = reader.ReadString();
                                break;
                            case "text":
                                ctrlText = reader.ReadString();
                                break;
                            case "help":
                                ctrlHelp = reader.ReadString();
                                break;
                            case "url":
                                ctrlUrl = reader.ReadString();
                                break;
                            case "author":
                                ctrlAuthor = reader.ReadString();
                                break;
                            case "compatibily":
                                ctrtCompatibility = reader.ReadString();
                                break;
                            case "control":
                                if (ctrlText != "")
                                {
                                    trans.Add((ctrlName + modName, ctrlText));
                                    trans.Add((ctrlName + modName + "help", ctrlHelp));
                                    trans.Add((ctrlName + modName + "url", ctrlUrl));
                                    trans.Add((ctrlName + modName + "author", ctrlAuthor));
                                    trans.Add((ctrlName + modName + "compatibily", ctrtCompatibility));
                                }
                                ctrlName = "";
                                ctrlText = "";
                                ctrlHelp = "";
                                ctrlUrl = "";
                                ctrlAuthor = "";
                                ctrtCompatibility = "";
                                break;
                        }

                    }

                }

                // avoid the last value to be ignored
                if (ctrlText != "")
                {
                    trans.Add((ctrlName + modName, ctrlText));
                    trans.Add((ctrlName + modName + "help", ctrlHelp));
                    trans.Add((ctrlName + modName + "url", ctrlUrl));
                    trans.Add((ctrlName + modName + "author", ctrlAuthor));
                    trans.Add((ctrlName + modName + "compatibily", ctrtCompatibility));
                }

            }
        }

    }
}
