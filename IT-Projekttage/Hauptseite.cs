using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.IO;

namespace IT_Projekttage
{
    public partial class Hauptseite : Form
    {
        int tempo = 120;
        bool isLooping;
        string instFilePath1;
        string instFilePath2;
        string instFilePath3;
        string instFilePath4;
        string instFilePath5;
        string instFilePath6;
        string instrName1;
        string instrName2;
        string instrName3;
        string instrName4;
        string instrName5;
        string instrName6;
        public static int Sample1Vol = 50;
        public static int Sample2Vol = 50;
        public static int Sample3Vol = 50;
        public static int Sample4Vol = 50;
        public static int Sample5Vol = 50;
        public static int Sample6Vol = 50;
        Thread loopThread;
        [ThreadStatic]
        public static MediaPlayer SamplePlayer1;
        public static MediaPlayer SamplePlayer2;
        public static MediaPlayer SamplePlayer3;
        public static MediaPlayer SamplePlayer4;
        public static MediaPlayer SamplePlayer5;
        public static MediaPlayer SamplePlayer6;


        public Hauptseite()
        {
            InitializeComponent();
            Directory.CreateDirectory(Application.StartupPath + @"\samples\");
            Directory.CreateDirectory(Application.StartupPath + @"\exports\");
        }

        private void Hauptseite_Load(object sender, EventArgs e)
        {
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!isLooping)
            {
                CalculateSleepTempo();
                isLooping = true;
                PlayAllPanels();
            }
        }

        private void CalculateSleepTempo()
        {
            double TPmil = 1 / (Convert.ToDouble(tbBPM.Text) / 60);
            tempo = Convert.ToInt32(TPmil * 250);
        }

        private void PlayPanel(Panel pPanel)
        {
            foreach (CheckBox Step in pPanel.Controls)
            {
                System.Drawing.Color borderColor = System.Drawing.Color.FromArgb(0, 254, 254);
                Step.FlatAppearance.BorderColor = borderColor;
                if (Step.Checked)
                    PlaySample(Convert.ToString(Step.Tag));
            }
            Thread.Sleep(tempo);
            changeBorderColorBack(pPanel);
        }

        private void changeBorderColorBack (Panel panel)
        {
            foreach (CheckBox Step in panel.Controls)
            {
                System.Drawing.Color borderColorBack = System.Drawing.Color.FromArgb(13, 0, 26);
                Step.FlatAppearance.BorderColor = borderColorBack;
            }
        }

        private void PlayAllPanels()
        {

            loopThread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                SamplePlayer1 = new MediaPlayer();
                SamplePlayer2 = new MediaPlayer();
                SamplePlayer3 = new MediaPlayer();
                SamplePlayer4 = new MediaPlayer();
                SamplePlayer5 = new MediaPlayer();
                SamplePlayer6 = new MediaPlayer();
                while (isLooping)
                {
                    PlayPanel(pnlStep1);
                    PlayPanel(pnlStep2);
                    PlayPanel(pnlStep3);
                    PlayPanel(pnlStep4);
                              
                    PlayPanel(pnlStep5);
                    PlayPanel(pnlStep6);
                    PlayPanel(pnlStep7);
                    PlayPanel(pnlStep8);
                              
                    PlayPanel(pnlStep9);
                    PlayPanel(pnlStep10);
                    PlayPanel(pnlStep11);
                    PlayPanel(pnlStep12);
                              
                    PlayPanel(pnlStep13);
                    PlayPanel(pnlStep14);
                    PlayPanel(pnlStep15);
                    PlayPanel(pnlStep16);
                }
            });
            loopThread.Start();
        }

        private void textBoxBPM_TextChanged(object sender, EventArgs e)
        {
            CalculateSleepTempo();
        }

