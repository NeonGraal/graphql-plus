using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal abstract class ObjectAlternatesParser<TObjAlt, TObjAltAst, TObjBase, TObjArg>(
  ParserArray<IParserCollections, IGqlpModifier>.DA collections,
  Parser<TObjBase>.D parseBase
) : Parser<TObjAlt>.IA
  where TObjAlt : IGqlpObjAlternate
  where TObjAltAst : AstObjAlternate<TObjArg>, TObjAlt
  where TObjBase : IGqlpObjBase
  where TObjArg : IGqlpObjArg
{
  private readonly ParserArray<IParserCollections, IGqlpModifier>.LA _collections = collections;
  private readonly Parser<TObjBase>.L _parseBase = parseBase;

  public IResultArray<TObjAlt> Parse(ITokenizer tokens, string label)

  {
    tokens.ThrowIfNull();

    List<TObjAlt> result = [];
    while (tokens.Take('|')) {
      TokenAt at = tokens.At;
      IResult<TObjBase> objBase = _parseBase.Parse(tokens, label);
      if (!objBase.IsOk()) {
        return objBase.IsError()
          ? result.PartialArray(objBase.Message())
          : result.PartialArray(tokens.Error(label, "base missing after '|'"));
      }

      TObjBase baseObject = objBase.Required();
      TObjAltAst alternate = ObjAlternate(at, baseObject.Name, baseObject.Description) with {
        IsTypeParam = baseObject.IsTypeParam,
        BaseArgs = baseObject.Args.ArrayOf<TObjArg>(),
      };
      result.Add(alternate);
      IResultArray<IGqlpModifier> collections = _collections.Value.Parse(tokens, label);
      if (!collections.Optional(value => alternate.Modifiers = value.ArrayOf<ModifierAst>())) {
        return collections.AsPartialArray(result);
      }
    }

    return result.OkArray();
  }

  protected abstract TObjAltAst ObjAlternate(TokenAt at, string name, string description);

}
