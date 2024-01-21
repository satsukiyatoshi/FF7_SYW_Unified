

namespace FF7_SYW_Unified
{

    partial class FF7U
    {
        public static class Globals
        {
            public static readonly Color activButtonBolor = Color.FromArgb(240, 240, 240);
            public static readonly Color inactivButtonBolor = Color.FromArgb(200, 200, 200);
            public static string gameLang { get; set; } = "F";
            public static int presetNumber { get; set; } = 0;
            public static Boolean formIsLoaded { get; set; } = false;
            public static Boolean formSettingsLoaded { get; set; } = false;
            public static string isodrive { get; set; } = "";
            public static string activMenuName { get; set; } = "menuAbout";
            public static string vanilla { get; set; } = "";
            public static Boolean directLaunch { get; set; } = false;
            public static string actualModFolder { get; set; } = "";
            public static string actualModUrl { get; set; } = "";
            public static string actualModFlags { get; set; } = "";
            public static Boolean isFoobarRunning { get; set; } = false;
            public static Boolean isGameLoading { get; set; } = false;
            public static int mouseY { get; set; } = 0;
            public static System.Drawing.Point mousePos { get; set; } = new System.Drawing.Point(0, 0);
            public static List<(string name, string text)> translateUI { get; set; } = new List<(string name, string text)> { }; //global UI translation list
            public static List<(string name, string text)> translateMod { get; set; } = new List<(string name, string text)> { }; //temp list to store mods translations files
            public static float scaleScreen { get; set; } = 1;
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

    }
}
