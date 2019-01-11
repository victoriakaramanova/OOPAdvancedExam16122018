namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Miscellaneous.Contracts;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Vehicles;
    using TheTankGame.Entities.Vehicles.Contracts;

    [TestFixture]
    public class BaseVehicleTests
    {
        private  IAssembler assembler;
        private  IList<string> orderedParts;
        List<IPart> parts = new List<IPart>();

        [Test]
        public void CheckModelOnCreation()
        {
            assembler = new VehicleAssembler();
            IVehicle vehicle = new Revenger("AAAAA", 50, 200.00m, 100, 200, 60, assembler);

        }

        [Test]
        public void CheckAddArsenalPartToAssembler()
        {
            assembler = new VehicleAssembler();
            IAttackModifyingPart arsenalPart = new ArsenalPart("arsenalModel", 5.3,20.45m, 32);
            orderedParts = new List<string>();
            this.assembler.AddArsenalPart(arsenalPart);
            this.orderedParts.Add(arsenalPart.Model);

            Assert.That(orderedParts.Count == 1);
            Assert.That(assembler.ArsenalParts.Count == 1);

        }

        [Test]
        public void CheckAddShellPartToAssembler()
        {
            assembler = new VehicleAssembler();
            IDefenseModifyingPart shellPart = new ShellPart("shellModel", 10, 2000m, 700);
            orderedParts = new List<string>();
            this.assembler.AddShellPart(shellPart);
            this.orderedParts.Add(shellPart.Model);

            Assert.That(orderedParts.Count == 1);
            Assert.That(assembler.ShellParts.Count == 1);
        }

        [Test]
        public void CheckAddEndurancePartToAssembler()
        {
            assembler = new VehicleAssembler();
            IHitPointsModifyingPart endurancePart = new EndurancePart("enduranceModel", 100, 700m, 30);
            orderedParts = new List<string>();
            this.assembler.AddEndurancePart(endurancePart);
            this.orderedParts.Add(endurancePart.Model);

            Assert.That(orderedParts.Count ==1);
            Assert.That(assembler.EnduranceParts.Count == 1);
        }

        [Test]
        public void CheckPartsAddition()
        {
            IVehicle vehicle = new Vanguard("KillingMachine", 123, 3446m, 9000, 876, 56, new VehicleAssembler());

            vehicle.AddArsenalPart(new ArsenalPart("arsenalModel", 5.3, 20.45m, 32));
            vehicle.AddShellPart(new ShellPart("shellModel", 10, 2000m, 700));
            vehicle.AddEndurancePart(new EndurancePart("enduranceModel", 100, 700m, 30));

            Assert.That(vehicle.Parts.Count().Equals(3));
        }

        [Test]
        public void CheckToString()
        {
            IVehicle vehicle = new Vanguard("KillingMachine", 123, 3446m, 9000, 876, 56, new VehicleAssembler());

            vehicle.AddArsenalPart(new ArsenalPart("arsenalModel", 5.3, 20.45m, 32));
            vehicle.AddShellPart(new ShellPart("shellModel", 10, 2000m, 700));
            vehicle.AddEndurancePart(new EndurancePart("enduranceModel", 100, 700m, 30));
            
            var actual = vehicle.ToString();
            var expected = "Vanguard - KillingMachine\r\nTotal Weight: 238.300\r\nTotal Price: 6166.450\r\nAttack: 9032\r\nDefense: 1576\r\nHitPoints: 86\r\nParts: arsenalModel, shellModel, enduranceModel";
            Assert.AreEqual(expected, actual);
        }
    }
}