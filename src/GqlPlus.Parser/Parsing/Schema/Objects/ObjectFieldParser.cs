using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal abstract class ObjectFieldParser<TObjField, TObjFieldAst>(
  Parser<string>.DA aliases,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IGqlpObjBase>.D parseBase
) : Parser<TObjField>.I
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField, TObjField
{
  private readonly Parser<string>.LA _aliases = aliases;
  private readonly Parser<IGqlpModifier>.LA _modifiers = modifiers;
  private readonly Parser<IGqlpObjBase>.L _parseBase = parseBase;

  public IResult<TObjField> Parse(ITokenizer tokens, string label)

  {
    tokens.ThrowIfNull();
    string description = tokens.Description();
    TokenAt at = tokens.At;
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
          return modifiers.AsPartial<TObjField>(field);
        }

        modifiers.WithResult(modifiers => field.Modifiers = [.. modifiers]);

        return FieldDefault(tokens, field);
      }

      return tokens.Error<TObjField>(label, "field type", field);
    }

    hasAliases.WithResult(aliases => field.Aliases = [.. aliases]);
    return FieldEnumValue(tokens, field);
  }

  protected IResult<TObjField> FieldEnumValue(ITokenizer tokens, TObjFieldAst field)
  {
    if (tokens.Take('=')) {
      string description = tokens.Description();
      TokenAt at = tokens.At;
      if (!tokens.Identifier(out string? enumType)) {
        return tokens.Partial<TObjField>("Output", "enum value after '='", () => field);
      }

      if (!tokens.Take('.')) {
        field.Type = ObjBase(at, "", description);
        field.EnumValue = new EnumValueAst(at, enumType);
        return field.Ok<TObjField>();
      }

      if (tokens.Identifier(out string? enumLabel)) {
        field.Type = ObjBase(at, enumType, description);
        field.EnumValue = new EnumValueAst(at, enumType, enumLabel);
        return field.Ok<TObjField>();
      }

      return tokens.Partial<TObjField>("Output", "enum value after '.'", () => field);
    }

    return tokens.Partial<TObjField>("Output", "':' or '='", () => field);
  }

  protected abstract void ApplyFieldParams(TObjFieldAst field, IGqlpInputParam[] parameters);
  protected abstract TObjFieldAst ObjField(TokenAt at, string name, string description, IGqlpObjBase typeBase);
  protected abstract IResult<TObjField> FieldDefault(ITokenizer tokens, TObjFieldAst field);
  protected abstract IResultArray<IGqlpInputParam> FieldParam(ITokenizer tokens);
  protected abstract IGqlpObjBase ObjBase(TokenAt at, string type, string description = "");
}
