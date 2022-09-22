

namespace FF7_SYW_Unified
{

    partial class Form1
    {
        public static class Globals
        {
            public static readonly Color activButtonBolor = Color.FromArgb(240, 240, 240);
            public static readonly Color inactivButtonBolor = Color.FromArgb(180, 180, 180);
            public static string activMenuName { get; set; } = "menuAbout";
            public static string vanilla { get; set; } = "";
            public static List<(string name, string text)> translateUI { get; set; } = new List<(string name, string text)> { }; //global UI translation list
            public static List<(string name, string text)> translateMod { get; set; } = new List<(string name, string text)> { }; //temp list to store mods translations files
        }
    }
}
