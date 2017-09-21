using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrestlerTests.Models
{
    public class WrestlerModel
    {
        public string id_wrestler { get; set; }
        public string id { get; set; }
        public string lname { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string dob { get; set; }
        public string style { get; set; }
        public string region1 { get; set; }
        public string region2 { get; set; }
        public string fst1 { get; set; }
        public string fst2 { get; set; }
        public TrainerModel trainer1 { get; set; }
        public TrainerModel trainer2 { get; set; }
        public string expires { get; set; }
        public string lictype { get; set; }
        public string card_state { get; set; }
        public string photo { get; set; }   //"photo":"data\/photo\/307.png",
        public List<AttachmentModel> attaches { get; set; }
        public string result { get; set; }

        public bool CompareModels(WrestlerModel current)
        {
            var propertiesOrigin = this.GetType().GetProperties();
            var propertiesCurr = current.GetType().GetProperties();
            var r = true;
            
            foreach (var property in propertiesOrigin)
            {
                var propOriginValue = property.GetValue(this);
                var propCurrValue = property.GetValue(current);

                if (property.Name.Contains("id")) { continue; }

                r &= (propOriginValue == propCurrValue);

                if (!r) break;                    
            }

            return r;

        }


        
    }
    
}
