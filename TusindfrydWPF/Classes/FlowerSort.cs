using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daisies
{
    public class FlowerSort
    {
        public string Name { get; set; }
        public string PicturePath { get; set; }
        public int ProductionTime { get; set; }
        public int HalfLife { get; set; }
        public int Size { get; set; }

        public FlowerSort(string name, string path, int producTime, int halfLife, int size)
        {
            Name = name;
            PicturePath = path;
            ProductionTime = producTime;
            HalfLife = halfLife;
            Size = size;
        }

        public FlowerSort(string name, int producTime, int halfLife, int size) : this(name, "", producTime, halfLife, size) 
        { 

        }
    }
}
