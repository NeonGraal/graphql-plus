using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal abstract class ObjectParser<O, F, R>
  : DeclarationParser<TypeName, TypeParameterAst, NullAst, ObjectDefinition<F, R>, O>, IObjectParser<O, F, R>
  where O : AstObject<F, R> where F : AstField<R> where R : AstReference<R>
{
  private readonly Parser<ModifierAst>.LA _modifiers;

  public ParserProxy<F, Tokenizer> FieldIParser { get; }
  public ParserProxy<R, Tokenizer> ReferenceIParser { get; }

  protected ObjectParser(
    Parser<ModifierAst>.DA modifiers,
    TypeName name,
    IParserArray<TypeParameterAst> param,
    IParserArray<string> aliases,
    IParser<NullAst> option,
    IParser<ObjectDefinition<F, R>> definition
  ) : base(name, param, aliases, option, definition)
  {
    _modifiers = modifiers;

    FieldIParser = new(ParseField);
    ReferenceIParser = new(tokens => ParseReference(tokens, false));
  }

  private IResult<R> ParseReference<TContext>(TContext tokens, bool isTypeArgument)
    where TContext : Tokenizer
  {
    tokens.String(out var description);
    if (!tokens.Prefix('$', out var param, out var at)) {
      return tokens.Error<R>(Label, "identifier after '$'");
    }

    if (param is not null) {
      var reference = Reference(at, param) with {
        Description = description,
        IsTypeParameter = true,
      };
      return reference.Ok();
    }

    at = tokens.At;

    if (tokens.Identifier(out var name)) {
      var reference = Reference(at, name) with { Description = description };
      if (tokens.Take('<')) {
        var arguments = new List<R>();
        var referenceArgument = ParseReference(tokens, isTypeArgument: true);
        while (referenceArgument.Required(arguments.Add)) {
          referenceArgument = ParseReference(tokens, isTypeArgument: true);
        }

        reference.Arguments = arguments.ToArray();

        if (!tokens.Take('>')) {
          return tokens.Error(Label, "'>' after type argument(s)", reference);
        } else if (arguments.Count < 1) {
          return tokens.Error(Label, "at least one type argument after '<'", reference);
        }
      } else if (isTypeArgument) {
        return TypeEnumLabel(tokens, reference);
      }

      return reference.Ok();
    }

    return 0.Empty<R>();
  }

  protected abstract R Reference(TokenAt at, string param);
  protected abstract IResult<R> TypeEnumLabel<TContext>(TContext tokens, R reference)
      where TContext : Tokenizer;

  private IResult<F> ParseField<TContext>(TContext tokens)
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

    var hasAliases = Aliases.Parse(tokens, Label);
    if (hasAliases.IsError()) {
      return hasAliases.AsResult<F>();
    }

    var field = Field(at, name, description, Reference(at, ""));

    if (tokens.Take(':')) {
      tokens.String(out var descr);
      if (ParseReference(tokens, isTypeArgument: false).Required(fieldType
        => field = Field(at, name, description, fieldType))
        ) {
        hasAliases.WithResult(aliases => field.Aliases = aliases);
        hasParameter.WithResult(parameter => ApplyFieldParameters(field, parameter));

        var modifiers = _modifiers.Parse(tokens, Label);
        if (modifiers.IsError()) {
          return modifiers.AsResult<F>();
        }

        modifiers.WithResult(modifiers => field.Modifiers = modifiers);

        return FieldDefault(tokens, field);
      }

      return tokens.Error(Label, "field type", field);
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

  protected override bool ApplyParameters(O result, IResultArray<TypeParameterAst> parameter)
    => parameter.Optional(value => result.Parameters = value ?? Array.Empty<TypeParameterAst>());
}

public class ObjectDefinition<F, R>
  where F : AstField<R> where R : AstReference<R>
{
  public R? Extends { get; set; }
  public F[] Fields { get; set; } = Array.Empty<F>();
  public AlternateAst<R>[] Alternates { get; set; } = Array.Empty<AlternateAst<R>>();
}

public abstract class ParseObjectDefinition<F, R> : IParser<ObjectDefinition<F, R>>
  where F : AstField<R> where R : AstReference<R>
{
  private readonly Lazy<IParser<F>> _field;
  private readonly Parser<ModifierAst>.LA _modifiers;
  private readonly Lazy<IParser<R>> _reference;

  protected ParseObjectDefinition(
    Func<IParser<F>> field,
    Parser<ModifierAst>.DA modifiers,
    Func<IParser<R>> reference)
  {
    _field = field.ThrowIfNull().Lazy();
    _modifiers = modifiers;
    _reference = reference.ThrowIfNull().Lazy();
  }

  protected abstract string Label { get; }

  public IResult<ObjectDefinition<F, R>> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    ObjectDefinition<F, R> result = new();
    tokens.String(out var descr);
    if (tokens.Take(':')) {
      var baseReference = _reference.Value.Parse(tokens);
      if (baseReference.IsError()) {
        return baseReference.AsResult(result);
      }

      baseReference.WithResult(reference => result.Extends = reference with { Description = descr });
    }

    var fields = new List<F>();
    var objectField = _field.Value.Parse(tokens);
    if (objectField.IsError()) {
      return objectField.AsPartial(result);
    }

    while (objectField.Required(fields.Add)) {
      objectField = _field.Value.Parse(tokens);
      if (objectField.IsError()) {
        return objectField.AsPartial(result, fields.Add, () =>
          result.Fields = fields.ToArray());
      }
    }

    result.Fields = fields.ToArray();
    var objectAlternates = ParseAlternates(tokens);
    return !objectAlternates.Optional(alternates => result.Alternates = alternates)
      ? objectAlternates.AsPartial(result)
      : tokens.End(Label, () => result);
  }

  private IResultArray<AlternateAst<R>> ParseAlternates<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    var result = new List<AlternateAst<R>>();
    while (tokens.Take('|')) {
      var reference = _reference.Value.Parse(tokens);
      if (!reference.IsOk()) {
        return reference.AsPartialArray(result);
      }

      AlternateAst<R> alternate = new(reference.Required());
      result.Add(alternate);
      var modifiers = _modifiers.Value.Parse(tokens, Label);
      if (!modifiers.Optional(value => alternate.Modifiers = value)) {
        return modifiers.AsPartialArray(result);
      }
    }

    return result.OkArray();
  }
}

public interface IObjectParser<O, F, R> : IParser<O>
  where F : AstField<R> where R : AstReference<R>
{
  ParserProxy<F, Tokenizer> FieldIParser { get; }
  ParserProxy<R, Tokenizer> ReferenceIParser { get; }
}
