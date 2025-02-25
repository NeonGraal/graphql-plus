using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Schema.Simple;

public sealed class ParseDomainStringTests(
  IBaseDomainChecks<DomainStringInput, IGqlpDomain<IGqlpDomainRegex>> checks
) : BaseDomainTests<DomainStringInput, IGqlpDomain<IGqlpDomainRegex>>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void WithRegexes_ReturnsCorrectAst(DomainStringInput input, string regex)
    => checks.TrueExpected(
      input.Name + "{string/" + input.Regex + "/!/" + regex + "/}",
      NewDomain(input.Name, new[] { input.Regex, regex }.DomainRegexes()));

  [Theory, RepeatData(Repeats)]
  public void WithRegexesFirstBad_ReturnsFalse(string name)
    => checks.FalseExpected(name + "{string/}");

  [Theory, RepeatData(Repeats)]
  public void WithRegexesSecondBad_ReturnsFalse(DomainStringInput input, string regex)
    => checks.FalseExpected(input.Name + "{string/" + input.Regex + "/!/" + regex + "}");

  private static AstDomain<DomainRegexAst, IGqlpDomainRegex> NewDomain(string name, DomainRegexAst[] members)
    => new(AstNulls.At, name, DomainKind.String, members);
}

internal sealed class ParseDomainStringChecks(
  Parser<IGqlpDomain>.D parser
) : BaseDomainChecks<DomainStringInput, AstDomain<DomainRegexAst, IGqlpDomainRegex>, IGqlpDomain<IGqlpDomainRegex>>(parser, DomainKind.String)
{
  protected internal override AstDomain<DomainRegexAst, IGqlpDomainRegex> NamedFactory(DomainStringInput input)
    => new(AstNulls.At, input.Name, DomainKind.String, new[] { input.Regex }.DomainRegexes());

  protected internal override string AliasesString(DomainStringInput input, string aliases)
    => input.Name + aliases + "{string/" + input.Regex + "/}";
  protected internal override string KindString(DomainStringInput input, string kind, string parent)
    => input.Name + "{" + parent + kind + "/" + input.Regex + "/}";
}

public record struct DomainStringInput(string Name, string Regex);
