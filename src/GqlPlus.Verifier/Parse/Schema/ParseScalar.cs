using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseScalar(
  ISimpleName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<NullAst>.D option,
  Parser<ScalarDefinition>.D definition
) : DeclarationParser<ISimpleName, NullAst, NullAst, ScalarDefinition, ScalarDeclAst>(name, param, aliases, option, definition)
{
  protected override void ApplyDefinition(ScalarDeclAst result, ScalarDefinition value)
  {
    result.Kind = value.Kind;
    switch (result.Kind) {
      case ScalarKind.Number:
        result.Ranges = value.Ranges;
        break;

      case ScalarKind.String:
        result.Regexes = value.Regexes;
        break;

      case ScalarKind.Union:
        result.References = value.References;
        break;

      default:
        break; // Not covered
    }
  }

  protected override bool ApplyOption(ScalarDeclAst result, IResult<NullAst> option) => true;
  protected override bool ApplyParameters(ScalarDeclAst result, IResultArray<NullAst> parameter) => true;

  [return: NotNull]
  protected override ScalarDeclAst MakeResult(TokenAt at, string? name, string description)
    => new(at, name!, description);
}

internal class ScalarDefinition
{
  public ScalarKind Kind { get; set; } = ScalarKind.Number;
  public ScalarRangeAst[] Ranges { get; set; } = [];
  public ScalarRegexAst[] Regexes { get; set; } = [];
  public ScalarReferenceAst[] References { get; set; } = [];
}

internal class ParseScalarDefinition(
  Parser<ScalarRangeAst>.DA ranges,
  Parser<ScalarReferenceAst>.DA references,
  Parser<ScalarRegexAst>.DA regexes
) : Parser<ScalarDefinition>.I
{
  private readonly Parser<ScalarRangeAst>.LA _ranges = ranges;
  private readonly Parser<ScalarReferenceAst>.LA _references = references;
  private readonly Parser<ScalarRegexAst>.LA _regexes = regexes;

  public IResult<ScalarDefinition> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ScalarDefinition result = new();

    var scalarKind = tokens.ParseEnumValue<ScalarKind>(label);
    if (!scalarKind.Required(kind => result.Kind = kind)) {
      return scalarKind.AsResult(result);
    }

    switch (result.Kind) {
      case ScalarKind.Number:
        var scalarRanges = _ranges.Parse(tokens, label);
        if (scalarRanges.Required(ranges => result.Ranges = ranges)) {
          return tokens.End(label, () => result);
        }

        return scalarRanges.AsResult(result);
      case ScalarKind.String:
        var scalarRegexes = _regexes.Parse(tokens, label);
        if (scalarRegexes.Required(regexes => result.Regexes = regexes)) {
          return tokens.End(label, () => result);
        }

        return scalarRegexes.AsResult(result); // not covered
      case ScalarKind.Union:
        var scalarReferences = _references.Parse(tokens, label);
        if (scalarReferences.Required(references => result.References = references)) {
          return tokens.End(label, () => result);
        }

        return scalarReferences.AsResult(result); // not covered
      default:
        return tokens.Partial(label, "valid kind", () => result); // not covered
    }
  }
}
