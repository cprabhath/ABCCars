using System;
using System.Collections.Generic;
using System.Drawing;

namespace ABCCars.Utils
{
    public class CustomersList
    {
        public int Id { get; set; }
        public Image image { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Status { get; set; }
    }
}
