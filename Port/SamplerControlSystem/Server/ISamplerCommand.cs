using SamplerControlSystem.Condition;
using SamplerControlSystem.Model;

namespace SamplerControlSystem.Server
{
    public interface ISamplerCommand
    {
        byte[] Init(SensorBoardSetting setting);
        byte[] WriteCommand(WriteCmdParameters writeCmdParam);
        byte[] QuerySampleResults();

        byte[] UpgradeFirmwareNotice(UpgradeFirmwareNoticeParameters upgradeFirmwareParam);
        byte[] UpgradeFirmware(UpgradeFirmwareParameters upgradeFirmwareParam);

    }
}
