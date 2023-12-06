using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseScalar : DeclarationParser<TypeName, NullAst, NullAst, ScalarDefinition, ScalarDeclAst>
{
  public ParseScalar(
    TypeName name,
    Parser<NullAst>.DA param,
    Parser<string>.DA aliases,
    Parser<NullAst>.D option,
    Parser<ScalarDefinition>.D definition
  ) : base(name, param, aliases, option, definition) { }

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
  public ScalarRangeAst[] Ranges { get; set; } = Array.Empty<ScalarRangeAst>();
  public ScalarRegexAst[] Regexes { get; set; } = Array.Empty<ScalarRegexAst>();
}

internal class ParseScalarDefinition : Parser<ScalarDefinition>.I
{
  private readonly Parser<ScalarRangeAst>.LA _ranges;
  private readonly Parser<ScalarRegexAst>.LA _regexes;

  public ParseScalarDefinition(
    Parser<ScalarRangeAst>.DA ranges,
    Parser<ScalarRegexAst>.DA regexes)
  {
    _ranges = ranges;
    _regexes = regexes;
  }

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
      default:
        return tokens.Partial(label, "valid kind", () => result); // not covered
    }
  }
}

internal class ParseScalarRange : Parser<ScalarRangeAst>.I
{
  public IResult<ScalarRangeAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var at = tokens.At;
    var range = new ScalarRangeAst(at);
    var hasLower = tokens.Number(out var min);
    var excludesLower = tokens.Take('>');
    var hasRange = tokens.Take("..");
    if (hasLower && !hasRange) {
      return tokens.Error(label, "range operator ('..')", range);
    }

    var excludesUpper = tokens.Take('<');
    var hasUpper = tokens.Number(out var max);

    if (hasLower) {
      range.Lower = min;
      range.LowerExcluded = excludesLower;
    }

    if (hasUpper) {
      range.Upper = max;
      range.UpperExcluded = excludesUpper;
    }

    return hasLower || hasUpper
      ? range.Ok()
      : hasRange
        ? tokens.Error(label, "min or max bounds", range)
        : range.Empty();
  }
}

internal class ParseScalarRegex : Parser<ScalarRegexAst>.I
{
  public IResult<ScalarRegexAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ScalarRegexAst? result = null;
    var at = tokens.At;
    if (tokens.Regex(out var regex)) {
      var excluded = tokens.Take('!');
      result = new(at, regex, excluded);
      return result.Ok();
    }

    return result.Empty();
  }
}
