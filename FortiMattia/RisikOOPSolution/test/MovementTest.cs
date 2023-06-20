using RisikOOPSolution.model;

namespace RisikOOPSolution.test
{
    [TestClass]
    public class MovementTest
    {
        private static readonly int INITIAL_TROOPS = 10;
        private static readonly int VALID_TROOPS = 5;
        private static readonly int INVALID_TROOPS = 11;
        private static readonly string SOURCE_TERRITORY_NAME = "Scandinavia";
        private static readonly string DESTINATION_TERRITORY_NAME = "Iceland";
        readonly Territory territory1 = new(SOURCE_TERRITORY_NAME, INITIAL_TROOPS);
        readonly Territory territory2 = new(DESTINATION_TERRITORY_NAME, INITIAL_TROOPS);

        [TestMethod]
        public void TestTerritoryCreation()
        {
            Assert.IsNotNull(territory1);
            Assert.IsNotNull(territory2);
            Assert.IsTrue(territory1.GetName() == SOURCE_TERRITORY_NAME);
            Assert.IsTrue(territory2.GetName() == DESTINATION_TERRITORY_NAME);
            Assert.IsTrue(territory1.GetTroops() == INITIAL_TROOPS);
            Assert.IsTrue(territory2.GetTroops() == INITIAL_TROOPS);
        }

        [TestMethod]
        public void TestMovementValid()
        {
            Movement movement = new(territory1, territory2);
            Assert.IsTrue(movement.IsMovementValid(VALID_TROOPS));
            Assert.IsFalse(movement.IsMovementValid(INVALID_TROOPS));
        }

        [TestMethod]
        public void TestMove()
        {
            Movement movement = new(territory1, territory2);
            movement.Move(VALID_TROOPS);
            Assert.IsTrue(movement.GetSourceTerritory().GetTroops() == INITIAL_TROOPS - VALID_TROOPS);
            Assert.IsTrue(movement.GetDestinationTerritory().GetTroops() == INITIAL_TROOPS + VALID_TROOPS);
            movement = new(territory2, territory1);
            movement.Move(VALID_TROOPS);
            Assert.IsTrue(movement.GetSourceTerritory().GetTroops() == INITIAL_TROOPS - VALID_TROOPS);
            Assert.IsTrue(movement.GetDestinationTerritory().GetTroops() == INITIAL_TROOPS + VALID_TROOPS);
        }
    }
}
