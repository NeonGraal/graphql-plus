using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Parsing;

namespace GqlPlus.Schema.Globals;

public sealed class ParseCategoryTests(
  IBaseAliasedChecks<string, IGqlpSchemaCategory> checks
) : BaseAliasedTests<string, IGqlpSchemaCategory>(checks)
{
  [Theory, RepeatData]
  public void WithOption_ReturnsCorrectAst(string output, CategoryOption option)
    => checks.OkResult(
      "{(" + option.ToString().ToLowerInvariant() + ")" + output + "}",
      new CategoryDeclAst(AstNulls.At, output) { Option = option });

  [Theory, RepeatData]
  public void WithOptionBad_ReturnsFalse(string output, CategoryOption option)
    => checks.ErrorResult(
      "{(" + option.ToString().ToLowerInvariant() + " " + output + "}",
      "')'");

  [Theory, RepeatData]
  public void WithOptionNone_ReturnsFalse(string output)
    => checks.ErrorResult("{()" + output, "");

  [Theory, RepeatData]
  public void WithName_ReturnsCorrectAst(string output, string name)
    => checks.OkResult(
      name + "{" + output + "}",
      new CategoryDeclAst(AstNulls.At, name, output));

  [Theory, RepeatData]
  public void WithOutputDescription_ReturnsCorrectAst(string output, string description)
    => checks.OkResult(
    "{'" + description + "'" + output + "}",
      new CategoryDeclAst(AstNulls.At, output) { OutputDescription = description });

  [Theory, RepeatData]
  public void WithModifers_ReturnsCorrectAst(string output)
    => checks.OkResult(
    "{" + output + "[]?}",
      new CategoryDeclAst(AstNulls.At, output) { Modifiers = TestMods() });

  [Theory, RepeatData]
  public void WithModifiersBad_ReturnsFalse(string output)
    => checks.FalseExpected("{" + output + "[?]");

  [Theory, RepeatData]
  public void WithAll_ReturnsCorrectAst(string name, string output, CategoryOption option, string[] aliases)
    => checks.OkResult(
      name + aliases.Bracket("[", "]{(").Joined() + option.ToString().ToLowerInvariant() + ")" + output + "[]?}",
      new CategoryDeclAst(AstNulls.At, name, output) {
        Aliases = aliases,
        Option = option,
        Modifiers = TestMods()
      });
}

internal sealed class ParseCategoryChecks(
  Parser<IGqlpSchemaCategory>.D parser
) : BaseAliasedChecks<string, CategoryDeclAst, IGqlpSchemaCategory>(parser)
{
  protected internal override CategoryDeclAst NamedFactory(string input)
    => new(AstNulls.At, input);
  protected internal override string AliasesString(string input, string aliases)
    => aliases + "{" + input + "}";
}
