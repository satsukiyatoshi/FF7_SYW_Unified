
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

        //translation on all controls from .lang file
        private void translation(string fileLang)
        {
            var lines = File.ReadAllLines(Application.StartupPath + @"\Translations\" + fileLang + ".lang");

            foreach (Control x in Flatten(this))
            {

                for (var i = 0; i < lines.Length; i += 1)
                {
                    if (lines[i].Contains(x.Name + ":::"))
                    {
                        x.Text = (lines[i].Replace(x.Name + ":::", "")).Replace("###", System.Environment.NewLine);
                    }

                    if (lines[i].Contains("donation:::") && x.Name.Contains("donation"))
                    {
                        x.Text = lines[i].Replace("donation:::", ""); 
                    }
                }
            }

            for (var i = 0; i < langGame.Items.Count; i += 1)
            {
                if (langGame.GetItemText(langGame.Items[i]) == langInterface.Text) { langGame.Text = langInterface.Text; return; }
            }
        }

    }
}
