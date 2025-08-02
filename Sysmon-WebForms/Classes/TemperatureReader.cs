using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;

namespace Sysmon_Web
{
    internal sealed class TemperatureReader : IDisposable
    {
        private Computer _computer;

        public TemperatureReader()
        {
            //_computer = new Computer { CPUEnabled = true };
            //_computer.Open();

            Computer _computer = new Computer();
            _computer.Open();
            _computer.CPUEnabled = true;
        }

        public IReadOnlyDictionary<string, float> GetTemperaturesInCelsius()
        {
            var coreAndTemperature = new Dictionary<string, float>();

            foreach (var hardware in _computer.Hardware)
            {
                hardware.Update(); //use hardware.Name to get CPU model
                foreach (var sensor in hardware.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature && sensor.Value.HasValue)
                        coreAndTemperature.Add(sensor.Name, sensor.Value.Value);
                }
            }

            return coreAndTemperature;
        }

        public void Dispose()
        {
            try
            {
                _computer.Close();
            }
            catch (Exception)
            {
                //ignore closing errors
            }
        }
    }
}
