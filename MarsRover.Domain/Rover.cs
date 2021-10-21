namespace MarsRover.Domain
{
    public abstract class Rover : IRover
    {
        private string roverName;
        private int xcoordinate;
        private int ycoordinate;
        private char compassDirection;

        public Rover(string RoverName, int XCoordinate, int YCoordinate, char CompassDirection)
        {
            this.roverName = RoverName;
            this.xcoordinate = XCoordinate;
            this.ycoordinate = YCoordinate;
            this.compassDirection = CompassDirection;
        }

        public void Move()
        {
            if (compassDirection == 'N' & ycoordinate != 5)
            {
                this.ycoordinate += 1;
            }
            if (compassDirection == 'S' & ycoordinate != 0)
            {
                this.ycoordinate -= 1;
            }
            if (compassDirection == 'E' & xcoordinate != 5)
            {
                this.xcoordinate += 1;
            }
            if (compassDirection == 'W' & xcoordinate != 0)
            {
                this.xcoordinate -= 1;
            }
        }

        public void SpinLeft()
        {
            if (this.compassDirection == 'N')
            {
                this.compassDirection = 'W';
                return;
            }
            if (compassDirection == 'W')
            {
                this.compassDirection = 'S';
                return;
            }
            if (compassDirection == 'S')
            {
                this.compassDirection = 'E';
                return;
            }
            if (compassDirection == 'E')
            {
                this.compassDirection = 'N';
                return;
            }
        }

        public void SpinRight()
        {
            if (this.compassDirection == 'N')
            {
                this.compassDirection = 'E';
                return;
            }
            if (compassDirection == 'W')
            {
                this.compassDirection = 'N';
                return;
            }
            if (compassDirection == 'S')
            {
                this.compassDirection = 'W';
                return;
            }
            if (compassDirection == 'E')
            {
                this.compassDirection = 'S';
                return;
            }
        }

        public void ProcessInstructions(string Instructions)
        {
            foreach (char instruction in Instructions)
            {
                if (instruction == 'L')
                {
                    SpinLeft();
                }
                if (instruction == 'R')
                {
                    SpinRight();
                }
                if (instruction == 'M')
                {
                    Move();
                }
            }
        }

        public override string ToString()
        {
            return $"Rover {roverName}:  {xcoordinate},{ycoordinate}, {compassDirection}";
        }
    }
}