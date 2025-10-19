using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_6
{
    /// <summary>
    /// Class to create a circle
    /// </summary>
public class Circle
    {
        private static int _nextId = 1;
        private double _radius;

        public int Id { get; private set; }

        public double Radius
        {
            get => _radius;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Radius cannot be negative");
                }
                else
                {
                    _radius = value;
                }
            }
        }

        public Circle(double radius)
        {
            Id = _nextId;
            _nextId++;
            Radius = radius;
        }

        public Circle()
        {
            Id = _nextId;
            _nextId++;
            Radius = 1;
        }
        /// <summary>
        /// Method calculates area
        /// </summary>
        /// <returns> area </returns>
        public double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
        /// <summary>
        /// Method calculates the circumferance
        /// </summary>
        /// <returns> circumferance </returns>
        public double CalculateCircumference()
        {
            return 2 * Math.PI * Radius;
        }
        
    }
}
