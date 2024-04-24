using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Simple;

internal class ParseDomain(
  ISimpleName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<DomainDefinition>.D definition
) : DeclarationParser<DomainDefinition, AstDomain>(name, param, aliases, option, definition)
{
  protected override AstDomain MakeResult(AstDomain partial, DomainDefinition value)
    => value.Kind switch {
      DomainKind.Boolean => new AstDomain<DomainTrueFalseAst>(partial.At, partial.Name, value.Kind, value.Values),
      DomainKind.Enum => new AstDomain<DomainMemberAst>(partial.At, partial.Name, value.Kind, value.Members),
      DomainKind.Number => new AstDomain<DomainRangeAst>(partial.At, partial.Name, value.Kind, value.Numbers),
      DomainKind.String => new AstDomain<DomainRegexAst>(partial.At, partial.Name, value.Kind, value.Regexes),
      _ => partial,
    } with {
      Aliases = partial.Aliases,
      Description = partial.Description,
      Parent = value.Parent
    };

  protected override bool ApplyOption(AstDomain result, IResult<NullOption> option) => true;
  protected override bool ApplyParameters(AstDomain result, IResultArray<NullAst> parameter) => true;

  [return: NotNull]
  protected override AstDomain<AstDomainItem> MakePartial(TokenAt at, string? name, string description)
    => new(at, name!, description, DomainKind.Enum);
}

public class DomainDefinition
{
  public DomainKind Kind { get; set; } = DomainKind.Number;
  public string? Parent { get; set; }
  public DomainTrueFalseAst[] Values { get; set; } = [];
  public DomainMemberAst[] Members { get; set; } = [];
  public DomainRangeAst[] Numbers { get; set; } = [];
  public DomainRegexAst[] Regexes { get; set; } = [];
}

internal class ParseDomainDefinition
  : Parser<DomainDefinition>.I
{
  private readonly Parser<IEnumParser<DomainKind>, DomainKind>.L _kind;

  private readonly Dictionary<DomainKind, ParseItems> _kindParsers = [];

  public ParseDomainDefinition(
      Parser<IEnumParser<DomainKind>, DomainKind>.D kind,
      IEnumerable<IParseDomain> domains)
  {
    _kind = kind;

    foreach (var item in domains) {
      _kindParsers[item.Kind] = item.Parser;
    }
  }

  public IResult<DomainDefinition> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    DomainDefinition result = new();

    if (tokens.Take(':')) {
      if (tokens.Identifier(out var parent)) {
        result.Parent = parent;
      } else {
        return tokens.Error(label, "type after ':'", result);
      }
    }

    var domainKind = _kind.I.Parse(tokens, label);
    return !domainKind.Required(kind => result.Kind = kind)
      ? domainKind.AsResult(result)
      : _kindParsers.TryGetValue(result.Kind, out var parser)
        ? parser(tokens, label, result)
        : tokens.Partial(label, "valid kind", () => result);
  }
}
