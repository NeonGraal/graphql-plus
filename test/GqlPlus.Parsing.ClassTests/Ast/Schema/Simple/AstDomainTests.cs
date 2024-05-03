namespace GqlPlus.Ast.Schema.Simple;

public abstract class AstDomainTests<TInput, TMember>
  : AstTypeTests
  where TInput : IEquatable<TInput>
  where TMember : AstAbbreviated, IAstDomainItem
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithMembers(string name, TInput input)
      => Checks.HashCode(
        () => NewDomain(name, DomainMembers(input)));

  [Theory, RepeatData(Repeats)]
  public void String_WithMembers(string name, TInput input)
    => Checks.Text(
      () => NewDomain(name, DomainMembers(input)),
      MembersString(name, input));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithMembers(string name, TInput input)
    => Checks.Equality(
      () => NewDomain(name, DomainMembers(input)));

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenMembers(string name, TInput input1, TInput input2)
    => Checks.InequalityBetween(input1, input2,
      input => NewDomain(name, DomainMembers(input)),
      input1.NullEqual(input2));

  protected override string AliasesString(string input, string aliases)
    => $"( !Do {input}{aliases} {Kind.Value} )";

  internal readonly AstTypeChecks<AstDomain<TMember>> Checks;
  internal readonly Lazy<string> Kind;

  internal override IAstTypeChecks TypeChecks => Checks;

  protected override string ParentString(string name, string parent)
    => $"( !{AliasedChecks.Abbr} {name} {Kind.Value} :{parent} )";

  protected abstract string MembersString(string name, TInput input);
  protected abstract TMember[] DomainMembers(TInput input);
  protected abstract AstDomain<TMember> NewDomain(string name, TMember[] list);

  protected AstDomainTests()
  {
    Checks = new(name => NewDomain(name, []));
    Kind = new(() => NewDomain("domainKind", []).DomainKind.ToString());
  }
}