        private void PlaySample(string pFilename)
        {
            if (pFilename == instrName1)
            {
                SamplePlayer1.Open(new System.Uri(instFilePath1));
                SamplePlayer1.Volume = Sample1Vol / 100.0;
                SamplePlayer1.Play();
            }

            if (pFilename == instrName2)
            {
                SamplePlayer2.Open(new System.Uri(instFilePath2));
                SamplePlayer2.Volume = Sample2Vol / 100.0;
                SamplePlayer2.Play();
            }

            if (pFilename == instrName3)
            {
                SamplePlayer3.Open(new System.Uri(instFilePath3));
                SamplePlayer3.Volume = Sample3Vol / 100.0;
                SamplePlayer3.Play();
            }

            if (pFilename == instrName4)
            {
                SamplePlayer4.Open(new System.Uri(instFilePath4));
                SamplePlayer4.Volume = Sample4Vol / 100.0;
                SamplePlayer4.Play();
            }

            if (pFilename == instrName5)
            {
                SamplePlayer5.Open(new System.Uri(instFilePath5));
                SamplePlayer5.Volume = Sample5Vol / 100.0;
                SamplePlayer5.Play();
            }

            if (pFilename == instrName6)
            {
                SamplePlayer6.Open(new System.Uri(instFilePath6));
                SamplePlayer6.Volume = Sample6Vol / 100.0;
                SamplePlayer6.Play();
            }
        }
        private void btnVolume_Click(object sender, EventArgs e)
        {
            Volume volumePage = new Volume();
            volumePage.Show();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isLooping = false;
            loopThread.Abort();
            changeBorderColorBack(pnlStep1);
            changeBorderColorBack(pnlStep2);
            changeBorderColorBack(pnlStep3);
            changeBorderColorBack(pnlStep4);
            changeBorderColorBack(pnlStep5);
            changeBorderColorBack(pnlStep6);
            changeBorderColorBack(pnlStep7);
            changeBorderColorBack(pnlStep8);
            changeBorderColorBack(pnlStep9);
            changeBorderColorBack(pnlStep10);
            changeBorderColorBack(pnlStep11);
            changeBorderColorBack(pnlStep12);
            changeBorderColorBack(pnlStep13);
            changeBorderColorBack(pnlStep14);
            changeBorderColorBack(pnlStep15);
            changeBorderColorBack(pnlStep16);
        }

