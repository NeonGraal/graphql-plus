﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public sealed class ParseDomainEnumTests(
  Parser<IGqlpDomain>.D parser
) : BaseDomainTests<DomainEnumInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithEnumType_ReturnsCorrectAst(DomainEnumInput input, string enumType)
    => _checks.TrueExpected(
      input.Name + "{enum!" + enumType + "." + input.Member + "}",
      NewDomain(input, input.DomainMember(enumType)));

  [Theory, RepeatData(Repeats)]
  public void WithEnumAllMembers_ReturnsCorrectAst(DomainEnumInput input)
    => _checks.TrueExpected(
      input.Name + "{enum " + input.Member + ".* }",
      NewDomain(input, input.DomainAllMembers()));

  [Theory, RepeatData(Repeats)]
  public void WithMembers_ReturnsCorrectAst(DomainEnumInput input, string member)
    => _checks.TrueExpected(
      input.Name + "{enum!" + input.Member + " " + member + "}",
      NewDomain(input, input.DomainMembers(member)));

  [Theory, RepeatData(Repeats)]
  public void WithMembersExcludeBad_ReturnsFalse(string name)
    => _checks.FalseExpected(name + "{enum !}");

  [Theory, RepeatData(Repeats)]
  public void WithMembersFirstBad_ReturnsFalse(DomainEnumInput input)
    => _checks.FalseExpected(input.Name + "{enum " + input.Member + ".}");

  [Theory, RepeatData(Repeats)]
  public void WithMembersSecondBad_ReturnsFalse(DomainEnumInput input, string member)
    => _checks.FalseExpected(input.Name + "{enum " + input.Member + "!" + member + ".}");

  internal override IBaseDomainChecks<DomainEnumInput> DomainChecks => _checks;

  private readonly ParseDomainEnumChecks _checks = new(parser);

  private static AstDomain<DomainMemberAst, IGqlpDomainMember> NewDomain(DomainEnumInput input, DomainMemberAst[] members)
    => new(AstNulls.At, input.Name, DomainKind.Enum, members);
}

internal sealed class ParseDomainEnumChecks(
  Parser<IGqlpDomain>.D parser
) : BaseDomainChecks<DomainEnumInput, AstDomain>(parser, DomainKind.Enum)
{
  protected internal override AstDomain<DomainMemberAst, IGqlpDomainMember> NamedFactory(DomainEnumInput input)
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
