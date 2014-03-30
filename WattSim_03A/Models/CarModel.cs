using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WattSim_03A.Models
{
    public class CarModel
    {
        #region Members
        string name;            // Car ID.
        double mass;            // Total mass in kg.
        double wheelBase;       // Wheelbase in m.
        double track;           // Average track in m.
        double cogLong;         // Longitudinal location of Cog, in metres from the front axle.
        double cogVert;         // Vertical location of CoG, in metres above the ground.
        double maxTorque;       // Maximum engine torque, at the crankshaft, in Nm.
        double finalDrive;      // Final drive ratio. Takes into account gearing through gearbox, engine output and differential sprocket.

        double tyreRadius;     // Outer radius of the tyre in m.
        double wheelInertia;    // MMoI of wheel and tyre in kgm^2.
        double tyreFricCoeff;   // Friction coefficient between the tyre and the surface.

        double throttlePos;    // Throttle position, 0-100%.

        double xPos;           // Car's X co-ordinate, distance is measured in metres.
        double yPos;           // Car's Y co-ordinate, distance measured in metres.
        double heading;        // Direction the car is heading. Measured in degrees, clockwise, from the X axis.
        double velocity;       // Car's linear velocity in m/s, in the direction the car is heading.
        double acceleration;   // Car's linear acceleration in m/s^2 in the direction the car is heading.

        double crankTorque;    // Engine torque, measured at the crankshaft in Nm.
        double frontReaction;   // Reaction at the front axle in N.
        double rearReaction;    // Reaction at the rear axle in N.
        double kineticEnergy;  // Car's kinetic energy in J.
        #endregion

        #region Properties
        /// <summary>
        /// The car's name or ID.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// The cars total mass in kg.
        /// </summary>
        public double Mass
        {
            get { return mass; }
            set
            {
                mass = value;
                frontReaction = (1 - (cogLong / wheelBase)) * (mass * 9.81);
                rearReaction = (cogLong / (wheelBase)) * (mass * 9.81);
            }
        }
        /// <summary>
        /// The cars wheelbase in m.
        /// </summary>
        public double WheelBase
        {
            get { return wheelBase; }
            set
            {
                wheelBase = value;
                frontReaction = (1 - (cogLong / wheelBase)) * (mass * 9.81);
                rearReaction = (cogLong / (wheelBase)) * (mass * 9.81);
            }
        }
        /// <summary>
        /// The cars average track in m.
        /// </summary>
        public double Track
        {
            get { return track; }
            set { track = value; }
        }
        /// <summary>
        /// Longitudinal location of Cog, in metres from the front axle.
        /// </summary>
        public double CogLong
        {
            get { return cogLong; }
            set
            {
                cogLong = value;
                frontReaction = ((wheelBase - cogLong) / (wheelBase)) * 
                    (mass * 9.81);
                rearReaction = (1 - ((wheelBase - cogLong) / (wheelBase))) * 
                    (mass * 9.81);
            }
        }
        /// <summary>
        /// Vertical location of Cog, in metres from the ground.
        /// </summary>
        public double CogVert
        {
            get { return cogVert; }
            set { cogVert = value; }
        }
        /// <summary>
        /// Max engine torque, in Nm, measure at the crankshaft.
        /// </summary>
        public double MaxTorque
        {
            get { return maxTorque; }
            set { maxTorque = value; }
        }
        /// <summary>
        /// Final drive ratio.
        /// </summary>
        public double FinalDrive
        {
            get { return finalDrive; }
            set { finalDrive = value; }
        }
        /// <summary>
        /// The car's tyre radius in m.
        /// </summary>
        public double TyreRadius
        {
            get { return tyreRadius; }
            set { tyreRadius = value; }
        }
        /// <summary>
        /// The car's wheel and tyre inertia in kgm^2.
        /// </summary>
        public double WheelInertia
        {
            get { return wheelInertia; }
            set { wheelInertia = value; }
        }
        /// <summary>
        /// Throttle position, 0-100%.
        /// </summary>
        public double ThrottlePos
        {
            get { return throttlePos; }
            set 
            { 
                throttlePos = value;
                crankTorque = maxTorque * throttlePos;
            }
        }
        /// <summary>
        /// Car's X co-ordinate, distance is measured in metres.
        /// </summary>
        public double XPos
        {
            get { return xPos; }
            set { xPos = value; }
        }
        /// <summary>
        /// Car's Y co-ordinate, distance is measured in metres.
        /// </summary>
        public double YPos
        {
            get { return yPos; }
            set { yPos = value; }
        }
        /// <summary>
        /// Direction the car is heading. Measured in degrees, clockwise, from the X axis.
        /// </summary>
        public double Heading
        {
            get { return heading; }
            set { heading = value; }
        }
        /// <summary>
        /// The car's current velovity in m/s.
        /// </summary>
        public double Velocity
        {
            get { return velocity; }
            set
            {
                velocity = value;
                //crankRPM = (velocity / (1 / finalDrive)) / tyreRadius * 60 / (2 * Math.PI);
                kineticEnergy = 0.5 * mass * velocity * velocity;       //  KE = (mv^2)/2
            }
        }
        /// <summary>
        /// The cars current acceleration in m/s^2.
        /// </summary>
        public double Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }
        /// <summary>
        /// Engine speed in revolutoins per minute.
        /// </summary>
        //public double CrankRPM
        //{
        //    get { return crankRPM; }
        //    set { crankRPM = value; }
        //}
        /// <summary>
        /// Engine torque, measure at the crankshaft in Nm.
        /// </summary>
        public double CrankTorque
        {
            get { return crankTorque; }
            set { crankTorque = value; }
        }
        /// <summary>
        /// Engine Power, in Watts, measure at the crankshaft.
        /// </summary>
        //public double CrankPower
        //{
        //    get { return crankPower; }
        //    set { crankPower = value; }
        //}
        /// <summary>
        /// The reaction at the front axle in N.
        /// </summary>
        public double FrontReaction
        {
            get { return frontReaction; }
            set { frontReaction = value; }
        }
        /// <summary>
        /// The reaction at the rear axle in N.
        /// </summary>
        public double RearReaction
        {
            get { return rearReaction; }
            set { rearReaction = value; }
        }
        /// <summary>
        /// The car's current kinetic energy in J.
        /// </summary>
        public double KineticEnergy
        {
            get { return kineticEnergy; }
            set { kineticEnergy = value; }
        }
        #endregion
    }
}
