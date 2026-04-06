using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class DualModelGeneratorParentTests
  : GenerateObjectParentTestsBase<IGqlpDualField>
{
  public DualModelGeneratorParentTests()
    : base(TypeKind.Dual)
  { }

  internal override GenerateForType<IGqlpObject<IGqlpDualField>> TypeGenerator { get; }
    = new DualModelGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedImplementation("public class " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => ForGeneratedImplementation(": " + parent);

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedImplementation(contains);

  internal override ForType ForGeneratedInterface(string contains)
    => ForGeneratedImplementation(contains);

  protected override ObjFieldBuilder<IGqlpDualField> MakeField(string name, string type)
    => new DualFieldBuilder(name, type);
}
