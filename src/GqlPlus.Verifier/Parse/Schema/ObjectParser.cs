using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal abstract class ObjectParser<O, F, R>
  : DeclarationParser<TypeName, ObjectParameters, NullAst, ObjectDefinition<F, R>, O>, IObjectParser<O, F, R>
  where O : AstObject<F, R> where F : AstField<R> where R : AstReference<R>
{
  private readonly IParserArray<ModifierAst> _modifiers;

  public ParserProxy<F, SchemaContext> FieldIParser { get; }
  public ParserProxy<R, SchemaContext> ReferenceIParser { get; }
  public ParserProxy<ObjectDefinition<F, R>, SchemaContext> DefinitionIParser { get; }

  protected ObjectParser(
    IParserArray<ModifierAst> modifiers,
    TypeName name,
    IParser<ObjectParameters> param,
    IParserArray<string> aliases,
    IParser<NullAst> option,
    IParser<ObjectDefinition<F, R>> definition
  ) : base(name, param, aliases, option, definition)
  {
    _modifiers = modifiers.ThrowIfNull();

    FieldIParser = new(ParseField);
    ReferenceIParser = new(tokens => ParseReference(tokens, false));
    DefinitionIParser = new(ParseDefinition);
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
        return TypeEnumLabel(reference);
      }

      return reference.Ok();
    }

    return 0.Empty<R>();
  }

  protected abstract R Reference(ParseAt at, string param);
  protected abstract IResult<R> TypeEnumLabel(R reference);

  private IResult<F> ParseField<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    var at = tokens.At;
    tokens.String(out var description);
    if (!tokens.Identifier(out var name)) {
      return 0.Empty<F>();
    }

    var hasParameter = FieldParameter();
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
        hasParameter.WithResult(parameter => ApplyParameter(field, parameter));

        var modifiers = _modifiers.Parse(tokens, Label);
        if (modifiers.IsError()) {
          return modifiers.AsResult<F>();
        }

        modifiers.WithResult(modifiers => field.Modifiers = modifiers);

        return FieldDefault(field);
      }

      return tokens.Error(Label, "field type", field);
    }

    return FieldEnumLabel(field);
  }

  protected abstract void ApplyParameter(F field, ParameterAst? parameter);
  protected abstract F Field(ParseAt at, string name, string description, R r);
  protected abstract IResult<F> FieldDefault(F field);
  protected abstract IResult<F> FieldEnumLabel(F field);
  protected abstract IResult<ParameterAst> FieldParameter();

  protected override bool ApplyParameter(O result, IResult<ObjectParameters> parameter)
    => parameter.Optional(value => result.Parameters = value?.Parameters ?? Array.Empty<TypeParameterAst>());

  private IResult<ObjectDefinition<F, R>> ParseDefinition(SchemaContext tokens)
  {
    ObjectDefinition<F, R> result = new();
    tokens.String(out var descr);
    if (tokens.Take(':')) {
      var baseReference = ParseReference(tokens, isTypeArgument: false);
      if (baseReference.IsError()) {
        return baseReference.AsResult(result);
      }

      baseReference.WithResult(reference => result.Extends = reference with { Description = descr });
    }

    var fields = new List<F>();
    var objectField = ParseField(tokens);
    if (objectField.IsError()) {
      return objectField.AsPartial(result);
    }

    while (objectField.Required(fields.Add)) {
      objectField = ParseField(tokens);
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

  private IResultArray<AstAlternate<R>> ParseAlternates<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    var result = new List<AstAlternate<R>>();
    while (tokens.Take('|')) {
      var reference = ParseReference(tokens, isTypeArgument: false);
      if (!reference.IsOk()) {
        return reference.AsPartialArray(result);
      }

      AstAlternate<R> alternate = new(reference.Required());
      result.Add(alternate);
      var modifiers = _modifiers.Parse(tokens, Label);
      if (!modifiers.Optional(value => alternate.Modifiers = value)) {
        return modifiers.AsPartialArray(result);
      }
    }

    return result.OkArray();
  }
}

internal class ObjectParameters
{
  internal TypeParameterAst[] Parameters { get; set; } = Array.Empty<TypeParameterAst>();
}

public class ObjectDefinition<F, R>
  where F : AstField<R> where R : AstReference<R>
{
  public R? Extends { get; set; }
  public F[] Fields { get; set; } = Array.Empty<F>();
  public AstAlternate<R>[] Alternates { get; set; } = Array.Empty<AstAlternate<R>>();
}

public interface IObjectParser<O, F, R> : IParser<O>
  where F : AstField<R> where R : AstReference<R>
{
  ParserProxy<F, SchemaContext> FieldIParser { get; }
  ParserProxy<R, SchemaContext> ReferenceIParser { get; }
  ParserProxy<ObjectDefinition<F, R>, SchemaContext> DefinitionIParser { get; }
}
