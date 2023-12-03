namespace GqlPlus.Verifier.Ast.Schema;

internal sealed class BaseAliasedAstChecks<T>
  : BaseAliasedAstChecks<string, T>, IBaseAliasedAstChecks
  where T : AstAliased
{
  public BaseAliasedAstChecks(CreateBy<string> create)
    : base(create) { }
}

internal class BaseAliasedAstChecks<I, T>
  : BaseNamedAstChecks<I, T>, IBaseAliasedAstChecks<I>
  where T : AstAliased
{
  public BaseAliasedAstChecks(CreateBy<I> create)
    : base(create) { }

  public void HashCode(I input, params string[] aliases)
    => HashCode(
      () => CreateAliases(input, aliases),
      _createExpression);

  public void Equality(I input, params string[] aliases)
    => Equality(
      () => CreateAliases(input, aliases),
      _createExpression);

  public void Inequality_WithAliases(I input, params string[] aliases)
    => Inequality(
      () => CreateAliases(input, aliases),
      () => CreateInput(input),
      factoryExpression: _createExpression);

  public void Inequality_ByAliased(I input, string aliased1, string aliased2)
    => InequalityBetween(aliased1, aliased2,
      aliased => CreateAliases(input, aliased),
      aliased1 == aliased2, _createExpression);

  public void Inequality_ByInputs(I input1, I input2, string aliased)
    => InequalityBetween(input1, input2,
      input => CreateAliases(input, aliased),
      input1!.Equals(input2), _createExpression);

  public void String(I input, string expected, params string[] aliases)
    => String(
      () => CreateAliases(input, aliases), expected,
      factoryExpression: _createExpression);

  public string AliasesString(I input, params string[] aliases)
    => $"( !{Abbr} {input} [ {aliases.Joined()} ] )";

  private T CreateAliases(I input, params string[] aliases)
    => CreateInput(input) with { Aliases = aliases };
}

internal interface IBaseAliasedAstChecks
  : IBaseAliasedAstChecks<string>, IBaseNamedAstChecks
{ }

internal interface IBaseAliasedAstChecks<I> : IBaseNamedAstChecks<I>
{
  void HashCode(I input, params string[] aliases);
  void String(I input, string expected, params string[] aliases);
  void Equality(I input, params string[] aliases);
  void Inequality_WithAliases(I input, params string[] aliases);
  void Inequality_ByInputs(I input1, I input2, string aliased);
  void Inequality_ByAliased(I input, string aliased1, string aliased2);
  string AliasesString(I input, params string[] aliases);
}
