using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseScalar : DeclarationParser<TypeName, NullAst, NullAst, ScalarDefinition, ScalarAst>
{
  public ParseScalar(
    TypeName name,
    IParser<NullAst> param,
    IParserArray<string> aliases,
    IParser<NullAst> option,
    IParser<ScalarDefinition> definition
  ) : base(name, param, aliases, option, definition) { }

  protected override string Label => "Scalar";

  protected override bool ApplyDefinition(ScalarAst result, IResult<ScalarDefinition> definition)
    => definition.Required(value => {
      result.Kind = value.Kind;
      switch (result.Kind) {
        case ScalarKind.Number:
          result.Ranges = value.Ranges;
          break;

        case ScalarKind.String:
          result.Regexes = value.Regexes;
          break;

        default:
          break;//
      }
    });

  protected override bool ApplyOption(ScalarAst result, IResult<NullAst> option) => true;
  protected override bool ApplyParameter(ScalarAst result, IResult<NullAst> parameter) => true;

  [return: NotNull]
  protected override ScalarAst MakeResult(ParseAt at, string? name, string description)
    => new(at, name!, description);
}

internal class ScalarDefinition
{
  public ScalarKind Kind { get; set; } = ScalarKind.Number;
  public ScalarRangeAst[] Ranges { get; set; } = Array.Empty<ScalarRangeAst>();
  public ScalarRegexAst[] Regexes { get; set; } = Array.Empty<ScalarRegexAst>();
}

internal class ParseScalarDefinition : IParser<ScalarDefinition>
{
  private readonly IParserArray<ScalarRangeAst> _ranges;
  private readonly IParserArray<ScalarRegexAst> _regexes;

  public ParseScalarDefinition(
    IParserArray<ScalarRangeAst> ranges,
    IParserArray<ScalarRegexAst> regexes)
  {
    _ranges = ranges.ThrowIfNull();
    _regexes = regexes.ThrowIfNull();
  }

  public IResult<ScalarDefinition> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    ScalarDefinition result = new();

    var scalarKind = tokens.ParseEnumValue<ScalarKind>("Scalar");
    if (!scalarKind.Required(kind => result.Kind = kind)) {
      return scalarKind.AsResult(result);
    }

    switch (result.Kind) {
      case ScalarKind.Number:
        var scalarRanges = _ranges.Parse(tokens);
        if (scalarRanges.Required(ranges => result.Ranges = ranges)) {
          return tokens.End("Scalar", () => result);
        }

        return scalarRanges.AsResult(result);
      case ScalarKind.String:
        var scalarRegexes = _regexes.Parse(tokens);
        if (scalarRegexes.Required(regexes => result.Regexes = regexes)) {
          return tokens.End("Scalar", () => result);
        }

        return scalarRegexes.AsResult(result); // not covered
      default:
        return tokens.Partial("Scalar", "valid kind", () => result); // not covered
    }
  }
}

internal class ParseScalarRange : IParser<ScalarRangeAst>
{
  public IResult<ScalarRangeAst> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    var at = tokens.At;
    var range = new ScalarRangeAst(at);
    var hasLower = tokens.Number(out var min);
    var excludesLower = tokens.Take('>');
    var hasRange = tokens.Take("..");
    if (hasLower && !hasRange) {
      return tokens.Error("Scalar", "range operator ('..')", range);
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
        ? tokens.Error("Scalar", "min or max bounds", range)
        : range.Empty();
  }
}

internal class ParseScalarRegex : IParser<ScalarRegexAst>
{
  public IResult<ScalarRegexAst> Parse<TContext>(TContext tokens)
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
