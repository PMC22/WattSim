using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Navigation;
using System.IO;
using MicroMvvm;

namespace WattSim_03A.ViewModels
{
    public class SimulationViewModel : ObservableObject
    {
        #region Construction
        /// <summary>
        /// Constructs the default instance of a SimulationViewModel
        /// </summary>
        public SimulationViewModel()
        {
            #region Car Constructor
            _Car = new Models.CarModel
            {
                Name = "HWR-01",
                Mass = 320,
                WheelBase = 1.6,
                Track = 0.6,
                CogLong = 1,
                TyreRadius = 0.508,
                WheelInertia = 7.5,
                MaxTorque = 55,
                //IdlePower = 7457,   // 10 hp = 7457 W
                //MaxPower = 75762,   // 101.6 hp = 75762 W
                //IdleRPM = 2000,
                //MaxRPM = 14000,
                FinalDrive = 11.04,

                ThrottlePos = 0,

                XPos = 0,
                Velocity = 0,
                Acceleration = 0,
            };
            #endregion

            #region Brake Constructor
            _Brake = new Models.BrakeModel
            {
                OuterDiameter = 0.22,
                InnerDiameter = 0.1,
                Thickness = 0.004,
                Density = 1890,
                SpecificHeatCapacity = 350,
                TensileModulus = 210e9,
                DiscTemperature = 300,

                BrakePos = 0,
                BrakePedalRatio = 4.89,
                MasterPistonOuterDiameter = 0.019734,
                MasterPistonInnerDiameter = 0,
                NumPistonsFront = 4,
                NumPistonsRear = 2,
                DiscPadFriction = 0.55,
                BrakePadMeanRadius = 0.1,
            };
            #endregion

            #region View model members
            // Ambient temperature in Kelvin.
            double airTemp = 300;
            // Force at contact patch of front wheels (N).
            double frontBrakeForce = _Brake.FrontBrakeTorque / _Car.TyreRadius;
            // Force at contact patch of rear wheels (N).
            double rearBrakeForce = _Brake.RearBrakeTorque / _Car.TyreRadius;
            // Total force slowing car (N).
            double totalBrakeForce = frontBrakeForce + rearBrakeForce;
            // Final acceleration of car due to braking (m/s^2).
            double accelerationFromBrakes = - totalBrakeForce / _Car.Mass;
            #endregion

            #region Create text file
            Uri assemblyUri = new Uri(System.Reflection.Assembly.
                GetExecutingAssembly().CodeBase);
            LocalDir = Path.GetDirectoryName(assemblyUri.LocalPath);
            StreamWriter SimData = new StreamWriter(LocalDir 
                + "\\SimData.txt");
            String VelString = Velocity.ToString();
            String AccString = Acceleration.ToString();
            String TempString = DiscTemperature.ToString();
            SimData.WriteLine("0:" + VelString + ":" + AccString + ":" 
                + TempString);
            SimData.Close();
            #endregion
        }
        #endregion

        #region Members
        Models.CarModel _Car;
        Models.BrakeModel _Brake;

        public string LocalDir;
        int TimeStamp = 0;
        #endregion

