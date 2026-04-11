using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class DualModelGeneratorTests
  : GenerateObjectTestsBase<IAstDualField>
{
  public DualModelGeneratorTests()
    : base(TypeKind.Dual)
  { }

  internal override GenerateForType<IAstObject<IAstDualField>> TypeGenerator { get; }
    = new DualModelGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedModel("public class " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedModel(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedModel(contains);

  internal override ForType ForGeneratedInterface(string contains)
    => ForGeneratedModel(contains);

  protected override ObjFieldBuilder<IAstDualField> MakeField(string name, string type)
    => new DualFieldBuilder(name, type);
}
