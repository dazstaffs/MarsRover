using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover.Domain;

namespace MarsRover.Tests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void GetMarsRoverPosition_Returns_PositionString()
        {
            IRover rover = new Domain.MarsRover("one", 1, 3, 'N');
            Assert.AreEqual("Rover one:  1,3, N", rover.ToString());
        }

        [TestMethod]
        [DataRow(1, 3, 'N', 1, 4)]
        [DataRow(1, 3, 'S', 1, 2)]
        [DataRow(1, 3, 'E', 2, 3)]
        [DataRow(1, 3, 'W', 0, 3)]
        public void MoveRover_Returns_NewPosition(
            int xCoordinate, int yCoordinate, char compassDirection, int expectedXCoordinate, int expectedYCoordinate
        )
        {
            IRover rover = new Domain.MarsRover("one", xCoordinate, yCoordinate, compassDirection);
            rover.Move();
            Assert.AreEqual($"Rover one:  {expectedXCoordinate},{expectedYCoordinate}, {compassDirection}", rover.ToString());
        }

        [TestMethod]
        [DataRow(3, 5, 'N')]
        [DataRow(3, 0, 'S')]
        [DataRow(5, 1, 'E')]
        [DataRow(0, 1, 'W')]
        public void MoveRoverOutsidePlateau_Returns_SamePosition(int xCoordinate, int yCoordinate, char compassDirection)
        {
            IRover rover = new Domain.MarsRover("one", xCoordinate, yCoordinate, compassDirection);
            rover.Move();
            Assert.AreEqual($"Rover one:  {xCoordinate},{yCoordinate}, {compassDirection}", rover.ToString());
        }

        [TestMethod]
        [DataRow('N', 'W')]
        [DataRow('E', 'N')]
        [DataRow('S', 'E')]
        [DataRow('W', 'S')]
        public void SpinRoverLeft_Returns_NewPosition(char currentDirection, char expectedDirection)
        {
            IRover rover = new Domain.MarsRover("one", 1, 1, currentDirection);
            rover.SpinLeft();
            Assert.AreEqual($"Rover one:  1,1, {expectedDirection}", rover.ToString());
        }

        [TestMethod]
        [DataRow('N', 'E')]
        [DataRow('E', 'S')]
        [DataRow('S', 'W')]
        [DataRow('W', 'N')]
        public void SpinRoverRight_Returns_NewPosition(char currentDirection, char expectedDirection)
        {
            IRover rover = new Domain.MarsRover("one", 1, 1, currentDirection);
            rover.SpinRight();
            Assert.AreEqual($"Rover one:  1,1, {expectedDirection}", rover.ToString());
        }

        [TestMethod]
        [DataRow("LMLMLMLMM")]
        public void ProcessRoverOneInstructions_Returns_CorrectPosition(string instructions)
        {
            IRover rover = new Domain.MarsRover("one", 1, 2, 'N');
            rover.ProcessInstructions(instructions);
            Assert.AreEqual($"Rover one:  1,3, N", rover.ToString());
        }

        [TestMethod]
        [DataRow("MMRMMRMRRM")]
        public void ProcessRoverTwoInstructions_Returns_CorrectPosition(string instructions)
        {
            IRover rover = new Domain.MarsRover("two", 3, 3, 'E');
            rover.ProcessInstructions(instructions);
            Assert.AreEqual($"Rover two:  5,1, E", rover.ToString());
        }
    }
}
