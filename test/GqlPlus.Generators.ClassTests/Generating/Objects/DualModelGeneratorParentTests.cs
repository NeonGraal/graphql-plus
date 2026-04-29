using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class DualModelGeneratorParentTests
  : GenerateObjectParentTestsBase<IAstDualField>
{
  public DualModelGeneratorParentTests()
    : base(TypeKind.Dual)
  { }

  internal override GenerateForType<IAstObject<IAstDualField>> TypeGenerator { get; }
    = new DualModelGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedModel(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedModel(contains);

  internal override ForType ForGeneratedInterface(string contains)
    => ForGeneratedModel(contains);

  protected override ObjFieldBuilder<IAstDualField> MakeField(string name, string type)
    => new DualFieldBuilder(name, type);
}
