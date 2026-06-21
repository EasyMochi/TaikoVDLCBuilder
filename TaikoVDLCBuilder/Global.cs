namespace TaikoVDLCBuilder;

public static class Global
{
    public static SongList Database;
    public static readonly int[] GenreVita = [0, 6, 1, 2, 5, 4, 3];
    public const int Tslot = 395; //Limit of slots that vita can handle
    public const int Tsong = 282; //Limit of songs that repatch(?) can handle
    public const string HexStart = "D3";
    public const int FirstCustomDlcFolderNumber = 112;
    public const ushort FirstCustomInternalSongId = 105;
    public const ushort LastCustomInternalSongId = 0x1F3;
    public const string PathJson = "Data/songdata.json";
    public const string PathDlc = "readdcont";
    public const string PathSongs = "Data/Songs/";
    public const string PathSongDat = "/_data/system/SongInfo.dat";
    public const string PathWay1 = "readdcont/PCSG00551/TAIKOV1SONG";
    public const string PathWay2 = "JH";
    public const string MsgDlc1 = "All done!\nMove readdcont folder to ux0:";
    public const string MsgDlc2 = "readdcont folder is present and will be deleted.";
    public const string MsgDlc3 = " folder is missing.";
    public const string MsgDlc4 = "SongInfo.dat is missing.";
    public const string MsgJson = "songdata.json is missing";
    public const string MsgSongSl1 = "You selected ";
    public const string MsgSongSl2 = " songs, using a total of ";
    public const string MsgSongSl3 = " slots.";
    public const string MsgSongSl4 = "\nYou can use more ";
    public const string MsgSongSl5 = "\nDo you want to proceed?";
    public const string MsgSongSl6 = "\nYou can select only 395 slots.\nRemember: Songs with Ura difficulty take 2 slots.";
    public const string MsgSongSl7 = "No song has been selected.";
    public const string MsgSongSl8 = "\nYou can select only 282 songs.";
    public const string TlDlc1 = "Clear";
    public const string TlDlc2 = "Error";
    public const string TlSongSl = "Attention";
    public const string WlcmTxt = "Taiko no Tatsujin V Version - DLC Builder (1.0.2)\nMade By DespairOfHarmony\n\nThis builder is not compatible with official DLC songs. Other DLC, such as costumes, work normally.\nSelect the songs that you wish to play. You can select up to 282 songs, with 395 slots, each song will take one slot,\nbut songs with Ura difficulty will take one more slot.\nREMEMBER: backup your save if you have older DLC scores, because they may be overlapped.";
}
