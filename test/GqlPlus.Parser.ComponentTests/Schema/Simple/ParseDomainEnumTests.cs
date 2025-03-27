using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Parsing;

namespace GqlPlus.Schema.Simple;

public sealed class ParseDomainEnumTests(
  IBaseDomainChecks<DomainEnumInput, IGqlpDomain<IGqlpDomainLabel>> checks
) : BaseDomainTests<DomainEnumInput, IGqlpDomain<IGqlpDomainLabel>>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void WithEnumType_ReturnsCorrectAst(DomainEnumInput input, string enumType)
    => checks.TrueExpected(
      input.Name + "{enum!" + enumType + "." + input.Member + "}",
      NewDomain(input, input.DomainLabel(enumType)));

  [Theory, RepeatData(Repeats)]
  public void WithEnumAllMembers_ReturnsCorrectAst(DomainEnumInput input)
    => checks.TrueExpected(
      input.Name + "{enum " + input.Member + ".* }",
      NewDomain(input, input.DomainAllMembers()));

  [Theory, RepeatData(Repeats)]
  public void WithMembers_ReturnsCorrectAst(DomainEnumInput input, string member)
    => checks.TrueExpected(
      input.Name + "{enum!" + input.Member + " " + member + "}",
      NewDomain(input, input.DomainLabels(member)));

  [Theory, RepeatData(Repeats)]
  public void WithMembersExcludeBad_ReturnsFalse(string name)
    => checks.FalseExpected(name + "{enum !}");

  [Theory, RepeatData(Repeats)]
  public void WithMembersFirstBad_ReturnsFalse(DomainEnumInput input)
    => checks.FalseExpected(input.Name + "{enum " + input.Member + ".}");

  [Theory, RepeatData(Repeats)]
  public void WithMembersSecondBad_ReturnsFalse(DomainEnumInput input, string member)
    => checks.FalseExpected(input.Name + "{enum " + input.Member + "!" + member + ".}");

  private static AstDomain<DomainLabelAst, IGqlpDomainLabel> NewDomain(DomainEnumInput input, DomainLabelAst[] members)
    => new(AstNulls.At, input.Name, DomainKind.Enum, members);
}

internal sealed class ParseDomainEnumChecks(
  Parser<IGqlpDomain>.D parser
) : BaseDomainChecks<DomainEnumInput, AstDomain<DomainLabelAst, IGqlpDomainLabel>, IGqlpDomain<IGqlpDomainLabel>>(parser, DomainKind.Enum)
{
  protected internal override AstDomain<DomainLabelAst, IGqlpDomainLabel> NamedFactory(DomainEnumInput input)
    => new(AstNulls.At, input.Name, DomainKind.Enum, input.DomainLabels());

  protected internal override string AliasesString(DomainEnumInput input, string aliases)
    => input.Name + aliases + "{enum !" + input.Member + "}";
  protected internal override string KindString(DomainEnumInput input, string kind, string parent)
    => input.Name + "{" + parent + kind + "!" + input.Member + "}";
}

public record struct DomainEnumInput(string Name, string Member)
{
  internal readonly DomainLabelAst[] DomainLabel(string enumType)
      => [new(AstNulls.At, "", true, Member) { EnumType = enumType }];
  internal readonly DomainLabelAst[] DomainAllMembers()
      => [new(AstNulls.At, "", false, "*") { EnumType = Member }];

  internal readonly DomainLabelAst[] DomainLabels(params string[] members)
      => [.. members.Select(r => new DomainLabelAst(AstNulls.At, "", false, r)).Prepend(new(AstNulls.At, "", true, Member))];
}
