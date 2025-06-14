﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseDomain(
  ISimpleName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<DomainDefinition>.D definition
) : SimpleParser<DomainDefinition, IGqlpDomain>(name, param, aliases, option, definition)
{
  protected override IResult<IGqlpDomain> AsResult(AstPartial<NullAst, NullOption> partial, DomainDefinition value)
    => value.Kind == DomainKind.Enum ? MakeEnum(partial, value) : base.AsResult(partial, value);

  protected override IGqlpDomain MakeResult(AstPartial<NullAst, NullOption> partial, DomainDefinition value)
  {
    return value.Kind switch {
      DomainKind.Boolean => MakeBoolean(partial, value),
      DomainKind.Number => MakeNumber(partial, value),
      DomainKind.String => MakeString(partial, value),
      _ => MakeBoolean(partial, new() { Kind = DomainKind.Boolean }),
    };
  }

  private static AstDomain<DomainRegexAst, IGqlpDomainRegex> MakeString(AstPartial<NullAst, NullOption> partial, DomainDefinition value)
    => new(partial.At, partial.Name, value.Kind, value.Regexes) {
      Aliases = partial.Aliases,
      Description = partial.Description,
      Parent = value.Parent
    };

  private static AstDomain<DomainRangeAst, IGqlpDomainRange> MakeNumber(AstPartial<NullAst, NullOption> partial, DomainDefinition value)
    => new(partial.At, partial.Name, value.Kind, value.Numbers) {
      Aliases = partial.Aliases,
      Description = partial.Description,
      Parent = value.Parent
    };

  private static IResult<IGqlpDomain> MakeEnum(AstPartial<NullAst, NullOption> partial, DomainDefinition value)
  {
    AstDomain<DomainLabelAst, IGqlpDomainLabel> result = new(partial.At, partial.Name, value.Kind, value.Labels) {
      Aliases = partial.Aliases,
      Description = partial.Description,
      Parent = value.Parent
    };

    if (value.Labels.Length == 0) {
      return result.Partial<IGqlpDomain>(partial.Error("Invalid Domain Enum. Expected at least one Label"));
    }

    return result.Ok<IGqlpDomain>();
  }

  private static AstDomain<DomainTrueFalseAst, IGqlpDomainTrueFalse> MakeBoolean(AstPartial<NullAst, NullOption> partial, DomainDefinition value)
    => new(partial.At, partial.Name, value.Kind, value.Values) {
      Aliases = partial.Aliases,
      Description = partial.Description,
      Parent = value.Parent
    };

  protected override IGqlpDomain ToResult(AstPartial<NullAst, NullOption> partial)
    => new AstDomain<DomainTrueFalseAst, IGqlpDomainTrueFalse>(partial.At, partial.Name, partial.Description, DomainKind.Boolean) {
      Aliases = partial.Aliases,
      Description = partial.Description,
    };
}

internal class DomainDefinition
  : SimpleDefinition
{
  public DomainKind Kind { get; set; } = DomainKind.Number;
  internal IGqlpDomainTrueFalse[] Values { get; set; } = [];
  internal IGqlpDomainLabel[] Labels { get; set; } = [];
  internal IGqlpDomainRange[] Numbers { get; set; } = [];
  internal IGqlpDomainRegex[] Regexes { get; set; } = [];
}

internal class ParseDomainDefinition
  : SimpleDefinitionParser<DomainDefinition>
{
  private readonly Parser<IEnumParser<DomainKind>, DomainKind>.L _kind;
  private readonly Dictionary<DomainKind, ParseItems> _kindParsers = [];

  public ParseDomainDefinition(
      Parser<IGqlpTypeRef>.D typeRef,
      Parser<IEnumParser<DomainKind>, DomainKind>.D kind,
      IEnumerable<IParseDomain> domains)
    : base(typeRef)
  {
    _kind = kind;

    foreach (IParseDomain item in domains) {
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
