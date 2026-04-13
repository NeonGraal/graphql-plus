namespace GqlPlus.Generating.Simple;

internal abstract class UnionGeneratorBase
  : GenerateForSimple<IAstUnion>
{
  protected override bool HasDefaultParent(out string? defaultParent)
  {
    defaultParent = null;
    return false;
  }

  internal override IEnumerable<MapPair<string>> TypeMembers(IAstUnion ast, GqlpGeneratorTypes types)
    => ast.Items.Select(item => new MapPair<string>("As" + item.Name, item.Name));
}

internal sealed class UnionInterfaceGenerator
  : UnionGeneratorBase
{
  protected override void Generate(IAstUnion ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
}

internal sealed class UnionModelGenerator
  : UnionGeneratorBase
{
  protected override void Generate(IAstUnion ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);
}

internal sealed class UnionDecoderGenerator
  : UnionGeneratorBase
{
  protected override void Generate(IAstUnion ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, DecoderHeader, TypeMembers, ClassMember);
}

internal sealed class UnionEncoderGenerator
  : UnionGeneratorBase
{
  protected override void Generate(IAstUnion ast, GqlpGeneratorContext context)
  {
    string typeName = context.TypeName(ast, "");
    string interfaceName = context.TypeName(ast, "I");
    MapPair<string>[] members = TypeMembers(ast, context).ToArray();

    context.Write("");
    if (members.Length == 0) {
      context.Write($"internal class {typeName}Encoder : IEncoder<{interfaceName}>");
      context.Write("{");
      context.Write($"  public Structured Encode({interfaceName} input)");
      context.Write("    => Structured.Empty();");
      context.Write("}");
      return;
    }

    context.Write($"internal class {typeName}Encoder(");
    context.Write("  IEncoderRepository encoders");
    context.Write($") : IEncoder<{interfaceName}>");
    context.Write("{");

    foreach (MapPair<string> member in members) {
      string memberCsType = context.TypeName(member.Value, "I");
      string varName = "_" + member.Key.Substring(2).ToLower(System.Globalization.CultureInfo.InvariantCulture);
      context.Write($"  private readonly IEncoder<{memberCsType}> {varName} = encoders.EncoderFor<{memberCsType}>();");
    }

    context.Write($"  public Structured Encode({interfaceName} input)");
    context.Write("    => input switch {");

    foreach (MapPair<string> member in members) {
      string varName = "_" + member.Key.Substring(2).ToLower(System.Globalization.CultureInfo.InvariantCulture);
      context.Write($"      {{ {member.Key}: {{ }} m }} => {varName}.Encode(m),");
    }

    context.Write("      _ => Structured.Empty()");
    context.Write("    };");
    context.Write("}");
  }
}
