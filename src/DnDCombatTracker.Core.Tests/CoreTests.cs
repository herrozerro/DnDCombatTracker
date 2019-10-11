using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DnDCombatTracker.Core.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void TestPartySaving()
        {
            File.Delete(string.Join("\\", Directory.GetCurrentDirectory(), "parties.json"));

            Party party = new Party()
            {
                Characters = new List<Character>()
                {
                    new Character("TestChar1", 1, null, null, null, 0, 0, new List<Conditions>(), ""),
                    new Character("TestChar2", 2, null, null, null, 0, 0, new List<Conditions>(), "")
                },
                Name = "Test Party",
                Notes = "",
                partyId = Guid.NewGuid()
            };

            var partymgr = new PartyManagerService();

            partymgr.SaveParty("parties.json", Directory.GetCurrentDirectory(), party);

            var parties = partymgr.GetParties("parties.json", Directory.GetCurrentDirectory());

            Assert.IsTrue(parties.First().partyId == party.partyId);

            //cleanup
            File.Delete(string.Join("\\", Directory.GetCurrentDirectory(), "parties.json"));
        }
    }
}
