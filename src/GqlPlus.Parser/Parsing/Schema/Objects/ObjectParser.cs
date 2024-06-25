using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

internal abstract class ObjectParser<TObject, TObjBase, TObjField, TObjAlt>(
  ISimpleName name,
  Parser<IGqlpTypeParameter>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<TObjBase, TObjField, TObjAlt>>.D definition
) : DeclarationParser<IGqlpTypeParameter, ObjectDefinition<TObjBase, TObjField, TObjAlt>, TObject>(name, param, aliases, option, definition)
  , Parser<TObject>.I
  where TObject : IGqlpObject<TObjBase, TObjField, TObjAlt>
  where TObjField : IGqlpObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjBase : IGqlpObjBase
{ }

public class ObjectDefinition<TObjBase, TObjField, TObjAlt>
  where TObjField : IGqlpObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjBase : IGqlpObjBase
{
  public TObjBase? Parent { get; set; }
  public TObjField[] Fields { get; set; } = [];
  public TObjAlt[] Alternates { get; set; } = [];
}
