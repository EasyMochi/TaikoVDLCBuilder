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
        // Check whether songdata.json exists.
        if (!File.Exists(Global.PathJson))
        {
            MessageBox.Show(Global.MsgJson);
            Environment.Exit(1);
        }
        RunPBar.Visible = false;
            
        // Parse songdata.json.
        string jsonfile = File.ReadAllText(Global.PathJson);
        Global.Database = JsonConvert.DeserializeObject<SongList>(jsonfile);
            
        // Sort songs by genre.
        Global.Database = DlcHandler.OrganizeByGenre(Global.Database);
        BindingSource source = new();
        source.DataSource = Global.Database.Items;
        DBView.AutoSize = true;
        DBView.DataSource = source;
        DBView.Refresh();
        IntroLabel.Text = Global.WlcmTxt;
    }

    // Handles the Run button click.
    private void RunButton_Click(object sender, EventArgs e)
    {
        int nSlot = 0;
        int nSong = 0;

        // List selected songs.
        List<SongItem> selectedSongs = new();

        // Count selected songs and used slots.
        for (int i = 0; i <= (DBView.Rows.Count - 1); i++)
        {
            if (!Global.Database.Items[i].isChecked) continue;
                
            nSong++;
            nSlot++;
                
            // Add one more slot if the song has an Ura chart.
            if (Global.Database.Items[i].starUra > 0)
            {
                nSlot++;
            }
            selectedSongs.Add(Global.Database.Items[i]);
        }
        string ms1 = Global.MsgSongSl1 + nSong + Global.MsgSongSl2 + nSlot + Global.MsgSongSl3;
        string ms2 = Global.MsgSongSl4 + (Global.Tslot - nSlot) + Global.MsgSongSl3;
            
        if (nSlot == 0) // No song selected.
        {
            MessageBox.Show(Global.MsgSongSl7, Global.TlSongSl);
            return;
        } 
            
        if (nSlot > Global.Tslot)  // More slots selected than the slot limit.
        {
            MessageBox.Show(ms1 + Global.MsgSongSl6, Global.TlSongSl);
            return;
        }
            
        if (nSong > Global.Tsong)  // More songs selected than the song limit.
        {
            MessageBox.Show(ms1 + Global.MsgSongSl8, Global.TlSongSl);
            return;
        }
            
        // Confirm the song selection.
        string message = ms1 + ms2 + Global.MsgSongSl5;
        DialogResult result = MessageBox.Show(message, Global.TlSongSl, MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
            DlcHandler.InitializeDlc(RunPBar,selectedSongs);
    }
        
    // Applies background colors by genre.
    private void DBView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        // Set the background color for each genre.
        foreach (DataGridViewRow row in DBView.Rows)
        {
            SongItem rowObject = (SongItem)row.DataBoundItem;
            row.DefaultCellStyle.BackColor = rowObject.genreColor;
        }
            
        // Put each column into programmatic sort mode.
        foreach (DataGridViewColumn column in DBView.Columns)
            column.SortMode = DataGridViewColumnSortMode.Programmatic;
    }
        
    // Handles the Random button click.
    private void RandomButton_Click(object sender, EventArgs e)
    {
        int rndSlot = 0;
        int rndSong = 0;
        Random rnd = new();
            
        // Clear the current selection.
        ClearDb();
            
        // Repeat until the limit is reached or all songs have been selected.
        while (rndSong < Global.Tsong)
        {
            // Get a random song.
            int idx = rnd.Next(DBView.Rows.Count);
                
            // Select the song only if it is not already selected.
            if (!Global.Database.Items[idx].isChecked)
            {
                Global.Database.Items[idx].isChecked = true;
                rndSlot++;
                rndSong++;
                    
                // Add one more slot if Ura is available.
                if (Global.Database.Items[idx].starUra > 0)
                {
                    rndSlot++;
                        
                    // Disable the song if it would exceed the slot limit.
                    if (rndSlot > Global.Tslot)
                        Global.Database.Items[idx].isChecked = false;
                }
            }
                
            if (rndSong == Global.Database.Items.Count) break;
        }
        DBView.Refresh();
    }
        
    // Handles the Clear button click.
    private void ClearButton_Click(object sender, EventArgs e)
    {
        ClearDb();
        DBView.Refresh();
    }
        
    // Clears all selected songs.
    private void ClearDb()
    {
        for (int i = 0; i <= (DBView.Rows.Count - 1); i++)
            Global.Database.Items[i].isChecked = false;
    }
}
