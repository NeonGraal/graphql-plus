namespace GqlPlus.Verifier.Ast.Schema;

public abstract class AstScalarTests<TScalar, TMember, TOf>
  : AstAliasedTests
  where TScalar : AstScalar<TMember>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithMembers(string name, MemberInput<TOf> input)
      => Checks.HashCode(
        () => NewScalar(name, "", input.ScalarMembers(NewScalarMember)));

  [Theory, RepeatData(Repeats)]
  public void String_WithMembers(string name, MemberInput<TOf> input)
    => Checks.String(
      () => NewScalar(name, "", input.ScalarMembers(NewScalarMember)),
      $"( !S {name} {Kind} !SR {input} )");

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

  protected abstract TMember NewScalarMember(TOf? lower, TOf? upper);

  protected abstract TScalar NewScalar(string name, string input, TMember[] list);

  protected AstScalarTests()
  {
    Checks = new(name => NewScalar(name, "", []));
    var scalar = NewScalar("scalar", "", []);
    Kind = scalar.Kind.ToString();
  }
}

public record struct MemberInput<TOf>(TOf? Min, TOf? Max, int minCompareMax)
{
  internal readonly TOf? Lower => minCompareMax > 0 ? Max : Min;
  internal readonly TOf? Upper => minCompareMax > 0 ? Min : Max;

  public override readonly string ToString()
  {
    if (Lower is null) {
      return $"~ {Upper}";
    }

    var result = $"{Lower}";

    if (minCompareMax == 0) {
      return result;
    }

    result += " ~";

    if (Upper is not null) {
      result += $" {Upper}";
    }

    return result;
  }

  public readonly TAst[] ScalarMembers<TAst>(Func<TOf?, TOf?, TAst> factory)
    => new TAst[] { factory(Lower, Upper) };
}
