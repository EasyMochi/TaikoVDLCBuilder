using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace TaikoVDLCBuilder
{
    [SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
    public class DlcHandler
    {
        //Function to initialize conversion
        public static void InitializeDlc(ProgressBar progress, List<SongItem> selectedsongs)
        {
            // Initialize progress bar
            progress.Visible = true;
            progress.Value = 1;
            progress.Minimum = 1;
            // Check if readdcont exist and delete
            if (Directory.Exists(Global.PathDlc))
            {
                MessageBox.Show(Global.MsgDlc2,Global.TlSongSl);
                DeleteDirectory(Global.PathDlc);
            }
            uint uniqueId = 105;
            int folderId = 1;
            string strId;
            progress.Maximum = selectedsongs.Count;
            progress.Step = 1;
            for (int i = 0; i <= (selectedsongs.Count - 1); i++)
            {
                strId = folderId.ToString(Global.HexStart);
                BuildDlc(selectedsongs[i], uniqueId, strId);
                uniqueId++;
                if (selectedsongs[i].starUra > 0) //Songs with Ura takes 2 slots
                    uniqueId++;
                folderId++;
                progress.PerformStep();
            }
            MessageBox.Show(Global.MsgDlc1, Global.TlDlc1);
            progress.Visible = false;
        }
        //Function to copy DLC files to output
        static void BuildDlc(SongItem song, uint id, string folderid)
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

            //Now Create all of the directories
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
        static void InjectId(uint id, int starUra, string path)
        {
            int idPos = 60; //ID Position: 0x3C
            int uraPos = 124; //Ura ID Position: 0x7C
            byte[] idbytes = BitConverter.GetBytes(id);
            // inject ID into SongInfo.dat
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                stream.Position = idPos;
                stream.WriteByte(idbytes[0]);
                stream.Position = idPos + 1;
                stream.WriteByte(idbytes[1]);
            }
            // Check if Ura exist in song
            if (starUra > 0)
            {
                byte[] idurabytes = BitConverter.GetBytes(id + 1);
                // inject ura ID into SongInfo.dat
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    stream.Position = uraPos;
                    stream.WriteByte(idurabytes[0]);
                    stream.Position = uraPos + 1;
                    stream.WriteByte(idurabytes[1]);
                    // repeat normal ID after Ura
                    stream.Position = uraPos + 2;
                    stream.WriteByte(idbytes[0]);
                    stream.Position = uraPos + 3;
                    stream.WriteByte(idbytes[1]);
                }
            }
        }
        //Directory Deleter
        public static void DeleteDirectory(string targetDir)
        {
            string[] files = Directory.GetFiles(targetDir);
            string[] dirs = Directory.GetDirectories(targetDir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(targetDir, false);
        }
        //Function to sort by genre
        public static SongList OrganizebyGenre(SongList data)
        {
            List<SongItem> organized = new();
            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j <= (data.Itens.Count - 1); j++)
                {
                    if (data.Itens[j].genreNo == Global.GenreVita[i])
                    {
                        organized.Add(data.Itens[j]);
                    }
                }
            }
            data.Itens = organized;
            return data;
        }
    }
}
