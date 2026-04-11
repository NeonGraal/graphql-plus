using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseDomain(
  IParserRepository parsers
) : SimpleParser<DomainDefinition, IAstDomain>(parsers)
{
  protected override IResult<IAstDomain> AsResult(AstPartial<NullAst, NullOption> partial, DomainDefinition value)
    => value.Kind == DomainKind.Enum ? MakeEnum(partial, value) : base.AsResult(partial, value);

  protected override IAstDomain MakeResult(AstPartial<NullAst, NullOption> partial, DomainDefinition value)
  {
    return value.Kind switch {
      DomainKind.Boolean => MakeBoolean(partial, value),
      DomainKind.Number => MakeNumber(partial, value),
      DomainKind.String => MakeString(partial, value),
      _ => MakeBoolean(partial, new() { Kind = DomainKind.Boolean }),
    };
  }

  private static AstDomain<DomainRegexAst, IAstDomainRegex> MakeString(AstPartial<NullAst, NullOption> partial, DomainDefinition value)
    => new(partial.At, partial.Name, value.Kind, value.Regexes) {
      Aliases = partial.Aliases,
      Description = partial.Description,
      Parent = value.Parent
    };

  private static AstDomain<DomainRangeAst, IAstDomainRange> MakeNumber(AstPartial<NullAst, NullOption> partial, DomainDefinition value)
    => new(partial.At, partial.Name, value.Kind, value.Numbers) {
      Aliases = partial.Aliases,
      Description = partial.Description,
      Parent = value.Parent
    };

  private static IResult<IAstDomain> MakeEnum(AstPartial<NullAst, NullOption> partial, DomainDefinition value)
  {
    AstDomain<DomainLabelAst, IAstDomainLabel> result = new(partial.At, partial.Name, value.Kind, value.Labels) {
      Aliases = partial.Aliases,
      Description = partial.Description,
      Parent = value.Parent
    };

    if (value.Labels.Length == 0) {
      return result.Partial<IAstDomain>(partial.Error("Invalid Domain Enum. Expected at least one Label"));
    }

    return result.Ok<IAstDomain>();
  }

  private static AstDomain<DomainTrueFalseAst, IAstDomainTrueFalse> MakeBoolean(AstPartial<NullAst, NullOption> partial, DomainDefinition value)
    => new(partial.At, partial.Name, value.Kind, value.Values) {
      Aliases = partial.Aliases,
      Description = partial.Description,
      Parent = value.Parent
    };

  protected override IAstDomain ToResult(AstPartial<NullAst, NullOption> partial)
    => new AstDomain<DomainTrueFalseAst, IAstDomainTrueFalse>(partial.At, partial.Name, partial.Description, DomainKind.Boolean) {
      Aliases = partial.Aliases,
      Description = partial.Description,
    };
}

public class DomainDefinition
  : SimpleDefinition
{
  public DomainKind Kind { get; set; } = DomainKind.Number;
  internal IAstDomainTrueFalse[] Values { get; set; } = [];
  internal IAstDomainLabel[] Labels { get; set; } = [];
  internal IAstDomainRange[] Numbers { get; set; } = [];
  internal IAstDomainRegex[] Regexes { get; set; } = [];
}

internal class ParseDomainDefinition
  : SimpleDefinitionParser<DomainDefinition>
{
  private readonly Parser<IEnumParser<DomainKind>, DomainKind>.L _kind;
  private readonly Dictionary<DomainKind, ParseItems> _kindParsers = [];

  public ParseDomainDefinition(
      IParserRepository parsers)
    : base(parsers)
  {
    _kind = parsers.ParserFor<IEnumParser<DomainKind>, DomainKind>();

    foreach (IParseDomain item in parsers.GetDomains()) {
      _kindParsers[item.Kind] = item.Parser;
    }
  }

  public override IResult<DomainDefinition> Parse(ITokenizer tokens, string label)
  {
    DomainDefinition result = new();

    if (!ParseParent(tokens, result)) {
      return tokens.Error(label, "parent type after ':'", result);
    }

    IResult<DomainKind> domainKind = _kind.I.Parse(tokens, label);
    if (!domainKind.Required(kind => result.Kind = kind)) {
      return result.Partial(domainKind.Message());
    } else {
      if (_kindParsers.TryGetValue(result.Kind, out ParseItems? parser)) {
        return parser(tokens, label, result);
      } else {
        return tokens.Partial(label, "valid kind", () => result);
      }
    }
  }
}
