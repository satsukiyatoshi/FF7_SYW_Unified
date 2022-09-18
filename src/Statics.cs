

namespace FF7_SYW_Unified
{

    partial class Form1
    {
        public static class Globals
        {
            public static readonly Color activButtonBolor = Color.FromArgb(240, 240, 240);
            public static readonly Color inactivButtonBolor = Color.FromArgb(180, 180, 180);
            public static string activMenuName { get; set; } = "menuAbout";
            public static List<(string name, string text)> translation { get; set; } = new List<(string name, string text)> { };
        }
    }
}
