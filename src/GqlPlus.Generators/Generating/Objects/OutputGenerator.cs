namespace GqlPlus.Generating.Objects;

internal class OutputGenerator
  : GenerateForObject<IGqlpOutputField, OutputField>
{
  protected override void ClassMember(OutputField item, GqlpGeneratorContext context)
  {
    string member = $"public {item.Type} {item.Name} ";
    if (string.IsNullOrEmpty(item.Param)) {
      context.Write(member + "{ get; set; }");
    } else {
      context.Write($"{member}({item.Param})");
      context.Write("{ }");
    }
  }

  protected override void InterfaceMember(OutputField item, GqlpGeneratorContext context)
  {
    string member = $"{item.Type} {item.Name} ";
    if (string.IsNullOrEmpty(item.Param)) {
      context.Write(member + "{ get; }");
    } else {
      context.Write($"{member}({item.Param} parameter);");
    }
  }

  internal override IEnumerable<OutputField> TypeMembers(IGqlpObject<IGqlpOutputField> ast, GqlpGeneratorContext context)
    => ast.ObjFields.Select(f => new OutputField(
      f.Name.Capitalize(),
      ModifiedTypeString(f.Type, f, context),
      f.Parameter is null ? "" : ModifiedTypeString(f.Parameter.Type, f.Parameter, context)));
}

internal class OutputField(string fieldName, string fieldType, string fieldParam)
{
  public string Name { get; } = fieldName;
  public string Type { get; } = fieldType;
  public string Param { get; } = fieldParam;
}
