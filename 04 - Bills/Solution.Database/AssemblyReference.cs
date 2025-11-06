using System.Reflection;

namespace Solution.Database;

public static class AssemblyReference
{
    public static readonly string Assembly = typeof(AssemblyReference).Assembly.GetName().Name!;
}
