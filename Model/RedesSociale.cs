using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Model
{
    public partial class RedesSociale
    {
        public RedesSociale()
        {
            ProvedoresRedesSociales = new HashSet<ProvedoresRedesSociale>();
        }

        public int Id { get; set; }
        public string RedSocial { get; set; }
        public string Placeholder { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<ProvedoresRedesSociale> ProvedoresRedesSociales { get; set; }
    }
}
