namespace SamplerControlSystem.Condition
{
    public class UpgradeFirmwareNoticeParameters
    {
        /// <summary>
        /// 硬件版本
        /// </summary>
        public ushort HwVersion { get; set; }

        /// <summary>
        /// 软件版本
        /// </summary>
        public ushort SwVersion { get; set;}

        /// <summary>
        /// 固件大小
        /// </summary>
        public uint FirmwareSize { get; set;}

        /// <summary>
        /// 固件校验码
        /// </summary>
        public uint FirmwareChecksum { get; set;}

        /// <summary>
        /// 固件块大小
        /// </summary>
        public ushort FirmwareBlockSize { get; set; }

        /// <summary>
        /// 固件块数量
        /// </summary>
        public ushort FirmwareBlockNum { get; set; }

    }
}