        #region Car Properties
        public Models.CarModel Car
        {
            get { return _Car; }
            set { _Car = value; }
        }
        public string Name
        {
            get { return Car.Name; }
            set
            {
                if (Car.Name != value)
                {
                    Car.Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        public double CarMass
        {
            get { return Car.Mass; }
            set
            {
                if (Car.Mass != value)
                {
                    Car.Mass = value;
                    RaisePropertyChanged("CarMass");
                }
            }
        }
        public double WheelBase
        {
            get { return Car.WheelBase; }
            set
            {
                if (Car.WheelBase != value)
                {
                    Car.WheelBase = value;
                    RaisePropertyChanged("WheelBase");
                }
            }
        }
        public double TyreRadius
        {
            get { return Car.TyreRadius; }
            set
            {
                if (Car.TyreRadius != value)
                {
                    Car.TyreRadius = value;
                    RaisePropertyChanged("TyreRadius");
                }
            }
        }
        public double WheelInertia
        {
            get { return Car.WheelInertia; }
            set
            {
                if (Car.WheelInertia != value)
                {
                    Car.WheelInertia = value;
                    RaisePropertyChanged("WheelInertia");
                }
            }
        }
        public double ThrottlePos
        {
            get { return Car.ThrottlePos; }
            set
            {
                if (Car.ThrottlePos != value)
                {
                    Car.ThrottlePos = value;
                    RaisePropertyChanged("ThrottlePos");
                    RaisePropertyChanged("CrankTorque");
                    RaisePropertyChanged("Acceleration");
                }
            }
        }
        public double CogLong
        {
            get { return Car.CogLong; }
            set
            {
                if (Car.CogLong != value)
                {
                    Car.CogLong = value;
                    RaisePropertyChanged("CogLong");
                }
            }
        }
        //public double CrankRPM
        //{
        //    get { return Car.CrankRPM; }
        //    set
        //    {
        //        if (Car.CrankRPM != value)
        //        {
        //            Car.CrankRPM = value;
        //            RaisePropertyChanged("CrankRPM");
        //        }
        //    }
        //}
        //public double IdlePower
        //{
        //    get { return Car.IdlePower; }
        //    set
        //    {
        //        if (Car.IdlePower != value)
        //        {
        //            Car.IdlePower = value;
        //            RaisePropertyChanged("IdlePower");
        //        }
        //    }
        //}
        //public double IdleRPM
        //{
        //    get { return Car.IdleRPM; }
        //    set
        //    {
        //        if (Car.IdleRPM != value)
        //        {
        //            Car.IdleRPM = value;
        //            RaisePropertyChanged("IdleRPM");
        //        }
        //    }
        //}
        //public double CrankPower
        //{
        //    get { return Car.CrankPower; }
        //    set
        //    {
        //        if (Car.CrankPower != value)
        //        {
        //            Car.CrankPower = value;
        //            RaisePropertyChanged("CrankPower");
        //        }
        //    }
        //}
        //public double MaxPower
        //{
        //    get { return Car.MaxPower; }
        //    set
        //    {
        //        if (Car.MaxPower != value)
        //        {
        //            Car.MaxPower = value;
        //            RaisePropertyChanged("MaxPower");
        //        }
        //    }
        //}
        //public double MaxRPM
        //{
        //    get { return Car.MaxRPM; }
        //    set
        //    {
        //        if (Car.MaxRPM != value)
        //        {
        //            Car.MaxRPM = value;
        //            RaisePropertyChanged("MaxRPM");
        //        }
        //    }
        //}
        public double FinalDrive
        {
            get { return Car.FinalDrive; }
            set
            {
                if (Car.FinalDrive != value)
                {
                    Car.FinalDrive = value;
                    RaisePropertyChanged("FinalDrive");
                }
            }
        }
        public double CrankTorque
        {
            get { return Car.CrankTorque; }
            set
            {
                if (Car.CrankTorque != value)
                {
                    Car.CrankTorque = value;
                    RaisePropertyChanged("CrankTorque");
                }
            }
        }
        public double FrontReaction
        {
            get { return Car.FrontReaction; }
            set
            {
                if (Car.FrontReaction != value)
                {
                    Car.FrontReaction = value;
                    RaisePropertyChanged("FrontReaction");
                }
            }
        }
        public double RearReaction
        {
            get { return Car.RearReaction; }
            set
            {
                if (Car.RearReaction != value)
                {
                    Car.RearReaction = value;
                    RaisePropertyChanged("RearReaction");
                }
            }
        }
        public double XPos
        {
            get { return Car.XPos; }
            set
            {
                if (Car.XPos != value)
                {
                    Car.XPos = value;
                    RaisePropertyChanged("XPos");
                }
            }
        }
        public double Velocity
        {
            get { return Car.Velocity; }
            set
            {
                if (Car.Velocity != value)
                {
                    Car.Velocity = value;
                    RaisePropertyChanged("Velocity");
                    //RaisePropertyChanged("CrankRPM");
                    RaisePropertyChanged("KineticEnergy");
                }
            }
        }
        public double Acceleration
        {
            get { return Car.Acceleration; }
            set
            {
                if (Car.Acceleration != value)
                {
                    Car.Acceleration = value;
                    RaisePropertyChanged("Acceleration");
                }
            }
        }
        public double KineticEnergy
        {
            get { return Car.KineticEnergy; }
            set
            {
                if (Car.KineticEnergy != value)
                {
                    Car.KineticEnergy = value;
                    RaisePropertyChanged("KineticEnergy");
                }
            }
        }
        #endregion

        #region Brake Properties
        public Models.BrakeModel Brake
        {
            get { return _Brake; }
            set { _Brake = value; }
        }
        public double Density
        {
            get { return Brake.Density; }
            set
            {
                if (Brake.Density != value)
                {
                    Brake.Density = value;
                    RaisePropertyChanged("Density");
                    RaisePropertyChanged("BrakeMass");
                }
            }
        }
        public double SpecificHeatCapacity
        {
            get { return Brake.SpecificHeatCapacity; }
            set
            {
                if (Brake.SpecificHeatCapacity != value)
                {
                    Brake.SpecificHeatCapacity = value;
                    RaisePropertyChanged("SpecificHeatCapacity");
                }
            }
        }
        public double TensileModulus
        {
            get { return Brake.TensileModulus; }
            set
            {
                if (Brake.TensileModulus != value)
                {
                    Brake.TensileModulus = value;
                    RaisePropertyChanged("TensileModulus");
                }
            }
        }
        public double OuterDiameter
        {
            get { return Brake.OuterDiameter; }
            set
            {
                if (Brake.OuterDiameter != value)
                {
                    Brake.OuterDiameter = value;
                    RaisePropertyChanged("OuterDiameter");
                    RaisePropertyChanged("SurfaceArea");
                    RaisePropertyChanged("BrakeMass");
                    RaisePropertyChanged("Volume");
                }
            }
        }
        public double InnerDiameter
        {
            get { return Brake.InnerDiameter; }
            set
            {
                if (Brake.InnerDiameter != value)
                {
                    Brake.InnerDiameter = value;
                    RaisePropertyChanged("InnerDiameter");
                    RaisePropertyChanged("SurfaceArea");
                    RaisePropertyChanged("Volume");
                    RaisePropertyChanged("BrakeMass");
                }
            }
        }
        public double Thickness
        {
            get { return Brake.Thickness; }
            set
            {
                if (Brake.Thickness != value)
                {
                    Brake.Thickness = value;
                    RaisePropertyChanged("Thickness");
                    RaisePropertyChanged("SurfaceArea");
                    RaisePropertyChanged("Volume");
                    RaisePropertyChanged("BrakeMass");
                }
            }
        }
        public double SurfaceArea
        {
            get { return Brake.SurfaceArea; }
            set
            {
                if (Brake.SurfaceArea != value)
                {
                    Brake.SurfaceArea = value;
                    RaisePropertyChanged("SurfaceArea");
                }
            }
        }
        public double Volume
        {
            get { return Brake.Volume; }
            set
            {
                if (Brake.Volume != value)
                {
                    Brake.Volume = value;
                    RaisePropertyChanged("Volume");
                    RaisePropertyChanged("BrakeMass");
                }
            }
        }
        public double BrakeMass
        {
            get { return Brake.BrakeMass; }
            set
            {
                if (Brake.BrakeMass != value)
                {
                    Brake.BrakeMass = value;
                    RaisePropertyChanged("BrakeMass");
                }
            }
        }
        public double DiscTemperature
        {
            get { return Brake.DiscTemperature; }
            set
            {
                if (Brake.DiscTemperature != value)
                {
                    Brake.DiscTemperature = value;
                    RaisePropertyChanged("DiscTemperature");
                }
            }
        }
        public double AngularVelocity
        {
            get { return Brake.AngularVelocity; }
            set
            {
                if (Brake.AngularVelocity != value)
                {
                    Brake.AngularVelocity = value;
                    RaisePropertyChanged("AngularVelocity");
                }
            }
        }
        /// <summary>
        /// Brake pedal position, 0-100%.
        /// </summary>
        public double BrakePos
        {
            get { return Brake.BrakePos; }
            set
            {
                if (Brake.BrakePos != value)
                {
                    Brake.BrakePos = value;
                    RaisePropertyChanged("BrakePos");
                }
            }
        }
        /// <summary>
        /// Brake pedal force in N.
        /// </summary>
        public double BrakePedalForce
        {
            get { return Brake.BrakePedalForce; }
            set 
            {
                if (Brake.BrakePedalForce != value)
                {
                    Brake.BrakePedalForce = value;
                    RaisePropertyChanged("BrakePedalForce");
                }
            }
        }
        /// <summary>
        /// Brake pedal lever ratio.
        /// </summary>
        public double BrakePedalRatio
        {
            get { return Brake.BrakePedalRatio; }
            set 
            {
                if (Brake.BrakePedalRatio != value)
                {
                    Brake.BrakePedalRatio = value;
                    RaisePropertyChanged("BrakePedalRatio");
                }
            }
        }
        /// <summary>
        /// Force on master cylinder actuators (N).
        /// </summary>
        public double MasterCylinderForce
        {
            get { return Brake.MasterCylinderForce; }
            set 
            {
                if (Brake.MasterCylinderForce != value)
                {
                    Brake.MasterCylinderForce = value;
                    RaisePropertyChanged("MasterCylinderForce");
                }
            }
        }
        /// <summary>
        /// Force on front master cylinder actuator (N).
        /// </summary>
        public double FrontCylinderForce
        {
            get { return Brake.FrontCylinderForce; }
            set 
            {
                if (Brake.FrontCylinderForce != value)
                {
                    Brake.FrontCylinderForce = value;
                    RaisePropertyChanged("FrontCylinderForce");
                }
            }
        }
        /// <summary>
        /// Force on rear master cylinder actuator (N).
        /// </summary>
        public double RearCylinderForce
        {
            get { return Brake.RearCylinderForce; }
            set 
            {
                if (Brake.RearCylinderForce != value)
                {
                    Brake.RearCylinderForce = value;
                    RaisePropertyChanged("RearCylinderForce");
                }
            }
        }
        /// <summary>
        /// Area of master cylinder piston (m^2).
        /// </summary>
        public double MasterPistonArea
        {
            get { return Brake.MasterPistonArea; }
            set 
            {
                if (Brake.MasterPistonArea != value)
                {
                    Brake.MasterPistonArea = value;
                    RaisePropertyChanged("MasterPistonArea");
                }
            }
        }
        /// <summary>
        /// Area of caliper piston (m^2).
        /// </summary>
        public double CalliperPistonArea
        {
            get { return Brake.CalliperPistonArea; }
            set 
            {
                if (Brake.CalliperPistonArea != value)
                {
                    Brake.CalliperPistonArea = value;
                    RaisePropertyChanged("CalliperPistonArea");
                }
            }
        }
        /// <summary>
        /// Pressure in front braking system (Pa).
        /// </summary>
        public double FrontBrakeSysPressure
        {
            get { return Brake.FrontBrakeSysPressure; }
            set 
            {
                if (Brake.FrontBrakeSysPressure != value)
                {
                    Brake.FrontBrakeSysPressure = value;
                    RaisePropertyChanged("FrontBrakeSysPressure");
                }
            }
        }
        /// <summary>
        /// Pressure in rear braking system (Pa).
        /// </summary>
        public double RearBrakeSysPressure
        {
            get { return Brake.RearBrakeSysPressure; }
            set 
            {
                if (Brake.RearBrakeSysPressure != value)
                {
                    Brake.RearBrakeSysPressure = value;
                    RaisePropertyChanged("RearBrakeSysPressure");
                }
            }
        }
        /// <summary>
        /// Number of pistons in front callipers.
        /// </summary>
        public double NumPistonsFront
        {
            get { return Brake.NumPistonsFront; }
            set 
            {
                if (Brake.NumPistonsFront != value)
                {
                    Brake.NumPistonsFront = value;
                    RaisePropertyChanged("NumPistonsFront");
                }
            }
        }
        /// <summary>
        /// Number of pistons in rear callipers.
        /// </summary>
        public double NumPistonsRear
        {
            get { return Brake.NumPistonsRear; }
            set 
            {
                if (Brake.NumPistonsRear != value)
                {
                    Brake.NumPistonsRear = value;
                    RaisePropertyChanged("NumPistonsRear");
                }
            }
        }
        /// <summary>
        /// Total force on front caliper pistons (N).
        /// </summary>
        public double FrontCalliperForce
        {
            get { return Brake.FrontCalliperForce; }
            set 
            {
                if (Brake.FrontCalliperForce != value)
                {
                    Brake.FrontCalliperForce = value;
                    RaisePropertyChanged("FrontCalliperForce");
                }
            }
        }
        /// <summary>
        /// Total force on rear caliper pistons (N).
        /// </summary>
        public double RearCalliperForce
        {
            get { return Brake.RearCalliperForce; }
            set 
            {
                if (Brake.RearCalliperForce != value)
                {
                    Brake.RearCalliperForce = value;
                    RaisePropertyChanged("RearCalliperForce");
                }
            }
        }
        /// <summary>
        /// Coefficient of friction between discs and pads.
        /// </summary>
        public double DiscPadFriction
        {
            get { return Brake.DiscPadFriction; }
            set 
            {
                if (Brake.DiscPadFriction != value)
                {
                    Brake.DiscPadFriction = value;
                    RaisePropertyChanged("DiscPadFriction");
                }
            }
        }
        /// <summary>
        /// Force on front discs due to friction (N).
        /// </summary>
        public double FrontBrakeForce
        {
            get { return Brake.FrontBrakeForce; }
            set 
            {
                if (Brake.FrontBrakeForce != value)
                {
                    Brake.FrontBrakeForce = value;
                    RaisePropertyChanged("FrontBrakeForce");
                }
            }
        }
        /// <summary>
        /// Force on rear discs due to friction (N).
        /// </summary>
        public double RearBrakeForce
        {
            get { return Brake.RearBrakeForce; }
            set 
            {
                if (Brake.RearBrakeForce != value)
                {
                    Brake.RearBrakeForce = value;
                    RaisePropertyChanged("RearBrakeForce");
                }
            }
        }
        /// <summary>
        /// Torque on front brake rotors (Nm).
        /// </summary>
        public double FrontBrakeTorque
        {
            get { return Brake.FrontBrakeTorque; }
            set 
            {
                if (Brake.FrontBrakeTorque != value)
                {
                    Brake.FrontBrakeTorque = value;
                    RaisePropertyChanged("FrontBrakeTorque");
                }
            }
        }
        /// <summary>
        /// Torque on rear brake rotors (Nm).
        /// </summary>
        public double RearBrakeTorque
        {
            get { return Brake.RearBrakeTorque; }
            set 
            {
                if (Brake.RearBrakeTorque != value)
                {
                    Brake.RearBrakeTorque = value;
                    RaisePropertyChanged("RearBrakeTorque");
                }
            }
        }
        /// <summary>
        /// Master cylinder piston outer diameter (m).
        /// </summary>
        public double MasterPistonOuterDiameter
        {
            get { return Brake.MasterPistonOuterDiameter; }
            set 
            {
                if (Brake.MasterPistonOuterDiameter != value)
                {
                    Brake.MasterPistonOuterDiameter = value;
                    RaisePropertyChanged("MasterPistonOuterDiameter");
                }
            }
        }
        /// <summary>
        /// Master cylinder piston inner diameter (m).
        /// </summary>
        public double MasterPistonInnerDiameter
        {
            get { return Brake.MasterPistonInnerDiameter; }
            set 
            {
                if (Brake.MasterPistonInnerDiameter != value)
                {
                    Brake.MasterPistonInnerDiameter = value;
                    RaisePropertyChanged("MasterPistonInnerDiameter");
                }
            }
        }
        /// <summary>
        /// Brake pad mean radius (m).
        /// </summary>
        public double BrakePadMeanRadius
        {
            get { return Brake.BrakePadMeanRadius; }
            set 
            {
                if (Brake.BrakePadMeanRadius != value)
                {
                    Brake.BrakePadMeanRadius = value;
                    RaisePropertyChanged("BrakePadMeanRadius");
                }
            }
        }
        /// <summary>
        /// Brake bias.
        /// </summary>
        public double BrakeBias
        {
            get { return Brake.BrakeBias; }
            set 
            {
                if (Brake.BrakeBias != value)
                {
                    Brake.BrakeBias = value;
                    RaisePropertyChanged("BrakeBias");
                }
            }
        }
        #endregion

        #region Commands
        void UpdateTimeExecute()
        {
            double KineticEnergyPrev = KineticEnergy;

            XPos = XPos + Velocity;
            Velocity = Velocity + Acceleration;

            AngularVelocity = Velocity / OuterDiameter;

            //if (BrakePos > 0)
            //{
            //    double KineticEnergyChange = KineticEnergy -
            //        KineticEnergyPrev;
            //    double EnergyToDisc = KineticEnergyChange / 4;
            //    double DiscTemperatureChange = EnergyToDisc / (BrakeMass *
            //        SpecificHeatCapacity);
            //    DiscTemperature = DiscTemperature + DiscTemperatureChange;
            //}

            TimeStamp++;

            // Raise property changed flags
            RaisePropertyChanged("Velocity");
            //RaisePropertyChanged("CrankRPM");
            RaisePropertyChanged("KineticEnergy");
            RaisePropertyChanged("DiscTemperature");

            // Write data to .txt file
            StreamWriter VelData = new StreamWriter(LocalDir
                + "\\SimData.txt", true);
            String VelString = Velocity.ToString();
            String TimeString = TimeStamp.ToString();
            String AccString = Acceleration.ToString();
            String TempString = DiscTemperature.ToString();
            VelData.WriteLine(TimeString + ":" + VelString + ":" + AccString
                + ":" + TempString);
            VelData.Close();
        }
        bool CanUpdateTimeExecute()
        {
            return true;
        }
        public ICommand UpdateTime 
        { get 
            { return new RelayCommand(UpdateTimeExecute, 
                CanUpdateTimeExecute); 
            } 
        }

        void BrakeTestExecute()
        {
            //if(XPos <= 50)
            //{
            //    Acceleration = 3;
            //}
            //else
            //{
            //    Acceleration = -6;
            //}

            double KineticEnergyPrev = KineticEnergy;

            XPos = XPos + Velocity;
            Velocity = Velocity + Acceleration;

            AngularVelocity = Velocity / OuterDiameter;

            //if (BrakePos > 0)
            //{
            //    double KineticEnergyChange = KineticEnergy -
            //        KineticEnergyPrev;
            //    double EnergyToDisc = KineticEnergyChange / 4;
            //    double DiscTemperatureChange = EnergyToDisc / (BrakeMass *
            //        SpecificHeatCapacity);
            //    DiscTemperature = DiscTemperature + DiscTemperatureChange;
            //}

            //double Deacceleration = BrakePos;
            //Acceleration = Acceleration - BrakePos;

            //  CrankRPM = CrankRPM + ((1 / FinalDrive) * (Acceleration * 
            //    TyreRadius));
            TimeStamp++;

            // Raise property changed flags
            RaisePropertyChanged("Velocity");
            //RaisePropertyChanged("CrankRPM");
            RaisePropertyChanged("KineticEnergy");
            RaisePropertyChanged("DiscTemperature");

            // Write data to .txt file
            StreamWriter VelData = new StreamWriter(LocalDir
                + "\\SimData.txt", true);
            String VelString = Velocity.ToString();
            String TimeString = TimeStamp.ToString();
            String AccString = Acceleration.ToString();
            String TempString = DiscTemperature.ToString();
            VelData.WriteLine(TimeString + ":" + VelString + ":" + AccString
                + ":" + TempString);
            VelData.Close();
            //}

        }
        bool CanBrakeTestExecute()
        {
            return true;
        }
        public ICommand BrakeTest
        {
            get
            {
                return new RelayCommand(UpdateTimeExecute,
                  CanUpdateTimeExecute);
            }
        }
        #endregion

        #region Functions
        // Calculates the heat flux through the area of contact between 
        // the brake pad and disc.
        double QfluxDisc(double QdotIn, double DiscOuterRadius, 
            double BrakePadHeight)
        {
            double Qflux;
            Qflux = (4 * QdotIn) / (3.14 * (Math.Pow(2 * DiscOuterRadius, 2)) - (3.14 * (Math.Pow((DiscOuterRadius - BrakePadHeight), 2))));
            return Qflux;
        }
        // Calculates heat transfer from an object to the environment 
        // based on the lumped capcitance model.
        double AmbientCooling(double Temperature, double TemperatureAmb, 
            double Alpha, double AreaSurface)
        {
            double QdotAmb;
            if (Temperature > TemperatureAmb)
            {
                QdotAmb = -AreaSurface * Alpha * (Temperature - TemperatureAmb);
            }
            else
            {
                QdotAmb = 0;
            }
            return QdotAmb;
        }
        #endregion
    }
}
