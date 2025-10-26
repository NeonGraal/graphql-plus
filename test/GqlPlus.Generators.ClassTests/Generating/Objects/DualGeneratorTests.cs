namespace GqlPlus.Generating.Objects;

public class DualGeneratorTests
  : GenerateObjectTestsBase<IGqlpDualObject, IGqlpDualField>
{
  public DualGeneratorTests()
    : base(TypeKind.Dual)
  { }

  internal override GenerateForType<IGqlpDualObject> TypeGenerator { get; }
    = new DualGenerator();
}
