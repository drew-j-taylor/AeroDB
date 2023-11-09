using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroDB.Model
{
    public class Part
    {
        public string PartNumber {  get; set; }
        public string PartDescription { get; set; }
        public string ProgramCode { get; set; }
        public string SourceCode { get; set; }
    }
}
