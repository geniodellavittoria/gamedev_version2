using System;
namespace Assets.Scripts
{

    public enum Direction
    {
        Left,
        Right,
        Up,
        Down


    };



    public static class DirectionMethods
    {

        public static Direction ReverseDirection(Direction dir)
        {
            if (dir == Direction.Left)
                dir = Direction.Right;
            else if (dir == Direction.Right)
                dir = Direction.Left;
            else if (dir == Direction.Up)
                dir = Direction.Down;
            else if (dir == Direction.Down)
                dir = Direction.Up;

            return dir;
        }
    }

}
