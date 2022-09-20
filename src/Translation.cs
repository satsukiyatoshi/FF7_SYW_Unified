
using System.Xml;

namespace FF7_SYW_Unified
{
    partial class Form1
    {

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
                if (langGame.GetItemText(langGame.Items[i]) == langInterface.Text) { langGame.Text = langInterface.Text; return; }
            }
        }



        //Read translation file to a static list
        static void getTranslationXml(string fileLang, List<(string name, string text)> trans)
        {
            string ctrlName = "" ;
            string ctrlText = "" ;

            using (XmlReader reader = XmlReader.Create(Application.StartupPath + @"\Translations\" + fileLang + ".xml"))
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
                            case "control":
                                ctrlName = "";
                                ctrlText = "";
                                break;
                        }
                    }

                    if (ctrlName != "" && ctrlText != "")
                    {
                        trans.Add((ctrlName, ctrlText));
                        ctrlName = "";
                        ctrlText = "";
                    }
                }

            }
        }

    }
}
