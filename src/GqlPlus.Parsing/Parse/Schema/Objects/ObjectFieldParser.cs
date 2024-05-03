﻿using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Objects;

public abstract class ObjectFieldParser<TObjField, TObjBase>
  : Parser<TObjField>.I
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  private readonly Parser<string>.LA _aliases;
  private readonly Parser<ModifierAst>.LA _modifiers;
  private readonly Parser<TObjBase>.L _objBase;

  protected ObjectFieldParser(
    Parser<string>.DA aliases,
    Parser<ModifierAst>.DA modifiers,
    Parser<TObjBase>.D objBase)
  {
    _aliases = aliases;
    _objBase = objBase;
    _modifiers = modifiers;
  }

  public IResult<TObjField> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ArgumentNullException.ThrowIfNull(tokens);
    TokenAt at = tokens.At;
    tokens.String(out string? description);
    if (!tokens.Identifier(out string? name)) {
      return 0.Empty<TObjField>();
    }

    IResultArray<ParameterAst> hasParameter = FieldParameter(tokens);
    if (hasParameter.IsError()) {
      return hasParameter.AsResult<TObjField>();
    }

    IResultArray<string> hasAliases = _aliases.Parse(tokens, label);
    if (hasAliases.IsError()) {
      return hasAliases.AsResult<TObjField>();
    }

    TObjField field = ObjField(at, name, description, ObjBase(at, ""));

    if (tokens.Take(':')) {
      if (_objBase.Parse(tokens, label).Required(fieldType
        => field = ObjField(at, name, description, fieldType))
        ) {
        hasAliases.WithResult(aliases => field.Aliases = [.. aliases]);
        hasParameter.WithResult(parameter => ApplyFieldParameters(field, [.. parameter]));
        IResultArray<ModifierAst> modifiers = _modifiers.Parse(tokens, label);
        if (modifiers.IsError()) {
          return modifiers.AsResult<TObjField>();
        }

        modifiers.WithResult(modifiers => field.Modifiers = [.. modifiers]);

        return FieldDefault(tokens, field);
      }

      return tokens.Error(label, "field type", field);
    }

    hasAliases.WithResult(aliases => field.Aliases = [.. aliases]);
    return FieldEnumValue(tokens, field);
  }

  protected abstract void ApplyFieldParameters(TObjField field, ParameterAst[] parameters);
  protected abstract TObjField ObjField(TokenAt at, string name, string description, TObjBase typeBase);
  protected abstract IResult<TObjField> FieldDefault<TContext>(TContext tokens, TObjField field)
      where TContext : Tokenizer;
  protected abstract IResult<TObjField> FieldEnumValue<TContext>(TContext tokens, TObjField field)
      where TContext : Tokenizer;
  protected abstract IResultArray<ParameterAst> FieldParameter<TContext>(TContext tokens)
      where TContext : Tokenizer;
  protected abstract TObjBase ObjBase(TokenAt at, string param, string description = "");
}
