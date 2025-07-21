namespace GqlPlus;

internal class GqlpGeneratorOptions
{
  public string BaseName { get; }
  public string NameSpace { get; }
  public GqlpBaseType BaseType { get; }
  public GqlpGeneratorType GeneratorType { get; }

  public GqlpGeneratorOptions(string fullName, GqlpBaseType baseType, GqlpGeneratorType generatorType)
  {
    string[] names = fullName.Split('.');

    if (names.Length > 1) {
      BaseName = names.Last();
      NameSpace = string.Join(".", names.Take(names.Length - 1));
    } else {
      BaseName = fullName;
      NameSpace = string.Empty;
    }

    BaseType = baseType;
    GeneratorType = generatorType;
  }
}
