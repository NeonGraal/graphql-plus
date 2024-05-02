using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public abstract class ObjectFieldParser<TField, TRef> : Parser<TField>.I
  where TField : AstObjectField<TRef> where TRef : AstReference<TRef>
{
  private readonly Parser<string>.LA _aliases;
  private readonly Parser<ModifierAst>.LA _modifiers;
  private readonly Parser<TRef>.L _reference;

  protected ObjectFieldParser(
    Parser<string>.DA aliases,
    Parser<ModifierAst>.DA modifiers,
    Parser<TRef>.D reference)
  {
    _aliases = aliases;
    _reference = reference;
    _modifiers = modifiers;
  }

  public IResult<TField> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ArgumentNullException.ThrowIfNull(tokens);
    var at = tokens.At;
    tokens.String(out var description);
    if (!tokens.Identifier(out var name)) {
      return 0.Empty<TField>();
    }

    var hasParameter = FieldParameter(tokens);
    if (hasParameter.IsError()) {
      return hasParameter.AsResult<TField>();
    }

    var hasAliases = _aliases.Parse(tokens, label);
    if (hasAliases.IsError()) {
      return hasAliases.AsResult<TField>();
    }

    var field = Field(at, name, description, Reference(at, ""));

    if (tokens.Take(':')) {
      if (_reference.Parse(tokens, label).Required(fieldType
        => field = Field(at, name, description, fieldType))
        ) {
        hasAliases.WithResult(aliases => field.Aliases = aliases);
        hasParameter.WithResult(parameter => ApplyFieldParameters(field, parameter));
        var modifiers = _modifiers.Parse(tokens, label);
        if (modifiers.IsError()) {
          return modifiers.AsResult<TField>();
        }

        modifiers.WithResult(modifiers => field.Modifiers = modifiers);

        return FieldDefault(tokens, field);
      }

      return tokens.Error(label, "field type", field);
    }

    hasAliases.WithResult(aliases => field.Aliases = aliases);
    return FieldEnumValue(tokens, field);
  }

  protected abstract void ApplyFieldParameters(TField field, ParameterAst[] parameters);
  protected abstract TField Field(TokenAt at, string name, string description, TRef typeReference);
  protected abstract IResult<TField> FieldDefault<TContext>(TContext tokens, TField field)
      where TContext : Tokenizer;
  protected abstract IResult<TField> FieldEnumValue<TContext>(TContext tokens, TField field)
      where TContext : Tokenizer;
  protected abstract IResultArray<ParameterAst> FieldParameter<TContext>(TContext tokens)
      where TContext : Tokenizer;
  protected abstract TRef Reference(TokenAt at, string param, string description = "");
}
