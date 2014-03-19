using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WattSim_03A.Models
{
    /// <summary>
    /// Model of a brake system.
    /// </summary>
    public class BrakeModel
    {
        #region Members
        double outerDiameter;      // The outer diameter of the disc in metres. 
        double innerDiameter;      // The inner diameter of the disc in metres.
        double thickness;          // Thicnkess of the disc in metres.
        double density;             // Density of brake disc in kg/m^3.    
        double specificHeatCapacity;    // SHC in J/kgK.
        double tensileModulus;      // Tensile modulus in N/m^2.

        double surfaceArea;        // Brake disc total surface area in m^2.
        double volume;             // Brake disc volume in m^3.
        double brakeMass;          // Brake disc mass in kg.
        double discTemperature;    // Brake disc temperature in Kelvin.
        double angularVelocity;
        #endregion

        #region Properties
        /// <summary>
        /// The brake disc's outer diameter in m.
        /// </summary>
        public double OuterDiameter
        {
            get { return outerDiameter; }
            set
            {
                outerDiameter = value;
                surfaceArea = 2 * (((Math.PI * outerDiameter * outerDiameter) / 4) - ((Math.PI * innerDiameter * innerDiameter) / 4)) + (Math.PI * outerDiameter * thickness) + (Math.PI * innerDiameter * thickness);
                volume = ((((Math.PI * outerDiameter * outerDiameter) / 4) - ((Math.PI * innerDiameter * innerDiameter) / 4)) * thickness);
                brakeMass = volume * density;
            }
        }
        /// <summary>
        /// The brake disc's inner diameter in m.
        /// </summary>
        public double InnerDiameter
        {
            get { return innerDiameter; }
            set
            {
                innerDiameter = value;
                surfaceArea = 2 * (((Math.PI * outerDiameter * outerDiameter) / 4) - ((Math.PI * innerDiameter * innerDiameter) / 4)) + (Math.PI * outerDiameter * thickness) + (Math.PI * innerDiameter * thickness);
                volume = ((((Math.PI * outerDiameter * outerDiameter) / 4) - ((Math.PI * innerDiameter * innerDiameter) / 4)) * thickness);
                brakeMass = volume * density;
            }
        }
        /// <summary>
        /// The brake disc's thickness in m.
        /// </summary>
        public double Thickness
        {
            get { return thickness; }
            set
            {
                thickness = value;
                surfaceArea = 2 * (((Math.PI * outerDiameter * outerDiameter) / 4) - ((Math.PI * innerDiameter * innerDiameter) / 4)) + (Math.PI * outerDiameter * thickness) + (Math.PI * innerDiameter * thickness);
                volume = ((((Math.PI * outerDiameter * outerDiameter) / 4) - ((Math.PI * innerDiameter * innerDiameter) / 4)) * thickness);
                brakeMass = volume * density;
            }
        }
        /// <summary>
        /// The brake disc's density in kg/m^3.
        /// </summary>
        public double Density
        {
            get { return density; }
            set
            {
                density = value;
                brakeMass = volume * density;
            }
        }
        /// <summary>
        /// The brake disc's specific heat capacity in J/kgK.
        /// </summary>
        public double SpecificHeatCapacity
        {
            get { return specificHeatCapacity; }
            set { specificHeatCapacity = value; }
        }
        /// <summary>
        /// The brake disc's tensilemodulus in N/m^2.
        /// </summary>
        public double TensileModulus
        {
            get { return tensileModulus; }
            set { tensileModulus = value; }
        }
        /// <summary>
        /// Brake disc total surface area in m^2.
        /// </summary>
        public double SurfaceArea
        {
            get { return surfaceArea; }
            set { surfaceArea = value; }
        }
        /// <summary>
        /// Brake disc volume in m^3.
        /// </summary>
        public double Volume
        {
            get { return volume; }
            set
            {
                volume = value;
            }
        }
        /// <summary>
        /// Brake disc mass in kg.
        /// </summary>
        public double BrakeMass
        {
            get { return brakeMass; }
            set { brakeMass = value; }
        }
        /// <summary>
        /// Brake disc temperature in Kelvin.
        /// </summary>
        public double DiscTemperature
        {
            get { return discTemperature; }
            set { discTemperature = value; }
        }
        public double AngularVelocity
        {
            get { return angularVelocity; }
            set { angularVelocity = value; }
        }
        #endregion
    }
}
