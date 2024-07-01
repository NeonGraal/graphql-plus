﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal abstract class ObjectTypeParser<TObjType, TObjTypeAst>
  where TObjType : IGqlpObjType
  where TObjTypeAst : AstObjType, TObjType
{
  protected IResult<TObjTypeAst> ParseObjectType<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    tokens.String(out string? description);
    if (!tokens.Prefix('$', out string? param, out TokenAt? at)) {
      return tokens.Error<TObjTypeAst>(label, "identifier after '$'");
    }

    if (param is not null) {
      TObjTypeAst objType = ObjType(at, param, description) with {
        IsTypeParameter = true,
      };
      return objType.Ok();
    }

    at = tokens.At;

    bool hasName = tokens.Identifier(out string? name);
    if (!hasName) {
      if (hasName = tokens.TakeZero()) {
        name = "0";
      } else if (hasName = tokens.TakeAny(out char simple, '^', '*', '_')) {
        name = $"{simple}";
      }
    }

    return hasName
      ? ObjType(at, name, description).Ok()
      : 0.Empty<TObjTypeAst>();
  }

  protected abstract TObjTypeAst ObjType(TokenAt at, string type, string description);
  public abstract IResultArray<TObjType> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer;
}
