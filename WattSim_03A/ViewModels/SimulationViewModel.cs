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
            double AirTemp = 300;       // Ambient temperature in Kelvin.

            #region Car Constructor
            _Car = new Models.CarModel
            {
                Name = "HWR-01",
                Mass = 320,
                WheelBase = 1.6,
                Track = 0.6,
                CogLong = 1,
                TyreRadius = 0.508,
                WheelInertia = 1,
                IdlePower = 7457,   // 10 hp = 7457 W
                MaxPower = 75762,   // 101.6 hp = 75762 W
                IdleRPM = 2000,
                MaxRPM = 14000,
                FinalDrive = 11.04,

                ThrottlePos = 0.1,

                CrankRPM = 2000,
                CrankPower = 7457,
                XPos = 0,
                KineticEnergy = 9935,
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
            };
            #endregion

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
                    RaisePropertyChanged("CrankPower");
                    RaisePropertyChanged("CrankTorque");
                    RaisePropertyChanged("Acceleration");
                }
            }
        }
        public double BrakePos
        {
            get { return Car.BrakePos; }
            set
            {
                if (Car.BrakePos != value)
                {
                    Car.BrakePos = value;
                    RaisePropertyChanged("BrakePos");
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
        public double CrankRPM
        {
            get { return Car.CrankRPM; }
            set
            {
                if (Car.CrankRPM != value)
                {
                    Car.CrankRPM = value;
                    RaisePropertyChanged("CrankRPM");
                    RaisePropertyChanged("Velocity");
                    RaisePropertyChanged("KineticEnergy");
                    RaisePropertyChanged("DiscTemperature");
                }
            }
        }
        public double IdlePower
        {
            get { return Car.IdlePower; }
            set
            {
                if (Car.IdlePower != value)
                {
                    Car.IdlePower = value;
                    RaisePropertyChanged("IdlePower");
                }
            }
        }
        public double IdleRPM
        {
            get { return Car.IdleRPM; }
            set
            {
                if (Car.IdleRPM != value)
                {
                    Car.IdleRPM = value;
                    RaisePropertyChanged("IdleRPM");
                }
            }
        }
        public double CrankPower
        {
            get { return Car.CrankPower; }
            set
            {
                if (Car.CrankPower != value)
                {
                    Car.CrankPower = value;
                    RaisePropertyChanged("CrankPower");
                }
            }
        }
        public double MaxPower
        {
            get { return Car.MaxPower; }
            set
            {
                if (Car.MaxPower != value)
                {
                    Car.MaxPower = value;
                    RaisePropertyChanged("MaxPower");
                }
            }
        }
        public double MaxRPM
        {
            get { return Car.MaxRPM; }
            set
            {
                if (Car.MaxRPM != value)
                {
                    Car.MaxRPM = value;
                    RaisePropertyChanged("MaxRPM");
                }
            }
        }
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
                    RaisePropertyChanged("KineticEnergy");      // The K.E. is a function of velocity.
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
        #endregion

        #region Commands
        void UpdateTimeExecute()
        {
            double KineticEnergyPrev = KineticEnergy;

            XPos = XPos + Velocity;
            AngularVelocity = Velocity / OuterDiameter;
            CrankRPM = CrankRPM + ((1 / FinalDrive) * ((Acceleration * 
                TyreRadius) / (2 * Math.PI) * 60));

            if (BrakePos > 0)
            {
                double KineticEnergyChange = KineticEnergy - 
                    KineticEnergyPrev;
                double EnergyToDisc = KineticEnergyChange / 4;
                double DiscTemperatureChange = EnergyToDisc / (BrakeMass * 
                    SpecificHeatCapacity);
                DiscTemperature = DiscTemperature + DiscTemperatureChange;
            }

            double Deacceleration = BrakePos;
            Acceleration = Acceleration - BrakePos;

            CrankRPM = CrankRPM + ((1 / FinalDrive) * (Acceleration * 
                TyreRadius));
            TimeStamp++;

            // Raise property changed flags
            RaisePropertyChanged("CrankPower");
            RaisePropertyChanged("CrankTorque");
            RaisePropertyChanged("Acceleration");
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
        #endregion

        #region Functions
        // Calculates the heat flux through the area of contact between the brake pad and disc.
        double QfluxDisc(double QdotIn, double DiscOuterRadius, double BrakePadHeight)
        {
            double Qflux;
            Qflux = (4 * QdotIn) / (3.14 * (Math.Pow(2 * DiscOuterRadius, 2)) - (3.14 * (Math.Pow((DiscOuterRadius - BrakePadHeight), 2))));
            return Qflux;
        }
        //  Calculates heat transfer from an object to the environment based on the lumped capcitance model
        double AmbientCooling(double Temperature, double TemperatureAmb, double Alpha, double AreaSurface)
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
