using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class DualGeneratorParentTests
  : GenerateObjectParentTestsBase<IGqlpDualField>
{
  public DualGeneratorParentTests()
    : base(TypeKind.Dual)
  { }

  internal override GenerateForType<IGqlpObject<IGqlpDualField>> TypeGenerator { get; }
    = new DualGenerator();

  protected override ObjFieldBuilder<IGqlpDualField> MakeField(string name, string type)
    => new DualFieldBuilder(name, type);
}
