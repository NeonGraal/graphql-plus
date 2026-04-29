using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class DualInterfaceGeneratorTests
  : GenerateObjectTestsBase<IAstDualField>
{
  public DualInterfaceGeneratorTests()
    : base(TypeKind.Dual)
  { }

  internal override GenerateForType<IAstObject<IAstDualField>> TypeGenerator { get; }
    = new DualInterfaceGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;
  internal override GqlpBaseType BaseType => GqlpBaseType.Interface;

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedInterface(": I" + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedInterface(contains);

  protected override ObjFieldBuilder<IAstDualField> MakeField(string name, string type)
    => new DualFieldBuilder(name, type);
}
