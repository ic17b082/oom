using System;
using NUnit.Framework;
using Task4;

namespace Task4
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CanCreateKundendaten()
        {
            var x = new Kundendaten("Max Mustermann", "Musterweg 15", 1);
            Assert.IsTrue(x.KName == "Max Mustermann");
            Assert.IsTrue(x.KAdresse == "Musterweg 15");
            Assert.IsTrue(x.Kundennummer == 1);
        }

        [Test]
        public void CanCreateMitarbeiter()
        {
            var x = new Mitarbeiter("Karl Klumpat", "Forstgasse 27", "Elektriker", 1);
            Assert.IsTrue(x.MName == "Karl Klumpat");
            Assert.IsTrue(x.MAdresse == "Forstgasse 27");
            Assert.IsTrue(x.Taetigkeit == "Elektriker");
            Assert.IsTrue(x.Dienstnummer == 1);
        }

        [Test]
        public void CannotCreateNegativeNumber()
        {
            Assert.Catch(() =>
            {
                var x = new Kundendaten("Max Mustermann", "Musterweg 15", -1);
            });
        }

        [Test]
        public void CannotCreateWithoutName1()
        {
            Assert.Catch(() =>
            {
                var x = new Mitarbeiter(null, "Forstgasse 27", "Elektriker", 1);
            });
        }

        [Test]
        public void CannotCreateWithoutName2()
        {
            Assert.Catch(() =>
            {
                var x = new Mitarbeiter("", "Forstgasse 27", "Elektriker", 1);
            });
        }

        [Test]
        public void CanChangeKundennummer()
        {
            var x = new Kundendaten("Max Mustermann", "Musterweg 15", 1);
            Assert.IsTrue(x.Kundennummer == 1);
            x.neueNummer(66);
            Assert.IsTrue(x.Kundennummer == 66);
        }

        [Test]
        public void CannotChangeNegativeNumber()
        {
            Assert.Catch(() =>
            {
                var x = new Kundendaten("Max Mustermann", "Musterweg 15", 1);
                x.neueNummer(-66);
            });
        }

        [Test]
        public void CannotCreateWithoutAddress1()
        {
            Assert.Catch(() =>
            {
                var x = new Mitarbeiter("Karl Klumpat", null, "Elektriker", 1);
            });
        }

        [Test]
        public void CannotCreateWithoutAddress2()
        {
            Assert.Catch(() =>
            {
                var x = new Mitarbeiter("Karl Klumpat", "", "Elektriker", 1);
            });
        }
    }
}
