namespace GqlPlus.Verifier.Parse.Schema;

internal interface IBaseObjectChecks
{
  void WithMinimum(string name, string other);
  void WithTypeParameters(string name, string other, string parameter);
  void WithAliases(string name, string other, string[] aliases);
  void WithExtendsField(string name, string extends, string field, string fieldType);
  void WithExtendsGenericField(string name, string extends, string subType, string field, string fieldType);
  void WithAlternates(string name, string[] others);
  void WithFields(string name, FieldInput[] fields);
}

public record struct FieldInput(string Name, string Type);
