namespace GqlPlus.Verifier.Ast.Schema.Types;

public abstract class AstScalarTests<TInput, TMember>
  : AstTypeTests
  where TInput : IEquatable<TInput>
  where TMember : IAstScalarItem
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithMembers(string name, TInput input)
      => Checks.HashCode(
        () => NewScalar(name, ScalarMembers(input)));

  [Theory, RepeatData(Repeats)]
  public void String_WithMembers(string name, TInput input)
    => Checks.Text(
      () => NewScalar(name, ScalarMembers(input)),
      MembersString(name, input));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithMembers(string name, TInput input)
    => Checks.Equality(
      () => NewScalar(name, ScalarMembers(input)));

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenMembers(string name, TInput input1, TInput input2)
    => Checks.InequalityBetween(input1, input2,
      input => NewScalar(name, ScalarMembers(input)),
      input1.NullEqual(input2));

  protected override string AliasesString(string input, string aliases)
    => $"( !S {input}{aliases} {Kind.Value} )";

  internal readonly AstTypeChecks<AstScalar<TMember>> Checks;
  internal readonly Lazy<string> Kind;

  internal override IAstTypeChecks TypeChecks => Checks;

  protected override string ParentString(string name, string parent)
    => $"( !{AliasedChecks.Abbr} {name} {Kind.Value} :{parent} )";

  protected abstract string MembersString(string name, TInput input);
  protected abstract TMember[] ScalarMembers(TInput input);
  protected abstract AstScalar<TMember> NewScalar(string name, TMember[] list);

  protected AstScalarTests()
  {
    Checks = new(name => NewScalar(name, []));
    Kind = new(() => NewScalar("scalar", []).Domain.ToString());
  }
}
