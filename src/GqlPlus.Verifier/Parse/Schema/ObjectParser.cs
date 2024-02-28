using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal abstract class ObjectParser<TObject, TField, TRef>
  : DeclarationParser<TypeParameterAst, ObjectDefinition<TField, TRef>, TObject>, Parser<TObject>.I
  where TObject : AstObject<TField, TRef> where TField : AstField<TRef> where TRef : AstReference<TRef>
{
  protected ObjectParser(
    ISimpleName name,
    Parser<TypeParameterAst>.DA param,
    Parser<string>.DA aliases,
    Parser<IOptionParser<NullOption>, NullOption>.D option,
    Parser<ObjectDefinition<TField, TRef>>.D definition
  ) : base(name, param, aliases, option, definition) { }

  protected override bool ApplyParameters(TObject result, IResultArray<TypeParameterAst> parameter)
    => parameter.Optional(value => result.TypeParameters = value ?? []);
}

public class ObjectDefinition<TField, TRef>
  where TField : AstField<TRef> where TRef : AstReference<TRef>
{
  public TRef? Parent { get; set; }
  public TField[] Fields { get; set; } = [];
  public AstAlternate<TRef>[] Alternates { get; set; } = [];
}

public abstract class ParseObjectDefinition<TField, TRef> : Parser<ObjectDefinition<TField, TRef>>.I
  where TField : AstField<TRef> where TRef : AstReference<TRef>
{
  private readonly Parser<TField>.L _field;
  private readonly ParserArray<IParserCollections, ModifierAst>.LA _collections;
  private readonly Parser<TRef>.L _reference;

  protected ParseObjectDefinition(
    Parser<TField>.D field,
    ParserArray<IParserCollections, ModifierAst>.DA collections,
    Parser<TRef>.D reference)
  {
    _field = field;
    _collections = collections;
    _reference = reference;
  }

  protected abstract string Label { get; }

  public IResult<ObjectDefinition<TField, TRef>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ArgumentNullException.ThrowIfNull(tokens);
    ObjectDefinition<TField, TRef> result = new();
    if (tokens.Take(':')) {
      var baseReference = _reference.Parse(tokens, label);
      if (baseReference.IsError()) {
        return baseReference.AsResult(result);
      }

      baseReference.WithResult(reference => result.Parent = reference);
    }

    var fields = new List<TField>();
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

  private IResultArray<AstAlternate<TRef>> ParseAlternates<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var result = new List<AstAlternate<TRef>>();
    while (tokens.Take('|')) {
      var reference = _reference.Parse(tokens, label);
      if (!reference.IsOk()) {
        return reference.AsPartialArray(result);
      }

      AstAlternate<TRef> alternate = new(reference.Required());
      result.Add(alternate);
      var collections = _collections.Value.Parse(tokens, Label);
      if (!collections.Optional(value => alternate.Modifiers = value)) {
        return collections.AsPartialArray(result);
      }
    }

    return result.OkArray();
  }
}
