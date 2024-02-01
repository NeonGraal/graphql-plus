namespace GqlPlus.Verifier.Ast.Schema;

public abstract class AstScalarTests<TInput, TMember>
  : AstAliasedTests
  where TInput : IEquatable<TInput>
  where TMember : IAstScalarItem
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithMembers(string name, TInput input)
      => Checks.HashCode(
        () => NewScalar(name, ScalarMembers(input)));

  [Theory, RepeatData(Repeats)]
  public void String_WithMembers(string name, TInput input)
    => Checks.String(
      () => NewScalar(name, ScalarMembers(input)),
      MembersString(name, input));
  //$"( !S {name} {Kind} !SR {input} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithMembers(string name, TInput input)
    => Checks.Equality(
      () => NewScalar(name, ScalarMembers(input)));

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenMembers(string name, TInput input1, TInput input2)
    => Checks.InequalityBetween(input1, input2,
      input => NewScalar(name, ScalarMembers(input)),
      input1.NullEqual(input2));

  protected override string AliasesString(string input, string aliases)
    => $"( !S {input}{aliases} {Kind} )";

  internal readonly AstAliasedChecks<AstScalar<TMember>> Checks;
  internal readonly string Kind;

  internal override IAstAliasedChecks<string> AliasedChecks => Checks;

  protected abstract string MembersString(string name, TInput input);
  protected abstract TMember[] ScalarMembers(TInput input);
  protected abstract AstScalar<TMember> NewScalar(string name, TMember[] list);

  protected AstScalarTests()
  {
    Checks = new(name => NewScalar(name, []));
    var scalar = NewScalar("scalar", []);
    Kind = scalar.Kind.ToString();
  }
}
