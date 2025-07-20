namespace GqlPlus;

internal class GqlpGeneratorOptions
{
  public string BaseName { get; }
  public string NameSpace { get; }
  public GqlpGeneratorType Types { get; }

  public GqlpGeneratorOptions(string fullName, GqlpGeneratorType types)
  {
    string[] names = fullName.Split('.');

    if (names.Length > 1) {
      BaseName = names.Last();
      NameSpace = string.Join(".", names.Take(names.Length - 1));
    } else {
      BaseName = fullName;
      NameSpace = string.Empty;
    }

    Types = types;
  }
}
