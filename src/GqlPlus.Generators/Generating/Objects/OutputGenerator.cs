using GqlPlus.Ast;

namespace GqlPlus.Generating.Objects;

internal abstract class OutputGeneratorBase
  : GenerateForObject<IAstOutputField, OutputField>
{
  protected override void ClassMember(OutputField item, GqlpGeneratorContext context)
  {
    context.Write("  public " + item.Type + " " + item.Name + " { get; set; }");

    if (!string.IsNullOrEmpty(item.Param)) {
      context.Write($"  public {item.Type.Trim('?')}? Call_{item.Name}({item.Param} parameter)");
      context.Write("    => null;");
    }
  }

  protected override void InterfaceMember(OutputField item, GqlpGeneratorContext context)
  {
    context.Write("  " + item.Type + " " + item.Name + " { get; }");

    if (!string.IsNullOrEmpty(item.Param)) {
      context.Write($"  {item.Type.Trim('?')}? Call_{item.Name}({item.Param} parameter);");
    }
  }

  internal override IEnumerable<OutputField> TypeMembers(IAstObject<IAstOutputField> ast, GqlpGeneratorTypes types)
    => ast.ObjFields.Select(f => new OutputField(
      f.Name.Capitalize(),
      ModifiedTypeString(f.Type, f, types),
      f.Parameter is null ? "" : ModifiedTypeString(f.Parameter.Type, f.Parameter, types)));
}

internal sealed class OutputInterfaceGenerator
  : OutputGeneratorBase
{
  protected override void Generate(IAstObject<IAstOutputField> ast, GqlpGeneratorContext context)
    => GenerateObjectInterfaces(ast, context);
}

internal sealed class OutputModelGenerator
  : OutputGeneratorBase
{
  protected override void Generate(IAstObject<IAstOutputField> ast, GqlpGeneratorContext context)
    => GenerateObjectClasses(ast, context);
}

internal sealed class OutputDecoderGenerator
  : OutputGeneratorBase
{
  protected override void Generate(IAstObject<IAstOutputField> ast, GqlpGeneratorContext context)
  { }
}

internal sealed class OutputEncoderGenerator()
  : ObjectEncoderGeneratorBase<IAstOutputField>;

internal class OutputField(string fieldName, string fieldType, string fieldParam)
{
  public string Name { get; } = fieldName;
  public string Type { get; } = fieldType;
  public string Param { get; } = fieldParam;
}
