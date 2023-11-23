using SamplerControlSystem.Entity;
using SamplerControlSystem.Server;
using SamplerSystem.UI.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SamplerSystem.UI.Testing
{
    public enum TestType
    {
        /// <summary>
        /// 设置参数
        /// </summary>
        Init,
        /// <summary>
        /// 开始标定
        /// </summary>
        Start,
        /// <summary>
        /// 预热中
        /// </summary>
        Preheating,
        /// <summary>
        /// 标定中
        /// </summary>
        Testing,
        /// <summary>
        /// Mes推送
        /// </summary>
        MesPush,

        /// <summary>
        /// 测试完成
        /// </summary>
        EndTest,
        /// <summary>
        /// 停止标定
        /// </summary>
        StopTest,
    }

    public class TestContext
    {
        public ControlSystem ControlSystem {  get; set; }

        public SysSettings Settings { get; set; }

        public TestType TestStatus { get; set; } 

        /// <summary>
        /// 测试状态
        /// </summary>
        public string TestStatusMsg
        {
            get
            {
                switch (TestStatus)
                {
                    case TestType.Init: return "初始化设置";
                    case TestType.Start: return "开始标定";
                    case TestType.Preheating: return "预热中";
                    case TestType.Testing: return "标定中";
                    case TestType.MesPush: return "数据上传中";
                    case TestType.EndTest: return "标定完成";
                    case TestType.StopTest: return "停止测试";
                    default: return "测试状态错误";
                }
            }
        }

        /// <summary>
        /// 标定详情
        /// </summary>
        public string SampleInfoMsg { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTestTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AutoResetEvent ResetEvent { get; set; }

        /// <summary>
        /// 预热开始时间
        /// </summary>
        public DateTime PreheatStartTime { get; set; }


        public TestContext(ControlSystem controlSystem, SysSettings settings)
        {
            ControlSystem = controlSystem;
            Settings = settings;
            TestStatus = TestType.Init;
            ResetEvent = new AutoResetEvent(false);
        }

        public void ReceiveCommand(byte cmd)
        {
            //未发送命令
            if (SamplerCmder.CheckCmd == 0xFF) return;
            //接收命令不是发送命令的答复
            if (SamplerCmder.CheckCmd != cmd) return;

            SamplerCmder.CheckCmd = 0xFF;
            ResetEvent.Set();
        }
  
    }

}
