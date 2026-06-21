using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TaikoVDLCBuilder;

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
        Global.Database = DlcHandler.OrganizeByGenre(Global.Database);
        BindingSource source = new();
        source.DataSource = Global.Database.Items;
        DBView.AutoSize = true;
        DBView.DataSource = source;
        DBView.Refresh();
        IntroLabel.Text = Global.WlcmTxt;
    }
    //Run button Click
    private void RunButton_Click(object sender, EventArgs e)
    {
        int nSlot = 0;
        int nSong = 0;
        //List selected songs
        List<SongItem> selectedSongs = new();
        //Check how many songs has been selected
        for (int i = 0; i <= (DBView.Rows.Count - 1); i++)
        {
            if (!Global.Database.Items[i].isChecked) continue;
                
            nSong++;
            nSlot++;
                
            //If Ura add one more slot
            if (Global.Database.Items[i].starUra > 0)
            {
                nSlot++;
            }
            selectedSongs.Add(Global.Database.Items[i]);
        }
        string ms1 = Global.MsgSongSl1 + nSong + Global.MsgSongSl2 + nSlot + Global.MsgSongSl3;
        string ms2 = Global.MsgSongSl4 + (Global.Tslot - nSlot) + Global.MsgSongSl3;
            
        if (nSlot == 0) //No song selected
        {
            MessageBox.Show(Global.MsgSongSl7, Global.TlSongSl);
            return;
        } 
            
        if (nSlot > Global.Tslot)  //More songs selected than the slot limit
        {
            MessageBox.Show(ms1 + Global.MsgSongSl6, Global.TlSongSl);
            return;
        }
            
        if (nSong > Global.Tsong)  //More songs selected than the song limit
        {
            MessageBox.Show(ms1 + Global.MsgSongSl8, Global.TlSongSl);
            return;
        }
            
        //Confirm song selection
        string message = ms1 + ms2 + Global.MsgSongSl5;
        DialogResult result = MessageBox.Show(message, Global.TlSongSl, MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
            DlcHandler.InitializeDlc(RunPBar,selectedSongs);
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
            column.SortMode = DataGridViewColumnSortMode.Programmatic;
    }
        
    //Randomizer button click
    private void RandomButton_Click(object sender, EventArgs e)
    {
        int rndSlot = 0;
        int rndSong = 0;
        Random rnd = new();
            
        //Clear all selection
        ClearDb();
            
        //Repeat while limit is not reached or number of songs is lower than total
        while (rndSong < Global.Tsong)
        {
            //Get a random song
            int idx = rnd.Next(DBView.Rows.Count);
                
            //Select song only if it's not selected
            if (!Global.Database.Items[idx].isChecked)
            {
                Global.Database.Items[idx].isChecked = true;
                rndSlot++;
                rndSong++;
                    
                //Add 1 more slot if Ura is avaible
                if (Global.Database.Items[idx].starUra > 0)
                {
                    rndSlot++;
                        
                    //Check if the song limit is reached and disable the ura song (to avoid limit + 1)
                    if (rndSlot > Global.Tslot)
                        Global.Database.Items[idx].isChecked = false;
                }
            }
                
            if (rndSong == Global.Database.Items.Count) break;
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
            Global.Database.Items[i].isChecked = false;
    }
}