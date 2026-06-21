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
    private const string VitaDlcSource = "VITADLC";

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
        DBView.AutoSize = true;
        RefreshSongList();
        
        // Update view.
        DBView.CurrentCellDirtyStateChanged += DBView_CurrentCellDirtyStateChanged;
        DBView.CellValueChanged += DBView_CellValueChanged;
        
        UpdateSelectedCounter();
        
        IntroLabel.Text = Global.WlcmTxt;
    }

    // Handles the Run button click.
    private void RunButton_Click(object sender, EventArgs e)
    {
        int nSlot = 0;
        int nSong = 0;

        // List selected songs.
        List<SongItem> selectedSongs = new();

        // Count selected songs and used slots from the currently visible list.
        foreach (DataGridViewRow row in DBView.Rows)
        {
            if (row.DataBoundItem is not SongItem song || !song.isChecked) continue;
                
            nSong++;
            nSlot++;
                
            // Add one more slot if the song has an Ura chart.
            if (song.starUra > 0)
            {
                nSlot++;
            }
            selectedSongs.Add(song);
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
            if (row.DataBoundItem is not SongItem rowObject) continue;
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
        List<SongItem> visibleSongs = GetVisibleSongs();
            
        // Clear the current selection.
        ClearDb();
            
        // Repeat until the limit is reached or all visible songs have been selected.
        while (rndSong < Global.Tsong && rndSong < visibleSongs.Count)
        {
            // Get a random visible song.
            int idx = rnd.Next(visibleSongs.Count);
            SongItem song = visibleSongs[idx];
                
            // Select the song only if it is not already selected.
            if (!song.isChecked)
            {
                song.isChecked = true;
                rndSlot++;
                rndSong++;
                    
                // Add one more slot if Ura is available.
                if (song.starUra > 0)
                {
                    rndSlot++;
                        
                    // Disable the song if it would exceed the slot limit.
                    if (rndSlot > Global.Tslot)
                        song.isChecked = false;
                }
            }
        }
        DBView.Refresh();
        UpdateSelectedCounter();
    }
        
    // Handles the Clear button click.
    private void ClearButton_Click(object sender, EventArgs e)
    {
        ClearDb();
        DBView.Refresh();
        UpdateSelectedCounter();
    }
        
    // Clears all selected songs.
    private void ClearDb()
    {
        foreach (SongItem song in Global.Database.Items)
            song.isChecked = false;
    }

    // Shows or hides official Vita DLC songs.
    private void includeVitaDlc_CheckedChanged(object sender, EventArgs e)
    {
        ClearHiddenVitaDlcSelection();
        RefreshSongList();
    }

    private void RefreshSongList()
    {
        songItemBindingSource.DataSource = GetVisibleSongs();
        DBView.DataSource = songItemBindingSource;
        DBView.Refresh();
        UpdateSelectedCounter();
    }

    private List<SongItem> GetVisibleSongs()
    {
        List<SongItem> songs = new();

        foreach (SongItem song in Global.Database.Items)
        {
            if (!includeVitaDlc.Checked && IsVitaDlc(song))
                continue;

            songs.Add(song);
        }

        return songs;
    }

    private void ClearHiddenVitaDlcSelection()
    {
        if (includeVitaDlc.Checked)
            return;

        foreach (SongItem song in Global.Database.Items)
        {
            if (IsVitaDlc(song))
                song.isChecked = false;
        }
    }

    private static bool IsVitaDlc(SongItem song)
    {
        return string.Equals(song.source, VitaDlcSource, StringComparison.OrdinalIgnoreCase);
    }
    
    private void DBView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (DBView.IsCurrentCellDirty)
            DBView.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void DBView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        UpdateSelectedCounter();
    }

    private void UpdateSelectedCounter()
    {
        int selectedSongs = 0;
        int selectedSlots = 0;

        foreach (SongItem song in GetVisibleSongs())
        {
            if (!song.isChecked)
                continue;

            selectedSongs++;
            selectedSlots++;

            if (song.starUra > 0)
                selectedSlots++;
        }

        selectedCounterLabel.Text = $"Selected: {selectedSongs} / Slots: {selectedSlots}";
    }
}
