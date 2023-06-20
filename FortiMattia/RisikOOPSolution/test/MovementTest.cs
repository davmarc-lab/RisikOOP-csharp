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
        readonly Territory _territory1 = new(SOURCE_TERRITORY_NAME, INITIAL_TROOPS);
        readonly Territory _territory2 = new(DESTINATION_TERRITORY_NAME, INITIAL_TROOPS);

        [TestMethod]
        public void TestTerritoryCreation()
        {
            Assert.IsNotNull(_territory1);
            Assert.IsNotNull(_territory2);
            Assert.IsTrue(_territory1.Name == SOURCE_TERRITORY_NAME);
            Assert.IsTrue(_territory2.Name == DESTINATION_TERRITORY_NAME);
            Assert.IsTrue(_territory1.Troops == INITIAL_TROOPS);
            Assert.IsTrue(_territory2.Troops == INITIAL_TROOPS);
        }

        [TestMethod]
        public void TestMovementValid()
        {
            Movement movement = new(_territory1, _territory2);
            Assert.IsTrue(movement.IsMovementValid(VALID_TROOPS));
            Assert.IsFalse(movement.IsMovementValid(INVALID_TROOPS));
        }

        [TestMethod]
        public void TestMove()
        {
            Movement movement = new(_territory1, _territory2);
            movement.Move(VALID_TROOPS);
            Assert.IsTrue(movement.SourceTerritory.Troops == INITIAL_TROOPS - VALID_TROOPS);
            Assert.IsTrue(movement.DestinationTerritory.Troops == INITIAL_TROOPS + VALID_TROOPS);
            movement = new(_territory2, _territory1);
            movement.Move(VALID_TROOPS);
            Assert.IsTrue(movement.SourceTerritory.Troops == INITIAL_TROOPS - VALID_TROOPS);
            Assert.IsTrue(movement.DestinationTerritory.Troops == INITIAL_TROOPS + VALID_TROOPS);
        }
    }
}
