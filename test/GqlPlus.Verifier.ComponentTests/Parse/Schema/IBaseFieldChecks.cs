namespace GqlPlus.Verifier.Parse.Schema;

internal interface IBaseFieldChecks
  : IBaseAliasedChecks<FieldInput>
{
  void WithMinimum(string name, string fieldType);
  void WithModifiers(string name, string fieldType);
  void WithModifiersBad(string name, string fieldType);
}

public record struct FieldInput(string Name, string Type);
