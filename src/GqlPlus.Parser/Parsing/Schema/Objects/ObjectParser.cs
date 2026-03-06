using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ObjectParser<TObjField>(
  ISimpleName name,
  IParserRepository parsers,
  IGqlpFieldKind<TObjField> fieldKind
) : DeclarationParser<IGqlpTypeParam, ObjectDefinition<TObjField>, IGqlpObject<TObjField>>(
    name,
    parsers.GetArray<IGqlpTypeParam>(),
    parsers.GetArray<string>(),
    parsers.GetInterface<IOptionParser<NullOption>, NullOption>(),
    parsers.Get<ObjectDefinition<TObjField>>())
  , Parser<IGqlpObject<TObjField>>.I
  where TObjField : IGqlpObjField

{
  protected override IGqlpObject<TObjField> MakeResult(AstPartial<IGqlpTypeParam, NullOption> partial, ObjectDefinition<TObjField> value)
    => new AstObject<TObjField>(fieldKind.FieldKind, partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParams = partial.Params,
      Parent = value.Parent,
      ObjFields = value.Fields,
      Alternates = value.Alternates,
    };

  protected override IGqlpObject<TObjField> ToResult(AstPartial<IGqlpTypeParam, NullOption> partial)
    => new AstObject<TObjField>(fieldKind.FieldKind, partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParams = partial.Params,
    };
}

public class ObjectDefinition<TObjField>
  where TObjField : IGqlpObjField
{
  public IGqlpObjBase? Parent { get; set; }
  public TObjField[] Fields { get; set; } = [];
  public IGqlpAlternate[] Alternates { get; set; } = [];
}
