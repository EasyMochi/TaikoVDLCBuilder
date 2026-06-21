using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace TaikoVDLCBuilder;

public class SongList
{
    public List<SongItem> Items;
}

public class SongItem
{
    // List with genre names
    private readonly string[] _gnrNames =
    [
        "J-POP",
        "VOCALOID",
        "Variety",
        "Namco Original",
        "Game Music",
        "Classic",
        "Anime"
    ];
        
    // List with genre colors
    private readonly Color[] _gnrColors =
    [
        Color.SkyBlue,
        Color.LightGray,
        Color.LimeGreen,
        Color.Salmon,
        Color.Plum,
        Color.Khaki,
        Color.SandyBrown
    ];
        
    // List with star names
    private readonly string[] _starNames =
    [
        "--",
        "★1",
        "★2",
        "★3",
        "★4",
        "★5",
        "★6",
        "★7",
        "★8",
        "★9",
        "★10"
    ];
    
    [JsonProperty("isChecked")]
    public bool isChecked { get; set; }
    
    [JsonProperty("name")]
    public string name { get; set; }
        
    [JsonProperty("nameJP")]
    public string nameJp { get; set; }
    
    [JsonProperty("genreNo")]
    public int genreNo { get; set; }
    
    [JsonProperty("genreName")]
    public string genreName
    {
        get
        {
            try
            {
                return _gnrNames[genreNo];
            }
            catch
            {
                return String.Empty;
            }
        }
    }
    
    [JsonProperty("genreColor")]
    public Color genreColor
    {
        get
        {
            try
            {
                return _gnrColors[genreNo];
            }
            catch
            {
                return Color.White;
            }
        }
    }
    
    [JsonProperty("folder")]
    public string folder { get; set; }
    
    [JsonProperty("starEasy")]
    public int starEasy { get; set; }
    
    [JsonProperty("strEasy")]
    public string strEasy
    {
        get
        {
            try
            {
                return _starNames[starEasy];
            }
            catch
            {
                return _starNames[0];
            }
        }
    }
    
    [JsonProperty("starNormal")]
    public int starNormal { get; set; }
    
    [JsonProperty("strNormal")]
    public string strNormal
    {
        get
        {
            try
            {
                return _starNames[starNormal];
            }
            catch
            {
                return _starNames[0];
            }
        }
    }
    
    [JsonProperty("starHard")]
    public int starHard { get; set; }
    
    [JsonProperty("strHard")]
    public string strHard
    {
        get
        {
            try
            {
                return _starNames[starHard];
            }
            catch
            {
                return _starNames[0];
            }
        }
    }
    
    [JsonProperty("starMania")]
    public int starMania { get; set; }
    
    [JsonProperty("strMania")]
    public string strMania
    {
        get
        {
            try
            {
                return _starNames[starMania];
            }
            catch
            {
                return _starNames[0];
            }
        }
    }
    
    [JsonProperty("starUra")]
    public int starUra { get; set; }
    
    [JsonProperty("strUra")]
    public string strUra
    {
        get
        {
            try
            {
                return _starNames[starUra];
            }
            catch
            {
                return _starNames[0];
            }
        }
    }
    
    [JsonProperty("source")]
    public string source { get; set; }
}