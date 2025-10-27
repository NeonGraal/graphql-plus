using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ObjectParser<TObjField>(
  ISimpleName name,
  Parser<IGqlpTypeParam>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<TObjField>>.D definition,
  IGqlpFieldKind<TObjField> fieldKind
) : DeclarationParser<IGqlpTypeParam, ObjectDefinition<TObjField>, IGqlpObject<TObjField>>(name, param, aliases, option, definition)
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
