using static System.Console;
using System.Reflection;
using System.Runtime.CompilerServices;
using WorkingWithReflection;

WriteLine("Assembly metadata:");
Assembly? assembly = Assembly.GetEntryAssembly();


if(assembly is null)
{
    WriteLine("Failed to get entry assembly");
    return;
}

WriteLine($"Full name: {assembly.FullName}");
WriteLine($"location: {assembly.Location}");


IEnumerable<Attribute> attributes = assembly.GetCustomAttributes();
WriteLine("Assembly-level attributes: ");

foreach(Attribute attribute in attributes)
{
    WriteLine($"{attribute.GetType()}");
}


AssemblyInformationalVersionAttribute ? versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

WriteLine($"Version: {versionAttribute?.InformationalVersion}");



AssemblyCompanyAttribute? company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();

WriteLine($" Company: {company?.Company}");

WriteLine("Hello, World!");

WriteLine("Get types ");

Type[] types = assembly.GetTypes();

foreach (Type type in types)
{
    WriteLine();
    WriteLine($"Type: {type.FullName}");

    MemberInfo[] memberInfos = type.GetMembers();

    foreach(MemberInfo memberInfo in memberInfos)
    {
        WriteLine($"{memberInfo.MemberType} - {memberInfo.Name} - {memberInfo.DeclaringType.Name}");
        IOrderedEnumerable<CoderAttribute> coders = memberInfo.GetCustomAttributes<CoderAttribute>().OrderByDescending(c=>c.LastModified);

        foreach(CoderAttribute coder in coders)
        {
            WriteLine($"Modified by {coder.Coder} Modified: {coder.LastModified.ToShortTimeString()}");
        }
    }
}



class Animal
{
    [Coder("Ammar Atef","22 August 2021")]
    [Coder("Ammar Atef1","26 August 2021")]

    public void Speak()
    {
        WriteLine("Woof...");
    }
}