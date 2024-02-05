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
    => value.Kind switch {
      ScalarKind.Boolean => new AstScalar<ScalarFalseAst>(partial.At, partial.Name, value.Kind, []),
      ScalarKind.Enum => new AstScalar<ScalarMemberAst>(partial.At, partial.Name, value.Kind, value.Members),
      ScalarKind.Number => new AstScalar<ScalarRangeAst>(partial.At, partial.Name, value.Kind, value.Numbers),
      ScalarKind.String => new AstScalar<ScalarRegexAst>(partial.At, partial.Name, value.Kind, value.Regexes),
      ScalarKind.Union => new AstScalar<ScalarReferenceAst>(partial.At, partial.Name, value.Kind, value.References),
      _ => partial,
    } with {
      Aliases = partial.Aliases,
      Description = partial.Description,
      Parent = value.Parent
    };

  protected override bool ApplyOption(AstScalar result, IResult<NullOption> option) => true;
  protected override bool ApplyParameters(AstScalar result, IResultArray<NullAst> parameter) => true;

  [return: NotNull]
  protected override AstScalar<AstScalarItem> MakePartial(TokenAt at, string? name, string description)
    => new(at, name!, description, ScalarKind.Enum);
}

public class ScalarDefinition
{
  public ScalarKind Kind { get; set; } = ScalarKind.Number;
  public string? Parent { get; set; }
  public ScalarMemberAst[] Members { get; set; } = [];
  public ScalarRangeAst[] Numbers { get; set; } = [];
  public ScalarRegexAst[] Regexes { get; set; } = [];
  public ScalarReferenceAst[] References { get; set; } = [];
}

internal class ParseScalarDefinition
  : Parser<ScalarDefinition>.I
{
  private readonly Parser<IEnumParser<ScalarKind>, ScalarKind>.L _kind;

  private readonly Dictionary<ScalarKind, ParseItems> _kindParsers = [];

  public ParseScalarDefinition(
      Parser<IEnumParser<ScalarKind>, ScalarKind>.D kind,
      IEnumerable<IParseScalar> scalars)
  {
    _kind = kind;

    foreach (var item in scalars) {
      _kindParsers[item.Kind] = item.Parser;
    }
  }

  public IResult<ScalarDefinition> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ScalarDefinition result = new();

    if (tokens.Take(':')) {
      if (tokens.Identifier(out var parent)) {
        result.Parent = parent;
      } else {
        return tokens.Error(label, "type after ':'", result);
      }
    }

    var scalarKind = _kind.I.Parse(tokens, label);
    return !scalarKind.Required(kind => result.Kind = kind)
      ? scalarKind.AsResult(result)
      : _kindParsers.TryGetValue(result.Kind, out var parser)
        ? parser(tokens, label, result)
        : tokens.Partial(label, "valid kind", () => result);
  }
}
