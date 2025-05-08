using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

public abstract class AstDomainTests<TInput>
  : AstTypeTests
  where TInput : IEquatable<TInput>
{
  [Theory, RepeatData]
  public void HashCode_WithItems(string name, TInput input)
      => Checks.HashCode_WithItems(name, input);

  [Theory, RepeatData]
  public void String_WithItems(string name, TInput input)
    => Checks.String_WithItems(name, input);

  [Theory, RepeatData]
  public void Equality_WithItems(string name, TInput input)
    => Checks.Equality_WithItems(name, input);

  [Theory, RepeatData]
  public void Inequality_BetweenItems(string name, TInput input1, TInput input2)
    => Checks.Inequality_BetweenItems(name, input1, input2);

  protected override string AliasesString(string input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} {Checks.Kind} )";

  internal abstract IAstDomainChecks<TInput> Checks { get; }

  internal override IAstTypeChecks TypeChecks => Checks;

  protected override string ParentString(string name, string parent)
    => $"( !{AliasedChecks.Abbr} {name} {Checks.Kind} :{parent} )";
}

internal abstract class AstDomainChecks<TInput, TItemAst, TItem>(
  DomainKind kind
) : AstTypeChecks<AstDomain<TItemAst, TItem>>(
    input => new AstDomain<TItemAst, TItem>(AstNulls.At, input, kind, [])
  ), IAstDomainChecks<TInput>
  where TInput : IEquatable<TInput>
  where TItemAst : AstAbbreviated, TItem
  where TItem : IGqlpDomainItem
{
  public DomainKind Kind { get; } = kind;

  public void Equality_WithItems(string name, TInput input)
    => Equality(() => NewDomain(name, DomainItems(input)));

  public void HashCode_WithItems(string name, TInput input)
    => HashCode(() => NewDomain(name, DomainItems(input)));

  public void Inequality_BetweenItems(string name, TInput input1, TInput input2)
    => InequalityBetween(input1, input2,
      input => NewDomain(name, DomainItems(input)),
      SkipEquals(input1, input2));

  public void String_WithItems(string name, TInput input)
    => Text(
      () => NewDomain(name, DomainItems(input)),
      ItemsString(name, input));

  protected virtual bool SkipEquals(TInput input1, TInput input2)
    => input1.NullEqual(input2);

  protected abstract string ItemsString(string name, TInput input);
  protected abstract TItemAst[] DomainItems(TInput input);
  protected abstract AstDomain<TItemAst, TItem> NewDomain(string name, TItemAst[] list);
}

internal interface IAstDomainChecks<TInput>
  : IAstTypeChecks
  where TInput : IEquatable<TInput>
{
  DomainKind Kind { get; }

  void HashCode_WithItems(string name, TInput input);
  void String_WithItems(string name, TInput input);
  void Equality_WithItems(string name, TInput input);
  void Inequality_BetweenItems(string name, TInput input1, TInput input2);
}
