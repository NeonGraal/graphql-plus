using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

public abstract class AstDomainTests<TInput>
  : AstTypeTests
  where TInput : IEquatable<TInput>
{
  [Theory, RepeatData]
  public void HashCode_WithMembers(string name, TInput input)
      => Checks.HashCode_WithMembers(name, input);

  [Theory, RepeatData]
  public void String_WithMembers(string name, TInput input)
    => Checks.String_WithMembers(name, input);

  [Theory, RepeatData]
  public void Equality_WithMembers(string name, TInput input)
    => Checks.Equality_WithMembers(name, input);

  [SkippableTheory, RepeatData]
  public void Inequality_BetweenMembers(string name, TInput input1, TInput input2)
    => Checks.Inequality_BetweenMembers(name, input1, input2);

  protected override string AliasesString(string input, string aliases)
    => $"( !Do {input}{aliases} {Checks.Kind} )";

  internal abstract IAstDomainChecks<TInput> Checks { get; }

  internal override IAstTypeChecks TypeChecks => Checks;

  protected override string ParentString(string name, string parent)
    => $"( !{AliasedChecks.Abbr} {name} {Checks.Kind} :{parent} )";
}

internal abstract class AstDomainChecks<TInput, TMember, TItem>(
  DomainKind kind
) : AstTypeChecks<AstDomain<TMember, TItem>>(
    input => new AstDomain<TMember, TItem>(AstNulls.At, input, kind, [])
  ), IAstDomainChecks<TInput>
  where TInput : IEquatable<TInput>
  where TMember : AstAbbreviated, TItem
  where TItem : IGqlpDomainItem
{
  public DomainKind Kind { get; } = kind;

  public void Equality_WithMembers(string name, TInput input)
    => Equality(() => NewDomain(name, DomainMembers(input)));

  public void HashCode_WithMembers(string name, TInput input)
    => HashCode(() => NewDomain(name, DomainMembers(input)));

  public void Inequality_BetweenMembers(string name, TInput input1, TInput input2)
    => InequalityBetween(input1, input2,
      input => NewDomain(name, DomainMembers(input)),
      SkipEquals(input1, input2));

  public void String_WithMembers(string name, TInput input)
    => Text(
      () => NewDomain(name, DomainMembers(input)),
      MembersString(name, input));

  protected virtual bool SkipEquals(TInput input1, TInput input2)
    => input1.NullEqual(input2);

  protected abstract string MembersString(string name, TInput input);
  protected abstract TMember[] DomainMembers(TInput input);
  protected abstract AstDomain<TMember, TItem> NewDomain(string name, TMember[] list);
}

internal interface IAstDomainChecks<TInput>
  : IAstTypeChecks
  where TInput : IEquatable<TInput>
{
  DomainKind Kind { get; }

  void HashCode_WithMembers(string name, TInput input);
  void String_WithMembers(string name, TInput input);
  void Equality_WithMembers(string name, TInput input);
  void Inequality_BetweenMembers(string name, TInput input1, TInput input2);
}
