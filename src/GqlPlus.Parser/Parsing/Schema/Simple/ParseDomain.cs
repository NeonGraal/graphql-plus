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
) : DeclarationParser<DomainDefinition, IGqlpDomain>(name, param, aliases, option, definition)
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

public class DomainDefinition
{
  public DomainKind Kind { get; set; } = DomainKind.Number;
  public string? Parent { get; set; }
  internal DomainTrueFalseAst[] Values { get; set; } = [];
  internal DomainLabelAst[] Labels { get; set; } = [];
  internal DomainRangeAst[] Numbers { get; set; } = [];
  internal DomainRegexAst[] Regexes { get; set; } = [];
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

    foreach (IParseDomain item in domains) {
      _kindParsers[item.Kind] = item.Parser;
    }
  }

  public IResult<DomainDefinition> Parse(ITokenizer tokens, string label)

  {
    DomainDefinition result = new();

    if (tokens.Take(':')) {
      if (tokens.Identifier(out string? parent)) {
        result.Parent = parent;
      } else {
        return tokens.Error(label, "type after ':'", result);
      }
    }

    IResult<DomainKind> domainKind = _kind.I.Parse(tokens, label);
    return !domainKind.Required(kind => result.Kind = kind)
      ? domainKind.AsResult(result)
      : _kindParsers.TryGetValue(result.Kind, out ParseItems? parser)
        ? parser(tokens, label, result)
        : tokens.Partial(label, "valid kind", () => result);
  }
}
