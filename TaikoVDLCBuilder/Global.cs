namespace TaikoVDLCBuilder;

public static class Global
{
    public static SongList Database;
    
    public static readonly int[] GenreVita = [0, 6, 1, 2, 5, 4, 3];
    
    public const int Tslot = 275; // Collision safe custom SongInfo ID slots.
    public const int Tsong = 275; // Normal-only maximum inside the collision-safe custom range.
    
    public const string HexStart = "D3";
    
    public const int FirstCustomDlcFolderNumber = 112;
    public const ushort FirstCustomInternalSongId = 105;
    public const ushort LastCustomInternalSongId = 0x1F3;
    
    public const string PathJson = "Data/songdata.json";
    
    public const string PathDlc = "reAddcont";
    public const string PathSongs = "Data/Songs/";
    public const string PathSongDat = "/_data/system/SongInfo.dat";
    
    public const string PathWay1 = "reAddcont/PCSG00551/TAIKOV1SONG";
    public const string PathWay2 = "JH";
    
    public const string MsgDlc1 = "All done!\nMove reAddcont folder to ux0:";
    public const string MsgDlc2 = "reAddcont folder is present and will be deleted.";
    public const string MsgDlc3 = " folder is missing.";
    public const string MsgDlc4 = "SongInfo.dat is missing.";
    public const string MsgJson = "songdata.json is missing";
    public const string MsgSongSl1 = "You selected ";
    public const string MsgSongSl2 = " songs, using a total of ";
    public const string MsgSongSl3 = " slots.";
    public const string MsgSongSl4 = "\nYou can use more ";
    public const string MsgSongSl5 = "\nDo you want to proceed?";
    public const string MsgSongSl6 = "\nYou can select only 275 safe custom slots.\nSongs with Ura difficulty will take 2 slots.";
    public const string MsgSongSl7 = "No song has been selected.";
    public const string MsgSongSl8 = "\nYou can select only 275 normal-only songs in the safe custom range.";
    
    public const string TlDlc1 = "Clear";
    public const string TlDlc2 = "Error";
    
    public const string TlSongSl = "Attention";
    
    public const string WlcmTxt = "Taiko no Tatsujin V Version - DLC Builder (2.0.0)\nMade by DespairOfHarmony and EasyMochi\n\nThis builder avoids base game and official DLC SongInfo ID collisions.\nCustom DLC folders start at TAIKOV1SONG112JH. Internal SongInfo IDs use the safe custom range 105-499 while skipping official DLC IDs 200-319.\nYou can select up to 275 safe slots, each song will take one slot,\nbut songs with Ura difficulty will take one more slot.";
}
