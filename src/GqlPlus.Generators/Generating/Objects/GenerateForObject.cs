namespace GqlPlus.Generating.Objects;

internal abstract class GenerateForObject<T>
  : GenerateForClass<T>
  where T : IGqlpObject
{
  internal override IEnumerable<MapPair<string>> TypeMembers(T ast, GeneratorContext context)
    => [.. ast.Fields.Select(FieldMember(context)), .. ast.Alternates.Select(AlternateMember(context))];

  private Func<IGqlpObjField, MapPair<string>> FieldMember(GeneratorContext context)
    => field => new(field.Name, TypeString(field.Type, context));

  private Func<IGqlpObjAlternate, MapPair<string>> AlternateMember(GeneratorContext context)
    => alternate => new("As" + alternate.Name, TypeString(alternate, context));

  protected virtual string TypeString(IGqlpObjType type, GeneratorContext context)
    => context.GetTypeAst<IGqlpType>(type.FullType)?.Name ?? type.FullType;
}
