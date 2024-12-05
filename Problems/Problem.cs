using Problems.Advent._2023;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Problems;

public abstract class Problem
{
    public abstract Task ExecuteAsync();

    protected string Input { get; private set; }

    protected virtual string? TestInput { get; } = null;
    protected virtual bool UseTestInput { get; }

    public virtual async Task Initialize()
    {
        if (UseTestInput && TestInput != null)
        {
            Input = TestInput;
            return;
        }

        var assembly = Assembly.GetAssembly(typeof(Dag01));
        var resourcePath = assembly.GetManifestResourceNames().SingleOrDefault(s => s.EndsWith($"{Nummer}.txt"));
        if (string.IsNullOrEmpty(resourcePath))
        {
            return;
        }
        using Stream stream = assembly.GetManifestResourceStream(resourcePath)!;
        using StreamReader reader = new(stream);
        Input = await reader.ReadToEndAsync();
    }

    public abstract int Nummer { get; }
    public string Result { get; protected set; }

}