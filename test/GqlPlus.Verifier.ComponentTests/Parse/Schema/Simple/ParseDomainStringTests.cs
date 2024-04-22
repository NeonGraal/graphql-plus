using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Parse.Schema.Types;

public sealed class ParseDomainStringTests(
  Parser<AstDomain>.D parser
) : BaseDomainTests<DomainStringInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithRegexes_ReturnsCorrectAst(DomainStringInput input, string regex)
    => _checks.TrueExpected(
      input.Name + "{string/" + input.Regex + "/!/" + regex + "/}",
      new AstDomain<DomainRegexAst>(AstNulls.At, input.Name, DomainDomain.String, new[] { input.Regex, regex }.DomainRegexes()));

  [Theory, RepeatData(Repeats)]
  public void WithRegexesFirstBad_ReturnsFalse(string name)
    => _checks.False(name + "{string/}");

  [Theory, RepeatData(Repeats)]
  public void WithRegexesSecondBad_ReturnsFalse(DomainStringInput input, string regex)
    => _checks.False(input.Name + "{string/" + input.Regex + "/!/" + regex + "}");

  internal override IBaseDomainChecks<DomainStringInput> DomainChecks => _checks;

  private readonly ParseDomainStringChecks _checks = new(parser);
}

internal sealed class ParseDomainStringChecks(
  Parser<AstDomain>.D parser
) : BaseDomainChecks<DomainStringInput, AstDomain>(parser, DomainDomain.String)
{
  protected internal override AstDomain<DomainRegexAst> NamedFactory(DomainStringInput input)
    => new(AstNulls.At, input.Name, DomainDomain.String, new[] { input.Regex }.DomainRegexes());

  protected internal override string AliasesString(DomainStringInput input, string aliases)
    => input.Name + aliases + "{string/" + input.Regex + "/}";
  protected internal override string KindString(DomainStringInput input, string kind, string parent)
    => input.Name + "{" + parent + kind + "/" + input.Regex + "/}";
}

public record struct DomainStringInput(string Name, string Regex);
