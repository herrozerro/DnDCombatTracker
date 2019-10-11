using System;
using System.Collections.Generic;
using System.Text;

namespace DnDCombatTracker.Core
{
    public class Party
    {
        public Guid partyId { get; set; }
        public string Name { get; set; }
        public List<Character> Characters { get; set; }
        public string Notes { get; set; }
    }
}
