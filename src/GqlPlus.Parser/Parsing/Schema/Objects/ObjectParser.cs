using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal abstract class ObjectParser<TObject, TObjField, TObjAlt, TObjBase>(
  ISimpleName name,
  Parser<IGqlpTypeParameter>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<TObjField, TObjAlt, TObjBase>>.D definition
) : DeclarationParser<IGqlpTypeParameter, ObjectDefinition<TObjField, TObjAlt, TObjBase>, TObject>(name, param, aliases, option, definition)
  , Parser<TObject>.I
  where TObject : AstObject<TObjField, TObjAlt, TObjBase>
  where TObjField : IGqlpObjField<TObjBase>
  where TObjAlt : IGqlpObjAlternate<TObjBase>
  where TObjBase : IGqlpObjBase<TObjBase>, IEquatable<TObjBase>
{ }

public class ObjectDefinition<TObjField, TObjAlt, TObjBase>
  where TObjField : IGqlpObjField<TObjBase>
  where TObjAlt : IGqlpObjAlternate<TObjBase>
  where TObjBase : IGqlpObjBase<TObjBase>, IEquatable<TObjBase>
{
  public TObjBase? Parent { get; set; }
  public TObjField[] Fields { get; set; } = [];
  public TObjAlt[] Alternates { get; set; } = [];
}