        private string openSampleFile()
        {
            try
            {
                using (var fdl = new OpenFileDialog())
                {
                    fdl.InitialDirectory = @Application.StartupPath + @"\Samples\";
                    fdl.Filter = "Wavefile(*.wav)|*.wav";
                    if (fdl.ShowDialog() == DialogResult.OK)
                    {
                        return fdl.FileName;
                    }
                }
                return "Error";
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void setPanelTag(int instrNum, string fileName)
        {
            string instPanelName;
            for (int panelCounter = 1; panelCounter < 17; panelCounter++)
            {
                instPanelName = "cbInstr" + instrNum + panelCounter;

                setPanelTagHelper(pnlStep1, instPanelName, fileName);
                setPanelTagHelper(pnlStep2, instPanelName, fileName);
                setPanelTagHelper(pnlStep3, instPanelName, fileName);
                setPanelTagHelper(pnlStep4, instPanelName, fileName);
                setPanelTagHelper(pnlStep5, instPanelName, fileName);
                setPanelTagHelper(pnlStep6, instPanelName, fileName);
                setPanelTagHelper(pnlStep7, instPanelName, fileName);
                setPanelTagHelper(pnlStep8, instPanelName, fileName);
                setPanelTagHelper(pnlStep9, instPanelName, fileName);
                setPanelTagHelper(pnlStep10, instPanelName, fileName);
                setPanelTagHelper(pnlStep11, instPanelName, fileName);
                setPanelTagHelper(pnlStep12, instPanelName, fileName);
                setPanelTagHelper(pnlStep13, instPanelName, fileName);
                setPanelTagHelper(pnlStep14, instPanelName, fileName);
                setPanelTagHelper(pnlStep15, instPanelName, fileName);
                setPanelTagHelper(pnlStep16, instPanelName, fileName);
            }
        }

        private void setPanelTagHelper(Panel panel, string instPanelNameHelper, string fileNameHelper)
        {
            foreach (CheckBox checkBox in panel.Controls)
            {
                if (checkBox.Name == instPanelNameHelper)
                {
                    checkBox.Tag = fileNameHelper;
                }
            }
        }

        private string cutFilePath(string uncutFilePath)
        {
            try
            {
                string fileNameSample = uncutFilePath;
                fileNameSample = fileNameSample.Substring(fileNameSample.LastIndexOf(@"\") + 1);
                fileNameSample = fileNameSample.Substring(0, fileNameSample.IndexOf("."));
                return fileNameSample;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Bitte wählen Sie eine Datei aus!", "Keine Datei ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Instrument";
            }
        }
        private void btnSample1_Click(object sender, EventArgs e)
        {
            LoadSample(openSampleFile(), 1);
        }
        private void btnSample2_Click(object sender, EventArgs e)
        {
            LoadSample(openSampleFile(), 2);
        }

        private void btnSample3_Click(object sender, EventArgs e)
        {
            LoadSample(openSampleFile(), 3);
        }

        private void btnSample4_Click(object sender, EventArgs e)
        {
            LoadSample(openSampleFile(), 4);
        }

        private void btnSample5_Click(object sender, EventArgs e)
        {
            LoadSample(openSampleFile(), 5);
        }

        private void btnSample6_Click(object sender, EventArgs e)
        {
            LoadSample(openSampleFile(), 6);
        }

        private void importierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fdl = new OpenFileDialog())
            {
                string tempImportHelper;
                fdl.InitialDirectory = Application.StartupPath;
                if (fdl.ShowDialog() == DialogResult.OK)
                {
                    StreamReader streamReader = new StreamReader(fdl.FileName);
                    string importJson = streamReader.ReadLine();
                    tempImportHelper = importJson.Substring(0, importJson.IndexOf(";") + 1);
                    importJson = importJson.Substring(importJson.IndexOf(";") + 1);
                    if (tempImportHelper != "")
                        processSubstring(tempImportHelper, 1);

                    tempImportHelper = importJson.Substring(0, importJson.IndexOf(";") + 1);
                    importJson = importJson.Substring(importJson.IndexOf(";") + 1);
                    if (tempImportHelper != "")
                        processSubstring(tempImportHelper, 2);

                    tempImportHelper = importJson.Substring(0, importJson.IndexOf(";") + 1);
                    importJson = importJson.Substring(importJson.IndexOf(";") + 1);
                    if (tempImportHelper != "")
                        processSubstring(tempImportHelper, 3);

                    tempImportHelper = importJson.Substring(0, importJson.IndexOf(";") + 1);
                    importJson = importJson.Substring(importJson.IndexOf(";") + 1);
                    if (tempImportHelper != "")
                        processSubstring(tempImportHelper, 4);

                    tempImportHelper = importJson.Substring(0, importJson.IndexOf(";") + 1);
                    importJson = importJson.Substring(importJson.IndexOf(";") + 1);
                    if (tempImportHelper != "")
                        processSubstring(tempImportHelper, 5);

                    tempImportHelper = importJson.Substring(0, importJson.IndexOf(";") + 1);
                    importJson = importJson.Substring(importJson.IndexOf(";") + 1);
                    if (tempImportHelper != "")
                        processSubstring(tempImportHelper, 6);

                    importJson = importJson.Substring(importJson.IndexOf(":") + 1);
                    tbBPM.Text = importJson;
                }
            }

        }

        private void processSubstring(string substring, int InstNo)
        {
            string settings;
            string filePath;
            string instrName;

            instrName = substring.Substring(0, substring.IndexOf(":"));
            settings = substring.Substring(substring.IndexOf(":") + 1);
            filePath = Application.StartupPath + @"\samples\" + instrName + ".wav";
            LoadSample(filePath, InstNo);
            setSettings(InstNo, settings);
        }

        private void setSettings(int instrNum, string settings)
        {
            string instPanelName;
            string tempSettings = settings;
            for (int panelCounter = 1; panelCounter < 17; panelCounter++)
            {
                instPanelName = "cbInstr" + instrNum + panelCounter;
                if (tempSettings != ";")
                {
                    int cutSettingIndex = Convert.ToInt32(tempSettings.Substring(0, 1));
                    tempSettings = tempSettings.Substring(tempSettings.IndexOf(",") + 1);

                    setSettingsHelper(pnlStep1, instPanelName, cutSettingIndex);
                    setSettingsHelper(pnlStep2, instPanelName, cutSettingIndex);
                    setSettingsHelper(pnlStep3, instPanelName, cutSettingIndex);
                    setSettingsHelper(pnlStep4, instPanelName, cutSettingIndex);
                    setSettingsHelper(pnlStep5, instPanelName, cutSettingIndex);
                    setSettingsHelper(pnlStep6, instPanelName, cutSettingIndex);
                    setSettingsHelper(pnlStep7, instPanelName, cutSettingIndex);
                    setSettingsHelper(pnlStep8, instPanelName, cutSettingIndex);
                    setSettingsHelper(pnlStep9, instPanelName, cutSettingIndex);
                    setSettingsHelper(pnlStep10, instPanelName, cutSettingIndex);
                    setSettingsHelper(pnlStep11, instPanelName, cutSettingIndex);
                    setSettingsHelper(pnlStep12, instPanelName, cutSettingIndex);
                    setSettingsHelper(pnlStep13, instPanelName, cutSettingIndex);
                    setSettingsHelper(pnlStep14, instPanelName, cutSettingIndex);
                    setSettingsHelper(pnlStep15, instPanelName, cutSettingIndex);
                    setSettingsHelper(pnlStep16, instPanelName, cutSettingIndex);
                }
            }
        }

        private void setSettingsHelper(Panel panel, string instPanelNameHelper, int settingsIndex)
        {
            foreach (CheckBox checkBox in panel.Controls)
            {
                if (checkBox.Name == instPanelNameHelper && settingsIndex == 1)
                {
                    checkBox.Checked = true;
                }
            }
        }

        private void exportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string exportJson = "";
            exportJson += exportHelper(instrName1);
            exportJson += exportHelper(instrName2);
            exportJson += exportHelper(instrName3);
            exportJson += exportHelper(instrName4);
            exportJson += exportHelper(instrName5);
            exportJson += exportHelper(instrName6);
            exportJson += "BPM:" + tbBPM.Text;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "txt Files (*.txt)|*.txt";
                sfd.InitialDirectory = Application.StartupPath;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream exportFile = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        using (StreamWriter exportWriter = new StreamWriter(exportFile))
                        {
                            exportWriter.WriteLine(exportJson);
                        }
                    }
                }
            }
            MessageBox.Show("Einstellungen wurden erfolgreich exportiert.");
        }

        private string exportHelper(string instrName)
        {
            string tempHelperExport = instrName + ":";
            if (instrName != null && instrName != "")
            {
                tempHelperExport += exportHelperHelper(pnlStep1, instrName);
                tempHelperExport += exportHelperHelper(pnlStep2, instrName);
                tempHelperExport += exportHelperHelper(pnlStep3, instrName);
                tempHelperExport += exportHelperHelper(pnlStep4, instrName);
                tempHelperExport += exportHelperHelper(pnlStep5, instrName);
                tempHelperExport += exportHelperHelper(pnlStep6, instrName);
                tempHelperExport += exportHelperHelper(pnlStep7, instrName);
                tempHelperExport += exportHelperHelper(pnlStep8, instrName);
                tempHelperExport += exportHelperHelper(pnlStep9, instrName);
                tempHelperExport += exportHelperHelper(pnlStep10, instrName);
                tempHelperExport += exportHelperHelper(pnlStep11, instrName);
                tempHelperExport += exportHelperHelper(pnlStep12, instrName);
                tempHelperExport += exportHelperHelper(pnlStep13, instrName);
                tempHelperExport += exportHelperHelper(pnlStep14, instrName);
                tempHelperExport += exportHelperHelper(pnlStep15, instrName);
                tempHelperExport += exportHelperHelper(pnlStep16, instrName);
            }
            tempHelperExport += ";";
            return tempHelperExport;
        }

        private string exportHelperHelper(Panel panel, string instrName)
        {
            string tempExport = "";
            foreach (CheckBox checkBox in panel.Controls)
            {
                if (Convert.ToString(checkBox.Tag) == instrName)
                {
                    if (checkBox.Checked)
                    {
                        tempExport += "1,";
                    }
                    else
                    {
                        tempExport += "0,";
                    }
                }
            }
            return tempExport;
        }

        private void überRhythmRibbonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ueber ueber = new Ueber();
            ueber.Show();
        }

        private void LoadSample(string pFilePath, int pInstrumentNo)
        {
            string tempFilePath = pFilePath;
            string tempFileName = cutFilePath(tempFilePath);
            switch (pInstrumentNo)
            {
                case 1:
                    instrName1 = tempFileName;
                    instFilePath1 = tempFilePath;
                    if (tempFileName.Length < 20)
                    {
                        setPanelTag(1, tempFileName);
                    }
                    btnSample1.Text = tempFileName;
                    Volume.sampleName1 = tempFileName;
                    break;

                case 2:
                    instrName2 = tempFileName;
                    instFilePath2 = tempFilePath;
                    if (tempFileName.Length < 20)
                    {
                        setPanelTag(2, tempFileName);
                    }
                    btnSample2.Text = tempFileName;
                    Volume.sampleName2 = tempFileName;
                    break;

                case 3:
                    instrName3 = tempFileName;
                    instFilePath3 = tempFilePath;
                    if (tempFileName.Length < 20)
                    {
                        setPanelTag(3, tempFileName);
                    }
                    btnSample3.Text = tempFileName;
                    Volume.sampleName3 = tempFileName;
                    break;

                case 4:
                    instrName4 = tempFileName;
                    instFilePath4 = tempFilePath;
                    if (tempFileName.Length < 20)
                    {
                        setPanelTag(4, tempFileName);
                    }
                    btnSample4.Text = tempFileName;
                    Volume.sampleName4 = tempFileName;
                    break;

                case 5:
                    instrName5 = tempFileName;
                    instFilePath5 = tempFilePath;
                    if (tempFileName.Length < 20)
                    {
                        setPanelTag(5, tempFileName);
                    }
                    btnSample5.Text = tempFileName;
                    Volume.sampleName5 = tempFileName;
                    break;

                case 6:
                    instrName6 = tempFileName;
                    instFilePath6 = tempFilePath;
                    if (tempFileName.Length < 20)
                    {
                        setPanelTag(6, tempFileName);
                    }
                    btnSample6.Text = tempFileName;
                    Volume.sampleName6 = tempFileName;
                    break;
            }
        }
    }
}
