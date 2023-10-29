namespace GqlPlus.Verifier.ClassTests.Parse.Schema;

internal interface IBaseReferenceChecks
{
  void WithMinimum(string name);
  void WithTypeParameter(string name);
  void WithTypeArguments(string name, string[] references);
}
