using System;
namespace Assets.GameObjects.Grounds
{
    public interface IGround
    {
        GroundNature Nature { get; set; }
        int Value { get; set; }
    }
}
