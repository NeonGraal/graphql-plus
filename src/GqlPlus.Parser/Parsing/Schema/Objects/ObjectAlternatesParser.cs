using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

public abstract class ObjectAlternatesParser<TObjAlt, TObjAltAst, TObjBase>(
  ParserArray<IParserCollections, IGqlpModifier>.DA collections,
  Parser<TObjBase>.D parseBase
) : Parser<TObjAlt>.IA
  where TObjAlt : IGqlpObjAlternate<TObjBase>
  where TObjAltAst : AstObjAlternate<TObjBase>, TObjAlt
  where TObjBase : IGqlpObjBase<TObjBase>, IEquatable<TObjBase>
{
  private readonly ParserArray<IParserCollections, IGqlpModifier>.LA _collections = collections;
  private readonly Parser<TObjBase>.L _parseBase = parseBase;

  public IResultArray<TObjAlt> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ArgumentNullException.ThrowIfNull(tokens);

    List<TObjAlt> result = [];
    while (tokens.Take('|')) {
      TokenAt at = tokens.At;
      IResult<TObjBase> objBase = _parseBase.Parse(tokens, label);
      if (!objBase.IsOk()) {
        return objBase.AsPartialArray(result);
      }

      TObjAltAst alternate = ObjAlternate(at, objBase.Required());
      result.Add(alternate);
      IResultArray<IGqlpModifier> collections = _collections.Value.Parse(tokens, label);
      if (!collections.Optional(value => alternate.Modifiers = value.ArrayOf<ModifierAst>())) {
        return collections.AsPartialArray(result);
      }
    }

    return result.OkArray();
  }

  protected abstract TObjAltAst ObjAlternate(TokenAt at, TObjBase objBase);
}
