using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal abstract class ObjectParser<O, F, R>
  : DeclarationParser<TypeName, TypeParameterAst, NullAst, ObjectDefinition<F, R>, O>, Parser<O>.I
  where O : AstObject<F, R> where F : AstField<R> where R : AstReference<R>
{
  protected ObjectParser(
    TypeName name,
    Parser<TypeParameterAst>.DA param,
    Parser<string>.DA aliases,
    Parser<NullAst>.D option,
    Parser<ObjectDefinition<F, R>>.D definition
  ) : base(name, param, aliases, option, definition) { }

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

public abstract class ParseObjectDefinition<F, R> : Parser<ObjectDefinition<F, R>>.I
  where F : AstField<R> where R : AstReference<R>
{
  private readonly Parser<F>.L _field;
  private readonly Parser<ModifierAst>.LA _modifiers;
  private readonly Parser<R>.L _reference;

  protected ParseObjectDefinition(
    Parser<F>.D field,
    Parser<ModifierAst>.DA modifiers,
    Parser<R>.D reference)
  {
    _field = field;
    _modifiers = modifiers;
    _reference = reference;
  }

  protected abstract string Label { get; }

  public IResult<ObjectDefinition<F, R>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ObjectDefinition<F, R> result = new();
    tokens.String(out var descr);
    if (tokens.Take(':')) {
      var baseReference = _reference.Parse(tokens, label);
      if (baseReference.IsError()) {
        return baseReference.AsResult(result);
      }

      baseReference.WithResult(reference => result.Extends = reference with { Description = descr });
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
          result.Fields = fields.ToArray());
      }
    }

    result.Fields = fields.ToArray();
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
      var modifiers = _modifiers.Value.Parse(tokens, Label);
      if (!modifiers.Optional(value => alternate.Modifiers = value)) {
        return modifiers.AsPartialArray(result);
      }
    }

    return result.OkArray();
  }
}
