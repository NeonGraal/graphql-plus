using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal abstract class ObjectParser<TObject, TObjField, TObjBase>(
  ISimpleName name,
  Parser<IGqlpTypeParameter>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<TObjField, TObjBase>>.D definition
) : DeclarationParser<IGqlpTypeParameter, ObjectDefinition<TObjField, TObjBase>, TObject>(name, param, aliases, option, definition)
  , Parser<TObject>.I
  where TObject : AstObject<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{ }

public class ObjectDefinition<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  public TObjBase? Parent { get; set; }
  public TObjField[] Fields { get; set; } = [];
  public AstAlternate<TObjBase>[] Alternates { get; set; } = [];
}
