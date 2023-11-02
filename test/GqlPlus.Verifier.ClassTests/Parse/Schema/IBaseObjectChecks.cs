namespace GqlPlus.Verifier.Parse.Schema;

internal interface IBaseObjectChecks
  : IBaseAliasedChecks<ObjectInput>
{
  void WithTypeParameters(string name, string other, string parameter);
  void WithTypeParametersBad(string name, string other, string parameter);
  void WithExtendsField(string name, string extends, string field, string fieldType);
  void WithExtendsFieldBad(string name, string extends, string field, string fieldType);
  void WithExtendsGenericField(string name, string extends, string subType, string field, string fieldType);
  void WithExtendsGenericFieldBad(string name, string extends, string subType, string field, string fieldType);
  void WithAlternates(string name, string[] others);
  void WithAlternateComments(string name, AlternateComment[] others);
  void WithFields(string name, FieldInput[] fields);
  void WithFieldsBad(string name, FieldInput[] fields);
  void WithFieldsAndAlternates(string name, FieldInput[] fields, string[] others);
  void WithFieldsBadAndAlternates(string name, FieldInput[] fields, string[] others);
  void WithFieldsAndAlternatesBad(string name, FieldInput[] fields, string[] others);
}
