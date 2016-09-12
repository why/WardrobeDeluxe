using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nullthings
{
    class HabboFurni
    {
        public char Type { get; set; }
        public int Id { get; set; }
        public string Classname { get; set; }
        public int Revision { get; set; }
        public int DefaultDirection { get; set; }
        public int XDimention { get; set; }
        public int YDimention {get;set;}
        public string[] Partcolors { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AdUrl { get; set; }
        public int OfferId { get; set; }
        public bool Buyout { get; set; }
        public int RentOfferId { get; set; }
        public bool RentBuyout { get; set; }
        public string[] CustomParams { get; set; }
        public int SpecialType { get; set; }
        public bool CanStandOn { get; set; }
        public bool CanSitOn { get; set; }
        public bool CanLayOn { get; set; }

        public HabboFurni(char type, int id, string classname, int revision, int defaultDirection, int xDimension, int yDimension, string[] partcolors,
            string name, string description, string adUrl, int offerId, bool buyout, int rentofferId, bool rentBuyout, string[] customParams,
            int specialType, bool canStandOn, bool canSitOn, bool canLayOn)
        {
            Type = type;
            Id = id;
            Classname = classname;
            Revision = revision;
            DefaultDirection = defaultDirection;
            XDimention = xDimension;
            YDimention = yDimension;
            Partcolors = partcolors;
            Name = name;
            Description = description;
            AdUrl = adUrl;
            OfferId = offerId;
            Buyout = buyout;
            RentOfferId = rentofferId;
            RentBuyout = rentBuyout;
            CustomParams = customParams;
            SpecialType = specialType;
            CanSitOn = canSitOn;
            CanStandOn = canStandOn;
            CanLayOn = canLayOn;
        }

        public static List<HabboFurni> Parse(string furnidata)
        {
            var matches = Regex.Matches(furnidata, "\\[\"(\\w{1})\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\",\"(.*?)\"\\]");

        }
    }
}
