namespace GqlPlus.Verifier.Parse.Schema;

internal interface IBaseObjectChecks
{
  void WithMinimum(string name, string other);
  void WithTypeParameters(string name, string other, string parameter);
  void WithAliases(string name, string other, string[] aliases);
  void WithField(string name, string field, string fieldType);
  void WithFieldAlias(string name, string field, string alias, string fieldType);
  void WithFieldGeneric(string name, string field, string fieldType, string subType);
  void WithFieldModified(string name, string field, string fieldType);
  void WithExtendsField(string name, string extends, string field, string fieldType);
  void WithExtendsGenericField(string name, string extends, string subType, string field, string fieldType);
  void WithAlternates(string name, string[] others);
  void WithFields(string name, FieldInput[] fields);
}

public record struct FieldInput(string Name, string Type);
