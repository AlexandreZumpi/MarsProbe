using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProbeCore
{
    class Issuer
    {
        List<Probe> _probes;

        public Issuer(List<Probe> probes)
        {
            _probes = probes;
        }
        internal void IssueCommands()
        {
            
        }
    }
}
