﻿using System.Diagnostics.CodeAnalysis;

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

internal class ScalarDefinition
{
  public ScalarKind Kind { get; set; } = ScalarKind.Number;
  public string? Parent { get; set; }
  public ScalarMemberAst[] Members { get; set; } = [];
  public ScalarRangeAst[] Numbers { get; set; } = [];
  public ScalarRegexAst[] Regexes { get; set; } = [];
  public ScalarReferenceAst[] References { get; set; } = [];
}

internal class ParseScalarDefinition(
  Parser<IEnumParser<ScalarKind>, ScalarKind>.D kind,
  Parser<ScalarMemberAst>.DA members,
  Parser<ScalarRangeAst>.DA numbers,
  Parser<ScalarReferenceAst>.DA references,
  Parser<ScalarRegexAst>.DA regexes
) : Parser<ScalarDefinition>.I
{
  private readonly Parser<IEnumParser<ScalarKind>, ScalarKind>.L _kind = kind;
  private readonly Parser<ScalarMemberAst>.LA _members = members;
  private readonly Parser<ScalarRangeAst>.LA _numbers = numbers;
  private readonly Parser<ScalarReferenceAst>.LA _references = references;
  private readonly Parser<ScalarRegexAst>.LA _regexes = regexes;

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
    if (!scalarKind.Required(kind => result.Kind = kind)) {
      return scalarKind.AsResult(result);
    }

    switch (result.Kind) {
      case ScalarKind.Boolean:
        return tokens.End(label, () => result);

      case ScalarKind.Enum:
        var scalarMembers = _members.Parse(tokens, label);
        if (scalarMembers.Required(members => result.Members = members)) {
          return tokens.End(label, () => result);
        }

        return scalarMembers.AsResult(result);
      case ScalarKind.Number:
        var scalarRanges = _numbers.Parse(tokens, label);
        if (scalarRanges.Required(ranges => result.Numbers = ranges)) {
          return tokens.End(label, () => result);
        }

        return scalarRanges.AsResult(result);
      case ScalarKind.String:
        var scalarRegexes = _regexes.Parse(tokens, label);
        if (scalarRegexes.Required(regexes => result.Regexes = regexes)) {
          return tokens.End(label, () => result);
        }

        return scalarRegexes.AsResult(result);
      case ScalarKind.Union:
        var scalarReferences = _references.Parse(tokens, label);
        if (scalarReferences.Required(references => result.References = references)) {
          return tokens.End(label, () => result);
        }

        return scalarReferences.AsResult(result);
      default:
        return tokens.Partial(label, "valid kind", () => result);
    }
  }
}
