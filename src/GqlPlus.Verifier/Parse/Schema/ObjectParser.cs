using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal abstract class ObjectParser<TObject, TField, TReference>
  : DeclarationParser<TypeName, TypeParameterAst, NullAst, ObjectDefinition<TField, TReference>, TObject>, Parser<TObject>.I
  where TObject : AstObject<TField, TReference> where TField : AstField<TReference> where TReference : AstReference<TReference>
{
  protected ObjectParser(
    TypeName name,
    Parser<TypeParameterAst>.DA param,
    Parser<string>.DA aliases,
    Parser<NullAst>.D option,
    Parser<ObjectDefinition<TField, TReference>>.D definition
  ) : base(name, param, aliases, option, definition) { }

  protected override bool ApplyParameters(TObject result, IResultArray<TypeParameterAst> parameter)
    => parameter.Optional(value => result.TypeParameters = value ?? []);
}

public class ObjectDefinition<F, R>
  where F : AstField<R> where R : AstReference<R>
{
  public R? Extends { get; set; }
  public F[] Fields { get; set; } = [];
  public AlternateAst<R>[] Alternates { get; set; } = [];
}

public abstract class ParseObjectDefinition<F, R> : Parser<ObjectDefinition<F, R>>.I
  where F : AstField<R> where R : AstReference<R>
{
  private readonly Parser<F>.L _field;
  private readonly ParserArray<IParserCollections, ModifierAst>.LA _collections;
  private readonly Parser<R>.L _reference;

  protected ParseObjectDefinition(
    Parser<F>.D field,
    ParserArray<IParserCollections, ModifierAst>.DA collections,
    Parser<R>.D reference)
  {
    _field = field;
    _collections = collections;
    _reference = reference;
  }

  protected abstract string Label { get; }

  public IResult<ObjectDefinition<F, R>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ObjectDefinition<F, R> result = new();
    if (tokens.Take(':')) {
      var baseReference = _reference.Parse(tokens, label);
      if (baseReference.IsError()) {
        return baseReference.AsResult(result);
      }

      baseReference.WithResult(reference => result.Extends = reference);
    }

    var fields = new List<F>();
    var objectField = _field.Parse(tokens, label);
    if (objectField.IsError()) {
      return objectField.AsPartial(result);
    }

    while (objectField.Required(fields.Add)) {
      objectField = _field.Parse(tokens, label);
      if (objectField.IsError()) {
        return objectField.AsPartial(result, fields.Add, () =>
          result.Fields = [.. fields]);
      }
    }

    result.Fields = [.. fields];
    var objectAlternates = ParseAlternates(tokens, label);
    return !objectAlternates.Optional(alternates => result.Alternates = alternates)
      ? objectAlternates.AsPartial(result)
      : tokens.End(Label, () => result);
  }

  private IResultArray<AlternateAst<R>> ParseAlternates<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var result = new List<AlternateAst<R>>();
    while (tokens.Take('|')) {
      var reference = _reference.Parse(tokens, label);
      if (!reference.IsOk()) {
        return reference.AsPartialArray(result);
      }

      AlternateAst<R> alternate = new(reference.Required());
      result.Add(alternate);
      var collections = _collections.Value.Parse(tokens, Label);
      if (!collections.Optional(value => alternate.Modifiers = value)) {
        return collections.AsPartialArray(result);
      }
    }

    return result.OkArray();
  }
}
