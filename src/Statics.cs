﻿

namespace FF7_SYW_Unified
{

    partial class FF7U
    {
        public static class Globals
        {
            public static readonly Color activButtonBolor = Color.FromArgb(240, 240, 240);
            public static readonly Color inactivButtonBolor = Color.FromArgb(180, 180, 180);
            public static string activMenuName { get; set; } = "menuAbout";
            public static string vanilla { get; set; } = "";
            public static Boolean isFoobarRunning { get; set; } = false;
            public static int mouseY  = 0;
            public static System.Drawing.Point mousePos { get; set; } = new System.Drawing.Point(0, 0);
            public static List<(string name, string text)> translateUI { get; set; } = new List<(string name, string text)> { }; //global UI translation list
            public static List<(string name, string text)> translateMod { get; set; } = new List<(string name, string text)> { }; //temp list to store mods translations files
        }
    }
}
