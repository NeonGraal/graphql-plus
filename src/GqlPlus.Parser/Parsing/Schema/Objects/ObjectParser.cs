using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ObjectParser<TObjField>(
  TypeKind fieldKind,
  IParserRepository parsers
) : DeclarationParser<IAstTypeParam, ObjectDefinition<TObjField>, IAstObject<TObjField>>(parsers)
  , Parser<IAstObject<TObjField>>.I
  where TObjField : IAstObjField

{
  protected override IAstObject<TObjField> MakeResult(AstPartial<IAstTypeParam, NullOption> partial, ObjectDefinition<TObjField> value)
    => new AstObject<TObjField>(fieldKind, partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParams = partial.Params,
      Parent = value.Parent,
      ObjFields = value.Fields,
      Alternates = value.Alternates,
    };

  protected override IAstObject<TObjField> ToResult(AstPartial<IAstTypeParam, NullOption> partial)
    => new AstObject<TObjField>(fieldKind, partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParams = partial.Params,
    };

  internal static Factory<ObjectParser<TObjField>, IParserRepository> Factory(TypeKind fieldKind)
    => r => new(fieldKind, r);
}

internal class ObjectDefinition<TObjField>
  where TObjField : IAstObjField
{
  public IAstObjBase? Parent { get; set; }
  public TObjField[] Fields { get; set; } = [];
  public IAstAlternate[] Alternates { get; set; } = [];
}
