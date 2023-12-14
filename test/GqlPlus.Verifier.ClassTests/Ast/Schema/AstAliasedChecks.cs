namespace GqlPlus.Verifier.Ast.Schema;

internal sealed class AstAliasedChecks<TAliased>
  : AstAliasedChecks<string, TAliased>, IAstAliasedChecks
  where TAliased : AstAliased
{
  public AstAliasedChecks(CreateBy<string> create)
    : base(create) { }
}

internal class AstAliasedChecks<TInput, TAliased>
  : AstBaseChecks<TInput, TAliased>, IAstAliasedChecks<TInput>
  where TAliased : AstAliased
{
  public AstAliasedChecks(CreateBy<TInput> create)
    : base(create) { }

  public void HashCode(TInput input, params string[] aliases)
    => HashCode(
      () => CreateAliases(input, aliases),
      _createExpression);

  public void Equality(TInput input, params string[] aliases)
    => Equality(
      () => CreateAliases(input, aliases),
      _createExpression);

  public void Inequality_WithAliases(TInput input, params string[] aliases)
    => Inequality(
      () => CreateAliases(input, aliases),
      () => CreateInput(input),
      factoryExpression: _createExpression);

  public void Inequality_ByAliased(TInput input, string aliased1, string aliased2)
    => InequalityBetween(aliased1, aliased2,
      aliased => CreateAliases(input, aliased),
      aliased1 == aliased2, _createExpression);

  public void Inequality_ByInputs(TInput input1, TInput input2, string aliased)
    => InequalityBetween(input1, input2,
      input => CreateAliases(input, aliased),
      input1!.Equals(input2), _createExpression);

  public void String(TInput input, string expected, params string[] aliases)
    => String(
      () => CreateAliases(input, aliases), expected,
      factoryExpression: _createExpression);

  public string AliasesString(TInput input, params string[] aliases)
    => $"( !{Abbr} {input} [ {aliases.Joined()} ] )";

  private TAliased CreateAliases(TInput input, params string[] aliases)
    => CreateInput(input) with { Aliases = aliases };
}

internal interface IAstAliasedChecks
  : IAstAliasedChecks<string>, IAstBaseChecks
{ }

internal interface IAstAliasedChecks<TInput> : IAstBaseChecks<TInput>
{
  void HashCode(TInput input, params string[] aliases);
  void String(TInput input, string expected, params string[] aliases);
  void Equality(TInput input, params string[] aliases);
  void Inequality_WithAliases(TInput input, params string[] aliases);
  void Inequality_ByInputs(TInput input1, TInput input2, string aliased);
  void Inequality_ByAliased(TInput input, string aliased1, string aliased2);
  string AliasesString(TInput input, params string[] aliases);
}
