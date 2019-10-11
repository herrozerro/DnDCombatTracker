using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DnDCombatTracker.Core
{
    public class PartyManagerService
    {

        public List<Party> GetParties(string filename, string folder)
        {
            var partyStr = Data.FileIO.GetFileString(filename, folder);

            if (partyStr == null)
            {
                return new List<Party>();
            }
            var parties = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Party>>(partyStr);

            return parties;
        }

        public void SaveParty(string filename, string folder, Party party)
        {
            var parties = GetParties(filename, folder);
            
            var PartyToUpdate =  parties.FirstOrDefault(x => x.partyId == party.partyId);

            if (PartyToUpdate == null)
            {
                parties.Add(party);
            }
            else
            {
                PartyToUpdate = party;
            }

            SaveParties(filename, folder, parties);
        }

        public void SaveParties(string filename, string folder, List<Party> parties)
        {
            var partiesString = Newtonsoft.Json.JsonConvert.SerializeObject(parties);

            Data.FileIO.SaveFileString(filename, folder, partiesString);
        }
    }
}
