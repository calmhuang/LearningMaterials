using SamplerControlSystem.Entity;

namespace SamplerControlSystem.Model
{
    public class ViewModelControlSystem
    {
        public ControlSystem  ControlSystemData { get; set; }
        public decimal InjectionTime { get; set; }
        public decimal Sample2 { get; set; }
        public decimal Sample3 { get; set; }

        public ViewModelControlSystem(ControlSystem controlSystem, decimal time, decimal sample2, decimal sample3) 
        {
            ControlSystemData= controlSystem;
            InjectionTime= time;
            Sample2 = sample2;
            Sample3 = sample3;
        }
    }
}
