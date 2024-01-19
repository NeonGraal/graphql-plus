namespace GqlPlus.Verifier.Ast.Schema;

public abstract class AstScalarTests<TScalar, TMember, TOf>
  : AstAliasedTests
  where TScalar : AstScalar<TMember>
  where TMember : AstScalarMember
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithMembers(string name, MemberInput<TOf> input)
      => Checks.HashCode(
        () => NewScalar(name, "", input.ScalarMembers(NewScalarMember)));

  [Theory, RepeatData(Repeats)]
  public void String_WithMembers(string name, MemberInput<TOf> input)
    => Checks.String(
      () => NewScalar(name, "", input.ScalarMembers(NewScalarMember)),
      $"( !S {name} {Kind} !SR < {input.Lower} !SR ! {input.Lower} ~ {input.Upper} !SR {input.Upper} > )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithMembers(string name, MemberInput<TOf> input)
    => Checks.Equality(
      () => NewScalar(name, "", input.ScalarMembers(NewScalarMember)));

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenMembers(string name, MemberInput<TOf> input1, MemberInput<TOf> input2)
    => Checks.InequalityBetween(input1, input2,
      input => NewScalar(name, "", input.ScalarMembers(NewScalarMember)),
      input1 == input2);

  protected override string AliasesString(string input, string aliases)
    => $"( !S {input}{aliases} {Kind} )";

  internal readonly AstAliasedChecks<TScalar> Checks;
  internal readonly string Kind;

  internal override IAstAliasedChecks<string> AliasedChecks => Checks;

  protected abstract TMember NewScalarMember(TOf? lower, TOf? upper, bool? rightNull);

  protected abstract TScalar NewScalar(string name, string input, TMember[] list);

  protected AstScalarTests()
  {
    Checks = new(name => NewScalar(name, "", []));
    var scalar = NewScalar("scalar", "", []);
    Kind = scalar.Kind.ToString();
  }
}

public record struct MemberInput<TOf>(TOf Min, TOf Max, int minCompareMax)
{
  internal readonly TOf Lower => minCompareMax > 0 ? Max : Min;
  internal readonly TOf Upper => minCompareMax > 0 ? Min : Max;

  public override string ToString()
    => $"{Lower} ~ {Upper}";

  public readonly TMember[] ScalarMembers<TMember>(Func<TOf?, TOf?, bool?, TMember> factory)
    where TMember : AstScalarMember
    => new TMember[] { factory(default, Lower, false), factory(Lower, Upper, null) with { Excludes = true }, factory(Upper, default, true) };
}
