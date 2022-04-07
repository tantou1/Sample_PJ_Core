using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample_PJ_Core.Models.Editdata
{
    [Table("m_j_tantousha")]
    public class Tantousha
    {
        public string cTANTOUSHA { get; set; }

        public string sTANTOUSHA { get; set; }
        //自社担当者chanyamin

    }
}
