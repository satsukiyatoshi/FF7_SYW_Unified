
using Microsoft.VisualBasic;
using System.Xml;

namespace FF7_SYW_Unified
{
    partial class Form1
    {

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

        private void translationXml(string fileLang)
        {
            string ctrlName = "" ;
            string ctrlText = "" ;
            var translation = new List<(string name, string text)> { };

            //Read translation file to a list
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
                        translation.Add((ctrlName, ctrlText));
                        ctrlName = "";
                        ctrlText = "";
                    }
                }

            }

            //apply translation list to each controls
            foreach (Control x in Flatten(this))
            {
                for (var i = 0; i < translation.Count; i += 1)
                {
                    if (x.Name == translation[i].name)
                    {
                        x.Text = translation[i].text;
                    }

                    if (x.Name.Contains("donation") && translation[i].name == ("donation"))
                    {
                        x.Text = translation[i].text;
                    }
                }
            }

            //set game lang = interface lang if possible
            for (var i = 0; i < langGame.Items.Count; i += 1)
            {
                if (langGame.GetItemText(langGame.Items[i]) == langInterface.Text) { langGame.Text = langInterface.Text; return; }
            }

        }

    }
}
