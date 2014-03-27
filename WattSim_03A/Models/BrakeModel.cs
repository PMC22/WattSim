﻿using System;
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
        #region Disc members
        // The outer diameter of the disc in metres. 
        double outerDiameter;
        // The inner diameter of the disc in metres.
        double innerDiameter;
        // Thicnkess of the disc in metres.
        double thickness;
        // Density of brake disc in kg/m^3.     
        double density;
        // SHC in J/kgK.
        double specificHeatCapacity;
        // Tensile modulus in N/m^2.
        double tensileModulus;
        // Brake disc total surface area in m^2.
        double surfaceArea;
        // Brake disc volume in m^3.
        double volume;
        // Brake disc mass in kg.  
        double brakeMass;
        // Brake disc temperature in Kelvin.
        double discTemperature;
        // Angular velocity of the disc in rad/sec.
        double angularVelocity;
        #endregion
        #region System members
        // Brake pedal position, 0-100%.
        double brakePos;
        // Force on brake pedal, N.
        double brakePedalForce;
        // Lever ratio between force applied to pedal and force into 
        // the master cylinders.
        double brakePedalRatio;
        // Force on master cylinder actuators (N).
        double masterCylinderForce;
        // Force on front master cylinder actuator (N).
        double frontCylinderForce;
        // Force on rear master cylinder actuator (N).
        double rearCylinderForce;
        // Area of master cylinder piston (m^2).
        double masterCylinderArea;
        // Area of caliper piston (m^2).
        double calliperPistonArea;
        // Pressure in front braking system (Pa).
        double frontBrakeSysPressure;
        // Pressure in rear braking system (Pa).
        double rearBrakeSysPressure;
        // Number of pistons in front callipers.
        double numPistonsFront;
        // Number of pistons in rear callipers.
        double numPistonsRear;
        // Total force on front caliper pistons (N).
        double frontCalliperForce;
        // Total force on rear caliper pistons (N).
        double rearCalliperForce;
        // Coefficient of friction between discs and pads.
        double discPadFriction;
        // Force on front discs due to friction (N).
        double frontBrakeForce;
        // Force on rear discs due to friction (N).
        double rearBrakeForce;
        // Torque on front brake rotors (Nm).
        double frontBrakeTorque;
        // Torque on rear brake rotors (Nm).
        double rearBrakeTorque;
        #endregion
        #endregion

        #region Properties
        #region Disc properties
        /// <summary>
        /// The brake disc's outer diameter in m.
        /// </summary>
        public double OuterDiameter
        {
            get { return outerDiameter; }
            set
            {
                outerDiameter = value;
                surfaceArea = 2 * (((Math.PI * outerDiameter * outerDiameter) 
                    / 4) - ((Math.PI * innerDiameter * innerDiameter) / 4)) 
                    + (Math.PI * outerDiameter * thickness) 
                    + (Math.PI * innerDiameter * thickness);
                volume = ((((Math.PI * outerDiameter * outerDiameter) / 4) 
                    - ((Math.PI * innerDiameter * innerDiameter) / 4)) 
                    * thickness);
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
                surfaceArea = 2 * (((Math.PI * outerDiameter * outerDiameter) 
                    / 4) - ((Math.PI * innerDiameter * innerDiameter) / 4)) 
                    + (Math.PI * outerDiameter * thickness) + (Math.PI 
                    * innerDiameter * thickness);
                volume = ((((Math.PI * outerDiameter * outerDiameter) / 4) 
                    - ((Math.PI * innerDiameter * innerDiameter) / 4)) 
                    * thickness);
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
                surfaceArea = 2 * (((Math.PI * outerDiameter * outerDiameter) 
                    / 4) - ((Math.PI * innerDiameter * innerDiameter) / 4)) 
                    + (Math.PI * outerDiameter * thickness) 
                    + (Math.PI * innerDiameter * thickness);
                volume = ((((Math.PI * outerDiameter * outerDiameter) / 4) 
                    - ((Math.PI * innerDiameter * innerDiameter) / 4)) 
                    * thickness);
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
        #region System properties
        /// <summary>
        /// Brake pedal position, 0-100%.
        /// </summary>
        public double BrakePos
        {
            get { return brakePos; }
            set { brakePos = value; }
        }
        /// <summary>
        /// Brake pedal force in N.
        /// </summary>
        public double BrakePedalForce
        {
            get { return brakePedalForce; }
            set { brakePedalForce = value; }
        }
        /// <summary>
        /// Brake pedal lever ratio.
        /// </summary>
        public double BrakePedalRatio
        {
            get { return brakePedalRatio; }
            set { brakePedalRatio = value; }
        }
        /// <summary>
        /// Force on master cylinder actuators (N).
        /// </summary>
        public double MasterCylinderForce
        {
            get { return masterCylinderForce; }
            set { masterCylinderForce = value; }
        }
        /// <summary>
        /// Force on front master cylinder actuator (N).
        /// </summary>
        public double FrontCylinderForce
        {
            get { return frontCylinderForce; }
            set { frontCylinderForce = value; }
        }
        /// <summary>
        /// Force on rear master cylinder actuator (N).
        /// </summary>
        public double RearCylinderForce
        {
            get { return rearCylinderForce; }
            set { rearCylinderForce = value; }
        }
        /// <summary>
        /// Area of master cylinder piston (m^2).
        /// </summary>
        public double MasterCylinderArea
        {
            get { return masterCylinderArea; }
            set { masterCylinderArea = value; }
        }
        /// <summary>
        /// Area of caliper piston (m^2).
        /// </summary>
        public double CalliperPistonArea
        {
            get { return calliperPistonArea; }
            set { calliperPistonArea = value; }
        }
        /// <summary>
        /// Pressure in front braking system (Pa).
        /// </summary>
        public double FrontBrakeSysPressure
        {
            get { return frontBrakeSysPressure; }
            set { frontBrakeSysPressure = value; }
        }
        /// <summary>
        /// Pressure in rear braking system (Pa).
        /// </summary>
        public double RearBrakeSysPressure
        {
            get { return rearBrakeSysPressure; }
            set { rearBrakeSysPressure = value; }
        }
        /// <summary>
        /// Number of pistons in front callipers.
        /// </summary>
        public double NumPistonsFront
        {
            get { return numPistonsFront; }
            set { numPistonsFront = value; }
        }
        /// <summary>
        /// Number of pistons in rear callipers.
        /// </summary>
        public double NumPistonsRear
        {
            get { return numPistonsRear; }
            set { numPistonsRear = value; }
        }
        /// <summary>
        /// Total force on front caliper pistons (N).
        /// </summary>
        public double FrontCalliperForce
        {
            get { return frontCalliperForce; }
            set { frontCalliperForce = value; }
        }
        /// <summary>
        /// Total force on rear caliper pistons (N).
        /// </summary>
        public double RearCalliperForce
        {
            get { return rearCalliperForce; }
            set { rearCalliperForce = value; }
        }
        /// <summary>
        /// Coefficient of friction between discs and pads.
        /// </summary>
        public double DiscPadFriction
        {
            get { return discPadFriction; }
            set { discPadFriction = value; }
        }
        /// <summary>
        /// Force on front discs due to friction (N).
        /// </summary>
        public double FrontBrakeForce
        {
            get { return frontBrakeForce; }
            set { frontBrakeForce = value; }
        }
        /// <summary>
        /// Force on rear discs due to friction (N).
        /// </summary>
        public double RearBrakeForce
        {
            get { return rearBrakeForce; }
            set { rearBrakeForce = value; }
        }
        /// <summary>
        /// Torque on front brake rotors (Nm).
        /// </summary>
        public double FrontBrakeTorque
        {
            get { return frontBrakeTorque; }
            set { frontBrakeTorque = value; }
        }
        /// <summary>
        /// Torque on rear brake rotors (Nm).
        /// </summary>
        public double RearBrakeTorque
        {
            get { return rearBrakeTorque; }
            set { rearBrakeTorque = value; }
        }
        #endregion
        #endregion
    }
}
