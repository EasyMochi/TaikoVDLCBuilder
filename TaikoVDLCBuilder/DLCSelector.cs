using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TaikoVDLCBuilder
{
    [SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
    public partial class DlcSelector : Form
    {
        public DlcSelector()
        {
            InitializeComponent();
        }

        private void DLCSelector_Load(object sender, EventArgs e)
        {
            //Check if file exist
            if (!File.Exists(Global.PathJson))
            {
                MessageBox.Show(Global.MsgJson);
                Environment.Exit(1);
            }
            RunPBar.Visible = false;
            //Parse songdata.json to object
            string jsonfile = File.ReadAllText(Global.PathJson);
            Global.Database = JsonConvert.DeserializeObject<SongList>(jsonfile);
            //Sort by genre
            Global.Database = DlcHandler.OrganizebyGenre(Global.Database);
            BindingSource source = new();
            source.DataSource = Global.Database.Itens;
            DBView.AutoSize = true;
            DBView.DataSource = source;
            DBView.Refresh();
            IntroLabel.Text = Global.WlcmTxt;
        }
        //Run button Click
        private void RunButton_Click(object sender, EventArgs e)
        {
            int nslot = 0;
            int nsong = 0;
            //List selected songs
            List<SongItem> selectedsongs = new();
            //Check how many songs has been selected
            for (int i = 0; i <= (DBView.Rows.Count - 1); i++)
            {
                if (Global.Database.Itens[i].isChecked)
                {
                    nsong++;
                    nslot++;
                    //If has Ura add one more slot
                    if (Global.Database.Itens[i].starUra > 0)
                    {
                        nslot++;
                    }
                    selectedsongs.Add(Global.Database.Itens[i]);
                }
            }
            string ms1 = Global.MsgSongSl1 + nsong + Global.MsgSongSl2 + nslot + Global.MsgSongSl3;
            string ms2 = Global.MsgSongSl4 + (Global.Tslot - nslot) + Global.MsgSongSl3;
            //No song selected
            if (nslot == 0)
            {
                MessageBox.Show(Global.MsgSongSl7, Global.TlSongSl);
            } else if (nslot > Global.Tslot)  //More songs selected than limit
            {
                MessageBox.Show(ms1 + Global.MsgSongSl6, Global.TlSongSl);
            }
            else if (nsong > Global.Tsong)  //More songs selected than limit
            {
                MessageBox.Show(ms1 + Global.MsgSongSl8, Global.TlSongSl);
            }
            else
            {
                //Confirm song selection
                string message = ms1 + ms2 + Global.MsgSongSl5;
                DialogResult result = MessageBox.Show(message, Global.TlSongSl, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DlcHandler.InitializeDlc(RunPBar,selectedsongs);
                }
            }
        }
        // Organize BG color by genre
        private void DBView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Set BGColor per genre
            foreach (DataGridViewRow row in DBView.Rows)
            {
                SongItem rowObject = (SongItem)row.DataBoundItem;
                row.DefaultCellStyle.BackColor = rowObject.genreColor;
            }
            // Put each of the columns into programmatic sort mode.
            foreach (DataGridViewColumn column in DBView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
        //Randomizer button click
        private void RandomButton_Click(object sender, EventArgs e)
        {
            int rndslt = 0;
            int rndsng = 0;
            Random rnd = new();
            int idx;
            //Clear all selection
            ClearDb();
            //Repeat while limit is not reached or number of songs is lower than total
            while (rndsng < Global.Tsong)
            {
                //Get a random song
                idx = rnd.Next(DBView.Rows.Count);
                //Select song only if it's not selected
                if (Global.Database.Itens[idx].isChecked == false)
                {
                    Global.Database.Itens[idx].isChecked = true;
                    rndslt++;
                    rndsng++;
                    //Add 1 more slot if Ura is avaible
                    if (Global.Database.Itens[idx].starUra > 0)
                    {
                        rndslt++;
                        //Check if the song limit is reached and disable the ura song (to avoid limit + 1)
                        if (rndslt > Global.Tslot)
                        {
                            Global.Database.Itens[idx].isChecked = false;
                        }
                    }
                }
                if (rndsng == Global.Database.Itens.Count)
                {
                    break;
                }
            }
            DBView.Refresh();
        }
        //Clear button click
        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearDb();
            DBView.Refresh();
        }
        //Function to clear all selection
        private void ClearDb()
        {
            for (int i = 0; i <= (DBView.Rows.Count - 1); i++)
            {
                Global.Database.Itens[i].isChecked = false;
            }
        }
    }
}
