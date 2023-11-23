namespace SamplerControlSystem.Entity
{
    public class ControlSystemStatus
    {
        /// <summary>
        /// 气体稳定状态
        /// </summary>
        public bool GasStableStatus { get; set; }
        /// <summary>
        /// 气箱门
        /// </summary>
        public bool AirboxDoorsStatus { get; set; }
        /// <summary>
        /// 零点状态
        /// </summary>
        public bool ZeroClearanceStatus { get; set; }

        /// <summary>
        /// 分析仪浓度漂移
        /// </summary>
        public bool AnalyserStatus { get; set; }
        /// <summary>
        /// 注气状态
        /// </summary>
        public bool GasInjectionStatus { get; set; }
        /// <summary>
        /// 流量计连接状态
        /// </summary>
        public bool FlowMeterConnectionStatus { get; set; }
        /// <summary>
        /// 模数转换器连接状态
        /// </summary>
        public bool ADCConcentrationStatus { get; set; }

        /// <summary>
        /// 注气检测状态
        /// </summary>
        public bool GasInjectionConcentrationStatus { get; set; }

        /// <summary>
        /// 注样仪运行状态
        /// </summary>
        public bool CalibrationCompletionStatus { get; set; }

        /// <summary>
        /// 气缸状态
        /// </summary>
        public bool CylinderStatus { get; set; }
        /// <summary>
        /// 风扇状态
        /// </summary>
        public bool CirculationFanStatus { get; set; }

        /// <summary>
        /// 排气阀
        /// </summary>
        public bool ExhaustValveStatus { get; set; }
        /// <summary>
        /// 排气扇
        /// </summary>
        public bool ExhaustFanStatus { get; set; }

        /// <summary>
        /// 流量计设置状态
        /// </summary>
        public bool FlowMeterSetStatus { get; set; }

        /// <summary>
        /// true为0,false为1
        /// </summary>
        /// <param name="allStatus"></param>
        /// <returns></returns>
        public void SetAttributeValue(ushort allStatus)
        {
            GasStableStatus = (allStatus & 0x1) == 0;
            AirboxDoorsStatus = (allStatus & 0x2) == 0;
            ZeroClearanceStatus = (allStatus & 0x4) == 0;
            AnalyserStatus = (allStatus & 0x8) == 0;
            GasInjectionStatus = (allStatus & 0x10) == 0;
            FlowMeterConnectionStatus = (allStatus & 0x20) == 0;
            ADCConcentrationStatus = (allStatus & 0x40) == 0;
            GasInjectionConcentrationStatus = (allStatus & 0x80) == 0;
            CalibrationCompletionStatus = (allStatus & 0x100) == 0;
            CylinderStatus = (allStatus & 0x200) == 0;
            CirculationFanStatus = (allStatus & 0x400) == 0;
            ExhaustValveStatus = (allStatus & 0x800) == 0;
            ExhaustFanStatus = (allStatus & 0x1000) == 0;
            FlowMeterSetStatus = (allStatus & 0x2000) == 0;
        }

    }
}
