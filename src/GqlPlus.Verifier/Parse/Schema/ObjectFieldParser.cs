using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Parse.Schema;

public abstract class ObjectFieldParser<F, R> : Parser<F>.I
  where F : AstField<R> where R : AstReference<R>
{
  private readonly Parser<string>.LA _aliases;
  private readonly Parser<ModifierAst>.LA _modifiers;
  private readonly Parser<R>.L _reference;

  protected ObjectFieldParser(
    Parser<string>.DA aliases,
    Parser<ModifierAst>.DA modifiers,
    Parser<R>.D reference)
  {
    _aliases = aliases;
    _reference = reference;
    _modifiers = modifiers;
  }

  public IResult<F> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var at = tokens.At;
    tokens.String(out var description);
    if (!tokens.Identifier(out var name)) {
      return 0.Empty<F>();
    }

    var hasParameter = FieldParameter(tokens);
    if (hasParameter.IsError()) {
      return hasParameter.AsResult<F>();
    }

    var hasAliases = _aliases.Parse(tokens, label);
    if (hasAliases.IsError()) {
      return hasAliases.AsResult<F>();
    }

    var field = Field(at, name, description, Reference(at, ""));

    if (tokens.Take(':')) {
      tokens.String(out var descr);
      if (_reference.Parse(tokens, label).Required(fieldType
        => field = Field(at, name, description, fieldType))
        ) {
        hasAliases.WithResult(aliases => field.Aliases = aliases);
        hasParameter.WithResult(parameter => ApplyFieldParameters(field, parameter));

        var modifiers = _modifiers.Parse(tokens, label);
        if (modifiers.IsError()) {
          return modifiers.AsResult<F>();
        }

        modifiers.WithResult(modifiers => field.Modifiers = modifiers);

        return FieldDefault(tokens, field);
      }

      return tokens.Error(label, "field type", field);
    }

    return FieldEnumLabel(tokens, field);
  }

  protected abstract void ApplyFieldParameters(F field, ParameterAst[] parameters);
  protected abstract F Field(TokenAt at, string name, string description, R typeReference);
  protected abstract IResult<F> FieldDefault<TContext>(TContext tokens, F field)
      where TContext : Tokenizer;
  protected abstract IResult<F> FieldEnumLabel<TContext>(TContext tokens, F field)
      where TContext : Tokenizer;
  protected abstract IResultArray<ParameterAst> FieldParameter<TContext>(TContext tokens)
      where TContext : Tokenizer;
  protected abstract R Reference(TokenAt at, string param);
}
