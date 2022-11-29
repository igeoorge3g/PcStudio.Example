using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PcStudio
{
    internal class Pc
    {
        public string Name { get; set; }
        public List<Component> Components { get; set; } = new List<Component>();
    }

    public class Component
    {
        public string Name { get; set; }
        public string? Brand { get; set; }
        public ComponentType Type { get; set; }

        public Component(string name, ComponentType type)
        {
            Name = name;
            Type = type;

        }
        public Component(string name, ComponentType type, string brand) : this(name, type)
        {
            Brand = brand;
        }


        public static List<Component> All = new List<Component>()
        {
            new Component("Ryzen 7 5700X", ComponentType.Cpu, "AMD"),
            new Component("Intel i5 12400", ComponentType.Cpu, "Intel"),
            new Component("X570", ComponentType.Motherboard, "AMD"),
            new Component("Z850", ComponentType.Motherboard, "Intel"),
            new Component("GSkill 32gb 4400mhz", ComponentType.Ram),
            new Component("RTX 3090", ComponentType.Gpu),
            new Component("Gigabyte 850W 80+ Platinum", ComponentType.PowerSupply),
            new Component("Thermaltake H330TG", ComponentType.Case),

        };



        public enum ComponentType
        {
            None = 0,
            Case = 1,
            Cpu = 2,
            Gpu = 3,
            Motherboard = 4,
            PowerSupply = 5,
            Ram = 6
        }
    }
}
