using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace TaikoVDLCBuilder;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public static class DlcHandler
{
    //Function to initialize conversion
    public static void InitializeDlc(ProgressBar progress, List<SongItem> selectedSongs)
    {
        // Initialize progress bar
        progress.Visible = true;
        progress.Value = 1;
        progress.Minimum = 1;
            
        // Check if reAddcont exist and delete
        if (Directory.Exists(Global.PathDlc))
        {
            MessageBox.Show(Global.MsgDlc2,Global.TlSongSl);
            DeleteDirectory(Global.PathDlc);
        }
        uint uniqueId = 105;
        int folderId = 1;
        progress.Maximum = selectedSongs.Count;
        progress.Step = 1;
        for (int i = 0; i <= (selectedSongs.Count - 1); i++)
        {
            string strId = folderId.ToString(Global.HexStart);
            BuildDlc(selectedSongs[i], uniqueId, strId);
            uniqueId++;
            if (selectedSongs[i].starUra > 0) //Songs with Ura takes 2 slots
                uniqueId++;
            folderId++;
            progress.PerformStep();
        }
        MessageBox.Show(Global.MsgDlc1, Global.TlDlc1);
        progress.Visible = false;
    }
        
    //Function to copy DLC files to output
    private static void BuildDlc(SongItem song, uint id, string folderid)
    {
        string sourcePath = Global.PathSongs + song.folder;
        //Check if folder exist
        if (!Directory.Exists(sourcePath))
        {
            MessageBox.Show(song.folder + Global.MsgDlc3, Global.TlDlc2);
            return;
        }
        string destinationPath = Global.PathWay1 + folderid + Global.PathWay2;
        Directory.CreateDirectory(destinationPath);

        //Now create all the directories
        foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationPath));

        //Copy all the files & Replaces any files with the same name
        foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            File.Copy(newPath, newPath.Replace(sourcePath, destinationPath), true);

        //Correct unique ID
        string songInfoPath = destinationPath + Global.PathSongDat;
            
        //Check if file exist
        if (!File.Exists(songInfoPath))
        {
            MessageBox.Show(Global.MsgDlc4, Global.TlDlc2);
            return;
        }
        //Inject ID function
        InjectId(id, song.starUra, songInfoPath);
    }
        
    //Function to inject unique ID into SongInfo.dat
    private static void InjectId(uint id, int starUra, string path)
    {
        const int idPos = 60; //ID Position: 0x3C
        const int uraPos = 124; //Ura ID Position: 0x7C
        byte[] idBytes = BitConverter.GetBytes(id);
            
        using FileStream stream = new(path, FileMode.Open, FileAccess.ReadWrite);
            
        // inject ID into SongInfo.dat
        stream.Position = idPos;
        stream.WriteByte(idBytes[0]);
        stream.Position = idPos + 1;
        stream.WriteByte(idBytes[1]);
            
        // Check if Ura exist in song
        if (starUra <= 0) return;
        byte[] idUraBytes = BitConverter.GetBytes(id + 1);
            
        // inject ura ID into SongInfo.dat
        stream.Position = uraPos;
        stream.WriteByte(idUraBytes[0]);
        stream.Position = uraPos + 1;
        stream.WriteByte(idUraBytes[1]);
                
        // repeat normal ID after Ura
        stream.Position = uraPos + 2;
        stream.WriteByte(idBytes[0]);
        stream.Position = uraPos + 3;
        stream.WriteByte(idBytes[1]);
    }
        
    //Directory Deleter
    private static void DeleteDirectory(string targetDir)
    {
        string[] files = Directory.GetFiles(targetDir);
        string[] dirs = Directory.GetDirectories(targetDir);

        foreach (string file in files)
        {
            File.SetAttributes(file, FileAttributes.Normal);
            File.Delete(file);
        }

        foreach (string dir in dirs)
            DeleteDirectory(dir);

        Directory.Delete(targetDir, false);
    }
        
    //Function to sort by genre
    public static SongList OrganizeByGenre(SongList data)
    {
        List<SongItem> organized = new();
        for (int i = 0; i <= 6; i++)
        {
            for (int j = 0; j <= (data.Items.Count - 1); j++)
            {
                if (data.Items[j].genreNo == Global.GenreVita[i])
                    organized.Add(data.Items[j]);
            }
        }
        data.Items = organized;
        return data;
    }
}