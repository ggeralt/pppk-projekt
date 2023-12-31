﻿using PeopleManager.Utility;
using System.Windows.Media.Imaging;

namespace PeopleManager.Model
{
    public class Person
    {
        public int IDPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public byte[] Picture { get; set; }
        public int JobID { get; set; }
        public BitmapImage Image { get => ImageUtilities.ByteArrayToBitmapImage(Picture); }
    }
}
