using System;
using System.Collections.Generic;
using System.Drawing;

namespace TaikoVDLCBuilder
{
    public class SongList
    {
        public List<SongItem> Itens;
    }
    public class SongItem
    {
        // List with genre names
        private readonly string[] _gnrNames = {
            "J-POP",
            "VOCALOID",
            "Variety",
            "Namco Original",
            "Game Music",
            "Classic",
            "Anime"
        };
        // List with genre colors
        private readonly Color[] _gnrColors = {
            Color.SkyBlue,
            Color.LightGray,
            Color.LimeGreen,
            Color.Salmon,
            Color.Plum,
            Color.Khaki,
            Color.SandyBrown
        };
        // List with star names
        private readonly string[] _starNames = {
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
        };
        public bool isChecked { get; set; }
        public string name { get; set; }
        public string nameJp { get; set; }
        public int genreNo { get; set; }
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
        public string folder { get; set; }
        public int starEasy { get; set; }
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
        public int starNormal { get; set; }
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
        public int starHard { get; set; }
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
        public int starMania { get; set; }
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
        public int starUra { get; set; }
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
        public string source { get; set; }
    }
}
