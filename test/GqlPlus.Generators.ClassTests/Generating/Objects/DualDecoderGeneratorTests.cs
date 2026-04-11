using GqlPlus.Ast.Schema;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class DualDecoderGeneratorTests
  : GenerateObjectTestsBase<IAstDualField>
{
  public DualDecoderGeneratorTests()
    : base(TypeKind.Dual)
  { }

  internal override GenerateForType<IAstObject<IAstDualField>> TypeGenerator { get; }
    = new DualDecoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Dec;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
  {
    int bracketIdx = name.IndexOf('<', StringComparison.Ordinal);
    string baseName = bracketIdx >= 0 ? name[..bracketIdx] : name;
    return ForGeneratedDecoder("internal class " + TestPrefix + baseName + "Decoder");
  }

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => _ => { };

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedDecoder(contains);

  internal override ForType ForGeneratedModel(string contains)
    => _ => result => { };

  protected override ObjFieldBuilder<IAstDualField> MakeField(string name, string type)
    => new DualFieldBuilder(name, type);
}
