namespace SamplerControlSystem.Condition
{
    public enum CmdType
    {
        Start = 0x01,
        Preheated=0x02,
        SamplePoint1=0x03,
        SamplePoint2=0x04,
        SamplePoint3=0x05,

        OpenCirculationFan=0x10,
        CloseCirculationFan=0x11,
        OpenExhaustValve=0x12,
        CloseExhaustValve=0x13,
        CylinderUpper=0x14,
        CylinderDown=0x15,
        OpenExhaustFan=0x16,
        CloseExhaustFan=0x17,

        Check40PPM =0x20,
        Check1000PPM=0x21,
        InjectionGas=0x22,
        Reset=0xff
    }

    public class WriteCmdParameters
    {
        public CmdType CmdType { get; set; }

        public float Sample2{ get; set; }

        public float Sample3 { get; set; }

        public float InjectionGasTime {  get; set; }

        public WriteCmdParameters(CmdType cmdType)
        {
            this.CmdType = cmdType;
        }
    }
}
