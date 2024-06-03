using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseAlternates<TObjBase>(
  ParserArray<IParserCollections, IGqlpModifier>.DA collections,
  Parser<TObjBase>.D objBase
) : Parser<AstAlternate<TObjBase>>.IA
  where TObjBase : IGqlpObjectBase<TObjBase>, IEquatable<TObjBase>
{
  private readonly ParserArray<IParserCollections, IGqlpModifier>.LA _collections = collections;
  private readonly Parser<TObjBase>.L _objBase = objBase;

  public IResultArray<AstAlternate<TObjBase>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ArgumentNullException.ThrowIfNull(tokens);

    List<AstAlternate<TObjBase>> result = [];
    while (tokens.Take('|')) {
      IResult<TObjBase> objBase = _objBase.Parse(tokens, label);
      if (!objBase.IsOk()) {
        return objBase.AsPartialArray(result);
      }

      AstAlternate<TObjBase> alternate = new(objBase.Required());
      result.Add(alternate);
      IResultArray<IGqlpModifier> collections = _collections.Value.Parse(tokens, label);
      if (!collections.Optional(value => alternate.Modifiers = value.ArrayOf<ModifierAst>())) {
        return collections.AsPartialArray(result);
      }
    }

    return result.OkArray();
  }
}
