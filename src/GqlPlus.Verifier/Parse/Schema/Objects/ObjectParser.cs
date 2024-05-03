using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Objects;

internal abstract class ObjectParser<TObject, TObjField, TObjBase>(
  ISimpleName name,
  Parser<TypeParameterAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<TObjField, TObjBase>>.D definition
) : DeclarationParser<TypeParameterAst, ObjectDefinition<TObjField, TObjBase>, TObject>(name, param, aliases, option, definition)
  , Parser<TObject>.I
  where TObject : AstObject<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  protected override bool ApplyParameters(TObject result, IResultArray<TypeParameterAst> parameter)
    => parameter.Optional(value => result.TypeParameters = value ?? []);
}

public class ObjectDefinition<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  public TObjBase? Parent { get; set; }
  public TObjField[] Fields { get; set; } = [];
  public AstAlternate<TObjBase>[] Alternates { get; set; } = [];
}

public abstract class ParseObjectDefinition<TObjField, TObjBase>(
  Parser<TObjField>.D objField,
  ParserArray<IParserCollections, ModifierAst>.DA collections,
  Parser<TObjBase>.D objBase
) : Parser<ObjectDefinition<TObjField, TObjBase>>.I
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  private readonly Parser<TObjField>.L _objField = objField;
  private readonly ParserArray<IParserCollections, ModifierAst>.LA _collections = collections;
  private readonly Parser<TObjBase>.L _objBase = objBase;

  protected abstract string Label { get; }

  public IResult<ObjectDefinition<TObjField, TObjBase>> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ArgumentNullException.ThrowIfNull(tokens);
    ObjectDefinition<TObjField, TObjBase> result = new();
    if (tokens.Take(':')) {
      var objBase = _objBase.Parse(tokens, label);
      if (objBase.IsError()) {
        return objBase.AsResult(result);
      }

      objBase.WithResult(parent => result.Parent = parent);
    }

    var fields = new List<TObjField>();
    var objectField = _objField.Parse(tokens, label);
    if (objectField.IsError()) {
      return objectField.AsPartial(result);
    }

    while (objectField.Required(fields.Add)) {
      objectField = _objField.Parse(tokens, label);
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

  private IResultArray<AstAlternate<TObjBase>> ParseAlternates<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var result = new List<AstAlternate<TObjBase>>();
    while (tokens.Take('|')) {
      var objBase = _objBase.Parse(tokens, label);
      if (!objBase.IsOk()) {
        return objBase.AsPartialArray(result);
      }

      AstAlternate<TObjBase> alternate = new(objBase.Required());
      result.Add(alternate);
      var collections = _collections.Value.Parse(tokens, Label);
      if (!collections.Optional(value => alternate.Modifiers = value)) {
        return collections.AsPartialArray(result);
      }
    }

    return result.OkArray();
  }
}
