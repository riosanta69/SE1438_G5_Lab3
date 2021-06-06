using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE1438_G5_Lab3.DTL
{
    public class Cart
    {

        private int recordID;
        private string cartID;
        private DateTime dateCreated;
        private int albumID;
        private int count;

        public int RecordID { get => recordID; set => recordID = value; }
        public string CartID { get => cartID; set => cartID = value; }
        public DateTime DateCreated { get => dateCreated; set => dateCreated = value; }
        public int AlbumID { get => albumID; set => albumID = value; }
        public int Count { get => count; set => count = value; }
    }
}
