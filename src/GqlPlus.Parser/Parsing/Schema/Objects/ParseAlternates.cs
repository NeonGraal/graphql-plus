using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseAlternates(
  IParserRepository parsers
) : Parser<IAstAlternate>.IA
{
  private readonly ParserArray<IParserCollections, IAstModifier>.LA _collections = parsers.ArrayFor<IParserCollections, IAstModifier>();
  private readonly Parser<IAstObjBase>.L _parseBase = parsers.ParserFor<IAstObjBase>();
  private readonly Parser<IAstEnumValue>.L _parseEnum = parsers.ParserFor<IAstEnumValue>();

  public IResultArray<IAstAlternate> Parse(ITokenizer tokens, string label)
  {
    tokens.ThrowIfNull();

    List<IAstAlternate> result = [];
    while (tokens.TakeAny(out char selector, '|', '!')) {
      IResultArray<IAstAlternate>? error = selector switch {
        '|' => ParseBase(tokens, label, result),
        '!' => ParseEnum(tokens, label, result),
        _ => result.PartialArray(tokens.Error(label, $"unexpected '{selector}' in Alts")),
      };
      if (error is not null) {
        return error;
      }
    }

    return result.OkArray();
  }

  private IResultArray<IAstAlternate>? ParseBase(ITokenizer tokens, string label, List<IAstAlternate> result)
  {
    TokenAt at = tokens.At;
    IResult<IAstObjBase> objBase = _parseBase.Parse(tokens, label);
    if (!objBase.IsOk()) {
      return objBase.IsError()
        ? result.PartialArray(objBase.Message())
        : result.PartialArray(tokens.Error(label, "base missing after '|'"));
    }

    IAstObjBase baseObject = objBase.Required();
    AlternateAst alternate = new(at, baseObject.Name, baseObject.Description) {
      IsTypeParam = baseObject.IsTypeParam,
      Args = baseObject.Args.ArrayOf<IAstTypeArg>(),
    };
    result.Add(alternate);
    IResultArray<IAstModifier> collections = _collections.Value.Parse(tokens, label);
    if (!collections.Optional(value => alternate.Modifiers = value.ArrayOf<ModifierAst>())) {
      return collections.AsPartialArray(result);
    }

    return null;
  }

  private IResultArray<IAstAlternate>? ParseEnum(ITokenizer tokens, string label, List<IAstAlternate> result)
  {
    TokenAt at = tokens.At;
    IResult<IAstEnumValue> enumResult = _parseEnum.Parse(tokens, label);
    if (!enumResult.IsOk()) {
      return enumResult.IsError()
        ? result.PartialArray(enumResult.Message())
        : result.PartialArray(tokens.Error(label, "enum missing after '!'"));
    }

    IAstEnumValue enumValue = enumResult.Required();
    AlternateAst alternate = new(at, enumValue.EnumType, "") {
      EnumValue = enumValue,
    };

    result.Add(alternate);
    return null;
  }

  internal static ParseAlternates Factory(IParserRepository p) => new(p);
}
