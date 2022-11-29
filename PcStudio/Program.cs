using PcStudio;
using System.Text;
using static PcStudio.Component;

Console.WriteLine("Welcome, select an option from main Menu");
DisplayMenuOptions(0);

void DisplayMenuOptions(int menuOption)
{
    bool loop = true;
    Pc? currentPc = null;

    while (loop)
    {

        Console.WriteLine(@"
0. Quit
1. Create PC
2. Our Recomndations
3. List of CPUs
4. List of GPUs
5. List Current PC
");
        var selectedMenuOption = int.Parse(Console.ReadLine()!);
        switch (selectedMenuOption)
        {
            case 0:
                loop = false;
                break;
            case 1:
                currentPc = CreatePcMenuActions();
                break;
            case 2:

                break;
            case 5:
                if (currentPc is null)
                {
                    Console.WriteLine("Empty PC");
                    return;
                }

                foreach (var component in currentPc.Components)
                {
                    Console.WriteLine($"{component.Name}");
                }

                break;
        }
    }
}

Pc CreatePcMenuActions()
{
    bool loop = true;
    var currentPC = new Pc();
    var sb = new StringBuilder();

    sb.AppendLine("0. Back");
    foreach (var componentType in Enum.GetValues<ComponentType>())
    {
        if (componentType == ComponentType.None)
            continue;

        sb.AppendLine($"{(int)componentType}. Add {componentType.ToString()}");
    }

    while (loop)
    {
        Console.WriteLine(sb.ToString());
        var selectedMenuOption = int.Parse(Console.ReadLine()!);

        if (Enum.TryParse<ComponentType>(selectedMenuOption.ToString(), out ComponentType selectedComponentType))
        {
            if (selectedComponentType == ComponentType.None)
            {
                loop = false;
                continue;
            }

            var availableComponents = GetComponents().Where(e => e.Type == selectedComponentType);

            var currentCpu = currentPC.Components.FirstOrDefault(e => e.Type == ComponentType.Cpu);
            if (currentCpu != null)
            {
                availableComponents = availableComponents.Where(e => e.Brand == currentCpu.Brand);
            }

            var selectedComponent = PrintAndSelectAvailableComponents(availableComponents.ToList());
            currentPC.Components.Add(selectedComponent);
        }
    }
    return currentPC;
}


List<Component> GetComponents()
{
    return Component.All;
}

Component PrintAndSelectAvailableComponents(List<Component> availableComponents)
{
    for (int i = 0; i < availableComponents.Count; i++)
    {
        Console.WriteLine($"{i}. {availableComponents[i].Name}");
    }
    var selected = int.Parse(Console.ReadLine());
    return availableComponents[selected];
}