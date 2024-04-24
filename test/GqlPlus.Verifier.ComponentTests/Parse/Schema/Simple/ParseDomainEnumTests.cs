using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Parse.Schema.Simple;

public sealed class ParseDomainEnumTests(
  Parser<AstDomain>.D parser
) : BaseDomainTests<DomainEnumInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithEnumType_ReturnsCorrectAst(DomainEnumInput input, string enumType)
    => _checks.TrueExpected(
      input.Name + "{enum!" + enumType + "." + input.Member + "}",
      new AstDomain<DomainMemberAst>(AstNulls.At, input.Name, DomainKind.Enum, input.DomainMember(enumType)));

  [Theory, RepeatData(Repeats)]
  public void WithEnumAllMembers_ReturnsCorrectAst(DomainEnumInput input)
    => _checks.TrueExpected(
      input.Name + "{enum " + input.Member + ".* }",
      new AstDomain<DomainMemberAst>(AstNulls.At, input.Name, DomainKind.Enum, input.DomainAllMembers()));

  [Theory, RepeatData(Repeats)]
  public void WithMembers_ReturnsCorrectAst(DomainEnumInput input, string member)
    => _checks.TrueExpected(
      input.Name + "{enum!" + input.Member + " " + member + "}",
      new AstDomain<DomainMemberAst>(AstNulls.At, input.Name, DomainKind.Enum, input.DomainMembers(member)));

  [Theory, RepeatData(Repeats)]
  public void WithMembersExcludeBad_ReturnsFalse(string name)
    => _checks.False(name + "{enum !}");

  [Theory, RepeatData(Repeats)]
  public void WithMembersFirstBad_ReturnsFalse(DomainEnumInput input)
    => _checks.False(input.Name + "{enum " + input.Member + ".}");

  [Theory, RepeatData(Repeats)]
  public void WithMembersSecondBad_ReturnsFalse(DomainEnumInput input, string member)
    => _checks.False(input.Name + "{enum " + input.Member + "!" + member + ".}");

  internal override IBaseDomainChecks<DomainEnumInput> DomainChecks => _checks;

  private readonly ParseDomainEnumChecks _checks = new(parser);
}

internal sealed class ParseDomainEnumChecks(
  Parser<AstDomain>.D parser
) : BaseDomainChecks<DomainEnumInput, AstDomain>(parser, DomainKind.Enum)
{
  protected internal override AstDomain<DomainMemberAst> NamedFactory(DomainEnumInput input)
    => new(AstNulls.At, input.Name, DomainKind.Enum, input.DomainMembers());

  protected internal override string AliasesString(DomainEnumInput input, string aliases)
    => input.Name + aliases + "{enum !" + input.Member + "}";
  protected internal override string KindString(DomainEnumInput input, string kind, string parent)
    => input.Name + "{" + parent + kind + "!" + input.Member + "}";
}

public record struct DomainEnumInput(string Name, string Member)
{
  internal readonly DomainMemberAst[] DomainMember(string enumType)
      => [new(AstNulls.At, true, Member) { EnumType = enumType }];
  internal readonly DomainMemberAst[] DomainAllMembers()
      => [new(AstNulls.At, false, "*") { EnumType = Member }];

  internal readonly DomainMemberAst[] DomainMembers(params string[] members)
      => [.. members.Select(r => new DomainMemberAst(AstNulls.At, false, r)).Prepend(new(AstNulls.At, true, Member))];
}
