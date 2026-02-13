namespace GqlPlus;

internal class GqlpGeneratorOptions
{
  public string BaseName { get; }
  public string NameSpace { get; }
  public GqlpBaseType BaseType { get; }
  public GqlpGeneratorType GeneratorType { get; }

  public string Warning { get; }

  public GqlpGeneratorOptions(string fullName, GqlpBaseType baseType, GqlpGeneratorType generatorType)
  {
    Warning = "";
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

  public GqlpGeneratorOptions(string warning)
  {
    Warning = warning;
    BaseName = string.Empty;
    NameSpace = string.Empty;
    BaseType = GqlpBaseType.Other;
    GeneratorType = GqlpGeneratorType.None;
  }
}
