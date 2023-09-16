using System;
using Multimeter.Scripts.Enum;

namespace Multimeter.Scripts.Models
{
    public class MultimeterModel
    {
        public double Resistance { get; set; }
        public double Power { get; set; }
        public double A => Math.Sqrt(Power / Resistance);
        public double V => Math.Sqrt(Power * Resistance);
        public double Variable => 0.01;

        public Position PreviousPosition = Position.Default;
        public Position PositionOfSwitch = Position.Default;

        public Action SwitchPosition;
    }
}