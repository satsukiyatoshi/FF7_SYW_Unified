using Microsoft.VisualBasic.Devices;
using System;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace FF7_SYW_Unified
{
    partial class FF7U
    {

        private void setDefaultUIValues ()
        {
            FFNx3dEngine.Items.Add(translate("automatic", Globals.translateUI));
            FFNx3dEngine.Items.Add("OpenGL");
            FFNx3dEngine.Items.Add("Direct3D9");
            FFNx3dEngine.Items.Add("Direct3D11");
            FFNx3dEngine.Items.Add("Direct3D12");
            FFNx3dEngine.Items.Add("Vulkan");
            FFNx3dEngine.Text = translate("automatic", Globals.translateUI);

            FFNxScreen.Items.Add(translate("fullscreen", Globals.translateUI));
            FFNxScreen.Items.Add(translate("windowed", Globals.translateUI));
            FFNxScreen.Items.Add(translate("windowedborderless", Globals.translateUI));
            FFNxScreen.Text=(translate("fullscreen", Globals.translateUI));

            FFNxResolution.Items.Add(translate("automatic", Globals.translateUI));
            getScreenResolutions();
            FFNxResolution.Text = (translate("automatic", Globals.translateUI));

            FFNxRatio.Items.Add("4/3 (" + translate("vanilla", Globals.translateUI)+")");
            FFNxRatio.Items.Add(translate("strechedwidescreen", Globals.translateUI));
            FFNxRatio.Items.Add(translate("realwidescreen", Globals.translateUI));
            FFNxRatio.Text = ("4/3 (" + translate("vanilla", Globals.translateUI) + ")");

            FFNxIR.Items.Add(translate("automatic", Globals.translateUI));
            FFNxIR.Items.Add("x1");
            FFNxIR.Items.Add("x2");
            FFNxIR.Items.Add("x4");
            FFNxIR.Items.Add("x8");
            FFNxIR.Text = translate("automatic", Globals.translateUI);

            FFNxHDR.Items.Add(translate("automatic", Globals.translateUI));
            FFNxHDR.Items.Add("100");
            FFNxHDR.Items.Add("200");
            FFNxHDR.Items.Add("300");
            FFNxHDR.Items.Add("400");
            FFNxHDR.Items.Add("500");
            FFNxHDR.Items.Add("600");
            FFNxHDR.Items.Add("700");
            FFNxHDR.Items.Add("800");
            FFNxHDR.Items.Add("900");
            FFNxHDR.Items.Add("1000");
            FFNxHDR.Items.Add("1100");
            FFNxHDR.Items.Add("1200");
            FFNxHDR.Items.Add("1300");
            FFNxHDR.Items.Add("1400");
            FFNxHDR.Items.Add("1500");
            FFNxHDR.Text = translate("automatic", Globals.translateUI);

            FFNxAA.Items.Add(translate("disabled", Globals.translateUI));
            FFNxAA.Items.Add("x2");
            FFNxAA.Items.Add("x4");
            FFNxAA.Items.Add("x6");
            FFNxAA.Items.Add("x8");
            FFNxAA.Text = "x4";

            FFNxSpeedhackStep.Items.Add("0.5");
            FFNxSpeedhackStep.Items.Add("1.0");
            FFNxSpeedhackStep.Items.Add("1.5");
            FFNxSpeedhackStep.Items.Add("2.0");
            FFNxSpeedhackStep.Items.Add("2.5");
            FFNxSpeedhackStep.Items.Add("3.0");
            FFNxSpeedhackStep.Text = ("1.0");

            FFNxSpeedhackMin.Items.Add("1.0");
            FFNxSpeedhackMin.Items.Add("1.5");
            FFNxSpeedhackMin.Items.Add("2.0");
            FFNxSpeedhackMin.Items.Add("2.5");
            FFNxSpeedhackMin.Items.Add("3.0");
            FFNxSpeedhackMin.Text = ("1.0");

            FFNxSpeedhackMax.Items.Add("1.5");
            FFNxSpeedhackMax.Items.Add("2.0");
            FFNxSpeedhackMax.Items.Add("3.0");
            FFNxSpeedhackMax.Items.Add("4.0");
            FFNxSpeedhackMax.Items.Add("5.0");
            FFNxSpeedhackMax.Items.Add("6.0");
            FFNxSpeedhackMax.Items.Add("7.0");
            FFNxSpeedhackMax.Items.Add("8.0");
            FFNxSpeedhackMax.Text = ("4.0");

            FFNxContolerDeathzoneStick.Items.Add("0.0");
            FFNxContolerDeathzoneStick.Items.Add("0.1");
            FFNxContolerDeathzoneStick.Items.Add("0.2");
            FFNxContolerDeathzoneStick.Items.Add("0.3");
            FFNxContolerDeathzoneStick.Items.Add("0.4");
            FFNxContolerDeathzoneStick.Items.Add("0.5");
            FFNxContolerDeathzoneStick.Items.Add("0.6");
            FFNxContolerDeathzoneStick.Items.Add("0.7");
            FFNxContolerDeathzoneStick.Items.Add("0.8");
            FFNxContolerDeathzoneStick.Items.Add("0.9");
            FFNxContolerDeathzoneStick.Items.Add("1.0");
            FFNxContolerDeathzoneStick.Text = "0.1";

            FFNxContolerDeathzoneLT.Items.Add("0.0");
            FFNxContolerDeathzoneLT.Items.Add("0.1");
            FFNxContolerDeathzoneLT.Items.Add("0.2");
            FFNxContolerDeathzoneLT.Items.Add("0.3");
            FFNxContolerDeathzoneLT.Items.Add("0.4");
            FFNxContolerDeathzoneLT.Items.Add("0.5");
            FFNxContolerDeathzoneLT.Items.Add("0.6");
            FFNxContolerDeathzoneLT.Items.Add("0.7");
            FFNxContolerDeathzoneLT.Items.Add("0.8");
            FFNxContolerDeathzoneLT.Items.Add("0.9");
            FFNxContolerDeathzoneLT.Items.Add("1.0");
            FFNxContolerDeathzoneLT.Text = "0.1";

            FFNxContolerDeathzoneRT.Items.Add("0.0");
            FFNxContolerDeathzoneRT.Items.Add("0.1");
            FFNxContolerDeathzoneRT.Items.Add("0.2");
            FFNxContolerDeathzoneRT.Items.Add("0.3");
            FFNxContolerDeathzoneRT.Items.Add("0.4");
            FFNxContolerDeathzoneRT.Items.Add("0.5");
            FFNxContolerDeathzoneRT.Items.Add("0.6");
            FFNxContolerDeathzoneRT.Items.Add("0.7");
            FFNxContolerDeathzoneRT.Items.Add("0.8");
            FFNxContolerDeathzoneRT.Items.Add("0.9");
            FFNxContolerDeathzoneRT.Items.Add("1.0");
            FFNxContolerDeathzoneRT.Text = "0.1";

            FFNxFps.Items.Add(translate("vanilla", Globals.translateUI));
            FFNxFps.Items.Add(translate("gamefpsbattle30", Globals.translateUI));
            FFNxFps.Items.Add(translate("gamefull60fps", Globals.translateUI));
            FFNxFps.Text = translate("vanilla", Globals.translateUI);

            FFNxAudioChannels.Items.Add(translate("automatic", Globals.translateUI));
            FFNxAudioChannels.Items.Add("1.0");
            FFNxAudioChannels.Items.Add("2.0");
            FFNxAudioChannels.Items.Add("2.1");
            FFNxAudioChannels.Items.Add("3.0");
            FFNxAudioChannels.Items.Add("3.1");
            FFNxAudioChannels.Items.Add("4.0");
            FFNxAudioChannels.Items.Add("4.1");
            FFNxAudioChannels.Items.Add("5.0");
            FFNxAudioChannels.Items.Add("5.1");
            FFNxAudioChannels.Items.Add("6.0");
            FFNxAudioChannels.Items.Add("6.1");
            FFNxAudioChannels.Items.Add("7.0");
            FFNxAudioChannels.Items.Add("7.1");
            FFNxAudioChannels.Text = translate("automatic", Globals.translateUI);

            FFNxAudioSample.Items.Add("8000");
            FFNxAudioSample.Items.Add("11025");
            FFNxAudioSample.Items.Add("22050");
            FFNxAudioSample.Items.Add("32000");
            FFNxAudioSample.Items.Add("44100");
            FFNxAudioSample.Items.Add("48000");
            FFNxAudioSample.Items.Add("88200");
            FFNxAudioSample.Items.Add("96000");
            FFNxAudioSample.Items.Add("174000");
            FFNxAudioSample.Items.Add("192000");
            FFNxAudioSample.Text = "44100";
        }



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
                tw.WriteLine(";;;;" + co.Name + "::::" + co.Text + "####");
            }

            foreach(int indexChecked in FFNxPatchsList.CheckedIndices)
            {
                tw.WriteLine("Patchslist;;;;" + FFNxPatchsList.Items[indexChecked].ToString()+"####");
            }

            tw.Close();
        }



        private void loadValues()
        {
            string patchname;

            if (File.Exists(Application.StartupPath + @"\settings.ini"))
            {
                string[] lines = File.ReadAllLines(Application.StartupPath + @"\settings.ini");
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

                    else
                    {
                        GetCheckboxByName(line).Checked = true;
                    }
                }
            }
        }



        CheckBox GetCheckboxByName(string Name)
        {
            foreach (CheckBox c in Flatten(this).OfType<CheckBox>())
            {
                if (c.Name == Name)
                    return c;
            }
                return null;
        }



        ComboBox GetComboboxByName(string Name)
        {
            foreach (ComboBox c in Flatten(this).OfType<ComboBox>())
            {
                if (c.Name == Name)
                    return c;
            }
            return null;
        }



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
