using ComboBox = System.Windows.Forms.ComboBox;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {
        //get all possible resolutions for current diplay
        private void getScreenResolutions()
        {
            var scope = new System.Management.ManagementScope();
            var query = new System.Management.ObjectQuery("SELECT * FROM CIM_VideoControllerResolution");

            using (var searcher = new System.Management.ManagementObjectSearcher(scope, query))
            {
                var results = searcher.Get();

                string prevReso = string.Empty;
                string currReso = string.Empty;

                foreach (var result in results)
                {
                    currReso = result["HorizontalResolution"] + "x" + result["VerticalResolution"];
                    if (currReso != prevReso) { FFNxResolution.Items.Add(currReso); prevReso = currReso; }
                }
            }
        }



        //save all form controls values to a settings file
        private void saveValues()
        {
            TextWriter tw = new StreamWriter(@Application.StartupPath + @"\settings.ini");

            foreach (CheckBox ce in Flatten(this).OfType<CheckBox>())
            {
                if(ce.Checked == true)
                {
                    tw.WriteLine(ce.Name);
                }
            }

            foreach (ComboBox co in Flatten(this).OfType<ComboBox>())
            {
                if(co.Name != "langInterface")
                {
                    tw.WriteLine(";;;;" + co.Name + "::::" + co.Text + "####");
                }
            }

            foreach(int indexChecked in FFNxPatchsList.CheckedIndices)
            {
                tw.WriteLine("Patchslist;;;;" + FFNxPatchsList.Items[indexChecked].ToString()+"####");
            }

            foreach (int indexChecked in GameplayPatchsList.CheckedIndices)
            {
                tw.WriteLine("GameplayPatchslist;;;;" + GameplayPatchsList.Items[indexChecked].ToString() + "####");
            }

            tw.Close();

            TextWriter twl = new StreamWriter(@Application.StartupPath + @"\lang.ini");
                twl.WriteLine(";;;;langInterface::::" + langInterface.Text + "####");
            twl.Close();
        }



        //load all form controls value from a setting file
        private void loadValues(string ininame)
        {
            string patchname;

            try
            {
                if (File.Exists(ininame))
                {
                    string[] lines = File.ReadAllLines(ininame);
                    foreach (string line in lines)
                    {
                        if (line.Contains("::::") == true && line.Contains(";;;;") == true && line.Contains("####") == true)
                        {
                            GetComboboxByName(Between(line, ";;;;", "::::")).Text = Between(line, "::::", "####");
                        }

                        else if (line.Contains("Patchslist;;;;") == true && line.Contains("####") == true)
                        {
                            patchname = Between(line, "Patchslist;;;;", "####");

                            for (int patchvalue = 0; patchvalue < FFNxPatchsList.Items.Count; patchvalue++)
                            {
                                if (FFNxPatchsList.Items[patchvalue].ToString() == patchname)
                                {
                                    FFNxPatchsList.SetItemChecked(patchvalue, true);
                                }
                            }
                        }

                        else if (line.Contains("GameplayPatchslist;;;;") == true && line.Contains("####") == true)
                        {
                            patchname = Between(line, "GameplayPatchslist;;;;", "####");

                            for (int patchvalue = 0; patchvalue < GameplayPatchsList.Items.Count; patchvalue++)
                            {
                                if (GameplayPatchsList.Items[patchvalue].ToString() == patchname)
                                {
                                    GameplayPatchsList.SetItemChecked(patchvalue, true);
                                }
                            }
                        }

                        else
                        {
                            GetCheckboxByName(line).Checked = true;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error while loading setting, it may appens if you added or removed mods or patchs, please check settings");
            }

        }



        //Get a checkbox control by its name
        CheckBox GetCheckboxByName(string Name)
        {
            foreach (CheckBox c in Flatten(this).OfType<CheckBox>())
            {
                if (c.Name == Name)
                    return c;
            }
                return null;
        }



        //Get a combobox control by its name
        ComboBox GetComboboxByName(string Name)
        {
            foreach (ComboBox c in Flatten(this).OfType<ComboBox>())
            {
                if (c.Name == Name)
                    return c;
            }
            return null;
        }



        //get string between 2 strings
        public string Between(string STR, string FirstString, string LastString)
        {
            string FinalString;
            int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
            int Pos2 = STR.IndexOf(LastString);
            FinalString = STR.Substring(Pos1, Pos2 - Pos1);

            return FinalString;
        }

    }
}
