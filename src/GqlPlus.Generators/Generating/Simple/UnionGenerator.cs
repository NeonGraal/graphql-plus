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
  {
    context.Write("");
    InterfaceHeader(ast, context);
    context.Write("{");
    if (ast.Parent is null) {
      context.Write("  bool HasA<T>();");
      context.Write("  T AsA<T>();");
    }

    context.Write("}");
  }
}

internal sealed class UnionModelGenerator
  : UnionGeneratorBase
{
  protected override void Generate(IAstUnion ast, GqlpGeneratorContext context)
  {
    context.Write("");
    ClassHeader(ast, context);
    context.Write("{");
    if (ast.Parent is null) {
      context.Write("  private object? _value;");
      context.Write("  public bool HasA<T>() => _value is T;");
      context.Write("  public T AsA<T>() => (T)_value!;");
    }

    context.Write("}");
  }
}

internal sealed class UnionDecoderGenerator
  : UnionGeneratorBase
{
  protected override void Generate(IAstUnion ast, GqlpGeneratorContext context)
  {
    string decoderName = context.TypeName(ast, "") + "Decoder";
    GenerateBlock(ast, context, DecoderHeader, TypeMembers, ClassMember,
      (_, c) => {
        c.Write("");
        c.Write($"  internal static {decoderName} Factory(IDecoderRepository _) => new();");
      });

    string interfaceType = context.TypeName(ast, "I");
    context.RegisterDecoder(interfaceType, decoderName);
  }
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
      context.Write("");
      context.Write($"  internal static {typeName}Encoder Factory(IEncoderRepository _) => new();");
      context.Write("}");
      context.RegisterEncoder(interfaceName, typeName + "Encoder");
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
    string encoderPrefix = "    => ";
    foreach (MapPair<string> member in members) {
      string memberCsType = context.TypeName(member.Value, "I");
      string varName = "_" + member.Key.Substring(2).ToLower(System.Globalization.CultureInfo.InvariantCulture);
      context.Write($"{encoderPrefix}input.HasA<{memberCsType}>() ? {varName}.Encode(input.AsA<{memberCsType}>())");
      encoderPrefix = "     : ";
    }

    context.Write("     : Structured.Empty();");
    context.Write("");
    context.Write($"  internal static {typeName}Encoder Factory(IEncoderRepository r) => new(r);");
    context.Write("}");
    context.RegisterEncoder(interfaceName, typeName + "Encoder", needsRepo: true);
  }
}
