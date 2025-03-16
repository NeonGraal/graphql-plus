using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal abstract class ObjectFieldParser<TObjField, TObjFieldAst, TObjBase>(
  Parser<string>.DA aliases,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<TObjBase>.D parseBase
) : Parser<TObjField>.I
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField<TObjBase>, TObjField
  where TObjBase : IGqlpObjBase
{
  private readonly Parser<string>.LA _aliases = aliases;
  private readonly Parser<IGqlpModifier>.LA _modifiers = modifiers;
  private readonly Parser<TObjBase>.L _parseBase = parseBase;

  public IResult<TObjField> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    tokens.ThrowIfNull();
    TokenAt at = tokens.At;
    tokens.String(out string? description);
    if (!tokens.Identifier(out string? name)) {
      return 0.Empty<TObjField>();
    }

    IResultArray<IGqlpInputParam> hasParam = FieldParam(tokens);
    if (hasParam.IsError()) {
      return hasParam.AsResult<TObjField>();
    }

    IResultArray<string> hasAliases = _aliases.Parse(tokens, label);
    if (hasAliases.IsError()) {
      return hasAliases.AsResult<TObjField>();
    }

    TObjFieldAst field = ObjField(at, name, description, ObjBase(at, ""));

    if (tokens.Take(':')) {
      if (_parseBase.Parse(tokens, label).Required(fieldType
        => field = ObjField(at, name, description, fieldType))
        ) {
        hasAliases.WithResult(aliases => field.Aliases = [.. aliases]);
        hasParam.WithResult(parameter => ApplyFieldParams(field, [.. parameter]));
        IResultArray<IGqlpModifier> modifiers = _modifiers.Parse(tokens, label);
        if (modifiers.IsError()) {
          return modifiers.AsResult<TObjField>();
        }

        modifiers.WithResult(modifiers => field.Modifiers = modifiers.ArrayOf<ModifierAst>());

        return FieldDefault(tokens, field);
      }

      return tokens.Error<TObjField>(label, "field type", field);
    }

    hasAliases.WithResult(aliases => field.Aliases = [.. aliases]);
    return FieldEnumValue(tokens, field);
  }

  protected abstract void ApplyFieldParams(TObjFieldAst field, IGqlpInputParam[] parameters);
  protected abstract TObjFieldAst ObjField(TokenAt at, string name, string description, TObjBase typeBase);
  protected abstract IResult<TObjField> FieldDefault<TContext>(TContext tokens, TObjFieldAst field)
      where TContext : Tokenizer;
  protected abstract IResult<TObjField> FieldEnumValue<TContext>(TContext tokens, TObjFieldAst field)
      where TContext : Tokenizer;
  protected abstract IResultArray<IGqlpInputParam> FieldParam<TContext>(TContext tokens)
      where TContext : Tokenizer;
  protected abstract TObjBase ObjBase(TokenAt at, string param, string description = "");
}
