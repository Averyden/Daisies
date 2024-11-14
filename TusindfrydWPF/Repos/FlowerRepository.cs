using Daisies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TusindfrydWPF.Repos
{
    public class FlowerRepository
    {
        public List<FlowerSort> Flowers { get; set; }
        public FlowerRepository() { Flowers = new List<FlowerSort>(); }

        public void AddFlower(FlowerSort flower)
        {
            Flowers.Add(flower);
        }

        public void SendToProd(FlowerSort flower)
        {
            
        }

    }
}
