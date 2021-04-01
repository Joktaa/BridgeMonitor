using System.Collections.Generic;

namespace BridgeMonitor.Models
{
    public class ListeFermetures {
        public List<Fermeture> FermeturesAVenir { get; set; }
        public List<Fermeture> FermeturesPassees { get; set; }

        public ListeFermetures(List<Fermeture> fav, List<Fermeture> fp){
            this.FermeturesAVenir = fav;
            this.FermeturesPassees = fp;
        }
    }
}