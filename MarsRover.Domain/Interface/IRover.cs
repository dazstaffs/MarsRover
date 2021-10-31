namespace MarsRover.Domain
{
    public interface IRover
    {
        void Move();
        void ProcessInstructions(string Instructions);
        void SpinLeft();
        void SpinRight();
    }
}