namespace GqlPlus.Verifier.ClassTests.Parse.Schema;

internal interface IBaseFieldChecks
{
  void WithAliases(string name, string fieldType, string[] aliases);
  void WithMinimum(string name, string fieldType);
  void WithModifiers(string name, string fieldType);
}
