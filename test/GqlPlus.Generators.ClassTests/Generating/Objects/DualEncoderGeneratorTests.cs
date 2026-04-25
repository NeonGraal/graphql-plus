using GqlPlus.Ast.Schema;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class DualEncoderGeneratorTests
  : GenerateObjectTestsBase<IAstDualField>
{
  public DualEncoderGeneratorTests()
    : base(TypeKind.Dual)
  { }

  internal override GenerateForType<IAstObject<IAstDualField>> TypeGenerator { get; }
    = new DualEncoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
  {
    int bracketIdx = name.IndexOf('<', StringComparison.Ordinal);
    string baseName = bracketIdx >= 0 ? name[..bracketIdx] : name;
    return ForGeneratedEncoder("internal class " + TestPrefix + baseName + "Encoder");
  }

  protected override ObjFieldBuilder<IAstDualField> MakeField(string name, string type)
    => new DualFieldBuilder(name, type);
}
