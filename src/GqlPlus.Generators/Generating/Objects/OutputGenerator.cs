using GqlPlus.Abstractions;

namespace GqlPlus.Generating.Objects;

internal class OutputGenerator
  : GenerateForObject<IGqlpOutputField, OutputField>
{
  protected override void ClassMember(OutputField item, GqlpGeneratorContext context)
  {
    if (string.IsNullOrEmpty(item.Param)) {
      context.Write("  public " + item.Type + " " + item.Name + " { get; set; }");
    } else {
      context.Write($"  public {item.Type}? {item.Name}({item.Param} parameter)");
      context.Write("    => null;");
    }
  }

  protected override void InterfaceMember(OutputField item, GqlpGeneratorContext context)
  {
    if (string.IsNullOrEmpty(item.Param)) {
      context.Write("  " + item.Type + " " + item.Name + " { get; }");
    } else {
      context.Write($"  {item.Type}? {item.Name}({item.Param} parameter);");
    }
  }

  internal override IEnumerable<OutputField> TypeMembers(IGqlpObject<IGqlpOutputField> ast, GqlpGeneratorContext context)
    => ast.ObjFields.Select(f => new OutputField(
      f.Name.Capitalize(),
      ModifiedTypeString(f.Type, f, context),
      f.Parameter is null ? "" : ModifiedTypeString(f.Parameter.Type, f.Parameter, context)));

  internal override MapPair<string>[] RequiredMembers(IGqlpObject<IGqlpOutputField> ast, GqlpGeneratorContext context)
    => [.. ast.ObjFields
      .Where(f => f.Parameter is null && f.Modifiers.LastOrDefault()?.ModifierKind != ModifierKind.Opt)
      .Select(f => ModifiedTypeString(f.Type, f, context).ToPair(f.Name))];

}

internal class OutputField(string fieldName, string fieldType, string fieldParam)
{
  public string Name { get; } = fieldName;
  public string Type { get; } = fieldType;
  public string Param { get; } = fieldParam;
}
