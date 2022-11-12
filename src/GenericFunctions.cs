namespace FF7_SYW_Unified
{
    partial class FF7U
    {

        //copy folder content to another folder recusively and overwrite
        public static void folderCopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
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


    }

}
