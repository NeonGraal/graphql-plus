using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

internal abstract class ObjectParser<TObject, TObjField>(
  ISimpleName name,
  Parser<IGqlpTypeParam>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<TObjField>>.D definition
) : DeclarationParser<IGqlpTypeParam, ObjectDefinition<TObjField>, TObject>(name, param, aliases, option, definition)
  , Parser<TObject>.I
  where TObject : IGqlpObject<TObjField>
  where TObjField : IGqlpObjField
{ }

public class ObjectDefinition<TObjField>
  where TObjField : IGqlpObjField
{
  public IGqlpObjBase? Parent { get; set; }
  public TObjField[] Fields { get; set; } = [];
  public IGqlpObjAlt[] Alternates { get; set; } = [];
}
