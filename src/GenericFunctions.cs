using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {
        private PrivateFontCollection pfc;

        protected override void OnLoad(EventArgs e)
        {
            pfc = new PrivateFontCollection();
            pfc.AddFontFile(Application.StartupPath + @"\Ressources\" + "Roboto-Regular.ttf");
            pfc.AddFontFile(Application.StartupPath + @"\Ressources\" + "Roboto-Black.ttf");

            base.OnLoad(e);

            ApplyFonts(this);
        }



        private void ApplyFonts(Control control)
        {
            //Apply fonts to controls
            if (control is Label || control is ComboBox || control is CheckBox || control is GroupBox || control is ListBox)
            {
                if (control.Font.Bold)
                {
                    control.Font = new Font(pfc.Families[1], control.Font.Size);
                }
                else
                {
                    control.Font = new Font(pfc.Families[0], control.Font.Size);
                }
            }

            // Appliquer la police aux contrôles enfants du contrôle actuel
            foreach (Control childControl in control.Controls)
            {
                ApplyFonts(childControl);
            }
        }



        //private declaration for SetPadding function
        private const int EM_SETRECT = 0xB3;

        [DllImport(@"User32.dll", EntryPoint = @"SendMessage", CharSet = CharSet.Auto)]
        private static extern int SendMessageRefRect(IntPtr hWnd, uint msg, int wParam, ref RECT rect);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public readonly int Left;
            public readonly int Top;
            public readonly int Right;
            public readonly int Bottom;

            private RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public RECT(Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom)
            {
            }
        }



        public void SetPadding(System.Windows.Forms.TextBox textBox, Padding padding)
        {
            var rect = new Rectangle(padding.Left, padding.Top, textBox.ClientSize.Width - padding.Left - padding.Right, textBox.ClientSize.Height - padding.Top - padding.Bottom);
            RECT rc = new RECT(rect);
            SendMessageRefRect(textBox.Handle, EM_SETRECT, 0, ref rc);
        }



        //copy folder content to another folder recusively and overwrite
        public static void folderCopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                Application.DoEvents();
            }
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                target.CreateSubdirectory(diSourceSubDir.Name);
                folderCopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }



        //Backup mouse Y position
        private void getMousePos(object sender, EventArgs e) { Globals.mouseY = Cursor.Position.Y; }



        //Restore pouse Y position
        private void setMousePos(object sender, EventArgs e)
        {
            if (Globals.mouseY != 0)
            {
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X, Globals.mouseY);
                Globals.mouseY = 0;
            }
        }




        //Hide or show vertical scrollbars in textborx if needed
        private void scrollHelper (System.Windows.Forms.TextBox helpBox)
        {
            if (helpBox.GetPositionFromCharIndex(helpBox.Text.Length - 1).Y < helpBox.ClientSize.Height)
            {
                helpBox.ScrollBars = ScrollBars.None;
                SetPadding(helpBox, new Padding(5, 4, 5, 4));
            }
            else
            {
                helpBox.ScrollBars = ScrollBars.Vertical;
                SetPadding(helpBox, new Padding(5, 4, 5, 4));
            }
        }

    }

}
