namespace GqlPlus.Verifier.Parse.Schema;

internal interface IBaseAliasedChecks<I>
{
  void WithMinimum(I input);
  void WithAliases(I input, string[] aliases);
  void WithAliasesBad(I input, string[] aliases);
  void WithAliasesNone(I input);
}
