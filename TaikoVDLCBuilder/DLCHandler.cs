using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace TaikoVDLCBuilder;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public static class DlcHandler
{
    // Initializes DLC conversion.
    public static void InitializeDlc(ProgressBar progress, List<SongItem> selectedSongs)
    {
        // Initialize the progress bar.
        progress.Visible = true;
        progress.Value = 1;
        progress.Minimum = 1;
            
        // Delete the existing reAddcont folder if it is present.
        if (Directory.Exists(Global.PathDlc))
        {
            MessageBox.Show(Global.MsgDlc2,Global.TlSongSl);
            DeleteDirectory(Global.PathDlc);
        }

        ushort nextSongId = Global.FirstCustomInternalSongId;
        int folderId = Global.FirstCustomDlcFolderNumber;
        progress.Maximum = selectedSongs.Count;
        progress.Step = 1;

        try
        {
            for (int i = 0; i <= (selectedSongs.Count - 1); i++)
            {
                bool hasUra = selectedSongs[i].starUra > 0;
                nextSongId = GetNextAvailableSongId(nextSongId, hasUra);

                string strId = folderId.ToString(Global.HexStart);
                BuildDlc(selectedSongs[i], nextSongId, strId);

                nextSongId += (ushort)(hasUra ? 2 : 1);
                folderId++;
                progress.PerformStep();
            }
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, Global.TlDlc2);
            progress.Visible = false;
            return;
        }

        MessageBox.Show(Global.MsgDlc1, Global.TlDlc1);
        progress.Visible = false;
    }
        
    // Copies DLC files to the output folder.
    private static void BuildDlc(SongItem song, uint id, string folderid)
    {
        string sourcePath = Global.PathSongs + song.folder;
        // Check whether the source folder exists.
        if (!Directory.Exists(sourcePath))
        {
            MessageBox.Show(song.folder + Global.MsgDlc3, Global.TlDlc2);
            return;
        }
        
        string destinationPath = Global.PathWay1 + folderid + Global.PathWay2;
        Directory.CreateDirectory(destinationPath);

        // Create the directory tree.
        foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationPath));

        // Copy all files and replace existing files with the same name.
        foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            File.Copy(newPath, newPath.Replace(sourcePath, destinationPath), true);

        // Patch the unique internal song ID.
        string songInfoPath = destinationPath + Global.PathSongDat;
            
        // Check whether SongInfo.dat exists.
        if (!File.Exists(songInfoPath))
        {
            MessageBox.Show(Global.MsgDlc4, Global.TlDlc2);
            return;
        }
        // Patch SongInfo.dat.
        InjectId(id, song.starUra, songInfoPath);
    }
        
    // Patches the assigned internal ID into SongInfo.dat.
    private static void InjectId(uint id, int starUra, string path)
    {
        const int idPos = 60; // ID position: 0x3C
        const int uraPos = 124; // Ura ID position: 0x7C
        byte[] idBytes = BitConverter.GetBytes(id);
            
        using FileStream stream = new(path, FileMode.Open, FileAccess.ReadWrite);
            
        // Write the normal chart ID.
        stream.Position = idPos;
        stream.WriteByte(idBytes[0]);
        stream.Position = idPos + 1;
        stream.WriteByte(idBytes[1]);
            
        // Stop here if the song does not have a Ura chart.
        if (starUra <= 0) return;
        byte[] idUraBytes = BitConverter.GetBytes(id + 1);
            
        // Write the Ura chart ID.
        stream.Position = uraPos;
        stream.WriteByte(idUraBytes[0]);
        stream.Position = uraPos + 1;
        stream.WriteByte(idUraBytes[1]);
                
        // Write the linked normal chart ID after the Ura ID.
        stream.Position = uraPos + 2;
        stream.WriteByte(idBytes[0]);
        stream.Position = uraPos + 3;
        stream.WriteByte(idBytes[1]);
    }

    private static ushort GetNextAvailableSongId(ushort startId, bool needsUraPair)
    {
        for (int id = startId; id <= Global.LastCustomInternalSongId; id++)
        {
            ushort normalId = (ushort)id;
            if (IsReservedInternalSongId(normalId))
                continue;

            if (!needsUraPair)
                return normalId;

            if (id >= Global.LastCustomInternalSongId)
                break;

            ushort uraId = (ushort)(id + 1);
            if (!IsReservedInternalSongId(uraId))
                return normalId;
        }

        throw new InvalidOperationException("No free internal SongInfo IDs left in the safe custom range.");
    }

    private static bool IsReservedInternalSongId(ushort id)
    {
        // Base game songs.
        if (id is >= 1 and <= 77)
            return true;

        if (id is >= 79 and <= 104)
            return true;

        // Official DLC songs. The official DLC scan found IDs from 200 to 319.
        // Reserve the whole block, including gaps, to avoid DLC-zone collisions.
        if (id is >= 200 and <= 319)
            return true;

        // Base game story, special, and test entries.
        if (id is >= 1000 and <= 1184)
            return true;

        return id == 2000;
    }
        
    // Deletes a directory recursively.
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
        
    // Sorts songs by genre.
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
