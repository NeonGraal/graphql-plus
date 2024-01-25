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
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ScalarDefinition>.D definition
) : DeclarationParser<ScalarDefinition, AstScalar>(name, param, aliases, option, definition)
{
  protected override AstScalar MakeResult(AstScalar partial, ScalarDefinition value)
    => value.Kind switch
    {
      ScalarKind.Number => new AstScalar<ScalarRangeAst>(partial.At, partial.Name, value.Kind, value.Numbers)
      {
        Aliases = partial.Aliases,
        Description = partial.Description,
        Extends = value.Extends
      },
      ScalarKind.String => new AstScalar<ScalarRegexAst>(partial.At, partial.Name, value.Kind, value.Regexes)
      {
        Aliases = partial.Aliases,
        Description = partial.Description,
        Extends = value.Extends
      },
      ScalarKind.Union => new AstScalar<ScalarReferenceAst>(partial.At, partial.Name, value.Kind, value.References)
      {
        Aliases = partial.Aliases,
        Description = partial.Description,
        Extends = value.Extends
      },
      _ => partial,
    };

  protected override bool ApplyOption(AstScalar result, IResult<NullOption> option) => true;
  protected override bool ApplyParameters(AstScalar result, IResultArray<NullAst> parameter) => true;

  [return: NotNull]
  protected override AstScalar<AstScalarMember> MakePartial(TokenAt at, string? name, string description)
    => new(at, name!, description, ScalarKind.Enum);
}

internal class ScalarDefinition
{
  public ScalarKind Kind { get; set; } = ScalarKind.Number;
  public string? Extends { get; set; }
  public ScalarRangeAst[] Numbers { get; set; } = [];
  public ScalarRegexAst[] Regexes { get; set; } = [];
  public ScalarReferenceAst[] References { get; set; } = [];
}

internal class ParseScalarDefinition(
  Parser<IEnumParser<ScalarKind>, ScalarKind>.D kind,
  Parser<ScalarRangeAst>.DA numbers,
  Parser<ScalarReferenceAst>.DA references,
  Parser<ScalarRegexAst>.DA regexes
) : Parser<ScalarDefinition>.I
{
  private readonly Parser<IEnumParser<ScalarKind>, ScalarKind>.L _kind = kind;
  private readonly Parser<ScalarRangeAst>.LA _numbers = numbers;
  private readonly Parser<ScalarReferenceAst>.LA _references = references;
  private readonly Parser<ScalarRegexAst>.LA _regexes = regexes;

  public IResult<ScalarDefinition> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ScalarDefinition result = new();

    var scalarKind = _kind.I.Parse(tokens, label);
    if (!scalarKind.Required(kind => result.Kind = kind))
    {
      return scalarKind.AsResult(result);
    }

    switch (result.Kind)
    {
      case ScalarKind.Number:
        var scalarRanges = _numbers.Parse(tokens, label);
        if (scalarRanges.Required(ranges => result.Numbers = ranges))
        {
          return tokens.End(label, () => result);
        }

        return scalarRanges.AsResult(result);
      case ScalarKind.String:
        var scalarRegexes = _regexes.Parse(tokens, label);
        if (scalarRegexes.Required(regexes => result.Regexes = regexes))
        {
          return tokens.End(label, () => result);
        }

        return scalarRegexes.AsResult(result);
      case ScalarKind.Union:
        var scalarReferences = _references.Parse(tokens, label);
        if (scalarReferences.Required(references => result.References = references))
        {
          return tokens.End(label, () => result);
        }

        return scalarReferences.AsResult(result);
      default:
        return tokens.Partial(label, "valid kind", () => result);
    }
  }
}
