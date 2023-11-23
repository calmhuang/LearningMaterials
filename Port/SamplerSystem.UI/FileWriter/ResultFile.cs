using SamplerControlSystem.Condition;
using SamplerControlSystem.Entity;
using SamplerSystem.UI.Models.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SamplerSystem.UI.FileWriter
{
    public class ResultFile
    {
        private string _resultpath;
        private string _beginTime;
        private SysSettings _settings;
        private string _endTime;



        public ResultFile(string path, string endTime, string beginTime, SysSettings settings)
        {
            _resultpath = path;
            _endTime = endTime;
            _beginTime = beginTime;

            _settings = settings;
        }

        public void WriteHead(float temperature,float humidity)
        {
            var tstrings = _resultpath.Split('\\');
            string lotdir = _resultpath.Remove(_resultpath.LastIndexOf(tstrings.LastOrDefault()));

            if (!Directory.Exists(lotdir))
            {
                Directory.CreateDirectory(lotdir);
            }

            using (var fs = new FileStream(_resultpath, FileMode.Create))
            {
                string s;

                s = $"Begin Time:,{_beginTime}{Environment.NewLine}";
                fs.Write(Encoding.ASCII.GetBytes(s), 0, s.Length);
                s = $"End Time:,{_endTime}{Environment.NewLine}";
                fs.Write(Encoding.ASCII.GetBytes(s), 0, s.Length);

                s = $"Gas Type:,{Enum.GetName(typeof(GasType), _settings.SensorBoardSettings.GasType)}{Environment.NewLine}";
                fs.Write(Encoding.GetEncoding("GB2312").GetBytes(s), 0, Encoding.GetEncoding("GB2312").GetBytes(s).Length);

                s = $"Calibration1 Concentration:,0{Environment.NewLine}";
                fs.Write(Encoding.GetEncoding("GB2312").GetBytes(s), 0, Encoding.GetEncoding("GB2312").GetBytes(s).Length);

                s = $"Calibration2 Concentration:,{_settings.SensorBoardSettings.GasParam.SamplePoint1}{Environment.NewLine}";
                fs.Write(Encoding.GetEncoding("GB2312").GetBytes(s), 0, Encoding.GetEncoding("GB2312").GetBytes(s).Length);

                s = $"Calibration3 Concentration:,{_settings.SensorBoardSettings.GasParam.SamplePoint2}{Environment.NewLine}";
                fs.Write(Encoding.GetEncoding("GB2312").GetBytes(s), 0, Encoding.GetEncoding("GB2312").GetBytes(s).Length);

                s = $"Preheat Time:,{_settings.SensorBoardSettings.PreheatTime}{Environment.NewLine}";
                fs.Write(Encoding.GetEncoding("GB2312").GetBytes(s), 0, Encoding.GetEncoding("GB2312").GetBytes(s).Length);

                s = $"Temperature:,{temperature}{Environment.NewLine}";
                fs.Write(Encoding.GetEncoding("GB2312").GetBytes(s), 0, Encoding.GetEncoding("GB2312").GetBytes(s).Length);

                s = $"Humidity:,{humidity}{Environment.NewLine}";
                fs.Write(Encoding.GetEncoding("GB2312").GetBytes(s), 0, Encoding.GetEncoding("GB2312").GetBytes(s).Length);


                s = $"{Environment.NewLine}";
                fs.Write(Encoding.GetEncoding("GB2312").GetBytes(s), 0, Encoding.GetEncoding("GB2312").GetBytes(s).Length);

                s = $"Point Number,SN/UID,Calibration State,Calibration1 Voltage,Calibration2 Voltage,Calibration3 Voltage,Calibration Slope," +
                    $"Zero Voltage,RealTime Voltage,Unload Voltage{Environment.NewLine}";
                fs.Write(Encoding.GetEncoding("GB2312").GetBytes(s), 0, Encoding.GetEncoding("GB2312").GetBytes(s).Length);
            }
        }

        public void WriteData(SensorData sensor)
        {
            //if (sensor == null) return;
            using (var fs = new FileStream(_resultpath, FileMode.Append))
            {
                string s = $"{sensor?.Index},{sensor?.BindSN}";
                fs.Write(Encoding.ASCII.GetBytes(s), 0, s.Length);

                s = $",{sensor?.CalibrationResult:X2},{sensor?.Voltage0},{sensor?.Voltage1},{sensor?.Voltage2}" +
                    $",{sensor?.CalibrationSlope},{sensor?.ZeroVoltage},{sensor?.RealTimeVoltage},{sensor?.NonLoadedVoltage}{Environment.NewLine}";
                fs.Write(Encoding.ASCII.GetBytes(s), 0, s.Length);
            }
        }


    }
}
