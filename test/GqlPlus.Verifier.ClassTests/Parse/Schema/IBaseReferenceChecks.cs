namespace GqlPlus.Verifier.Parse.Schema;

public interface IBaseReferenceChecks
{
  void WithMinimum(string name);
  void WithTypeParameter(string name);
  void WithTypeParameterBad();
  void WithTypeArguments(string name, string[] references);
  void WithTypeArgumentsBad(string name, string[] references);
  void WithTypeArgumentsNone(string name);
}
