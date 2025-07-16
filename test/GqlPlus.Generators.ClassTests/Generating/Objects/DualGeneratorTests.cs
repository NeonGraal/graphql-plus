namespace GqlPlus.Generating.Objects;

public class DualGeneratorTests
  : TypeGeneratorClassTestBase<IGqlpDualObject, IGqlpObjBase>
{
  public override string ExpectedTypePrefix => "Dual";
  internal override GenerateForType<IGqlpDualObject> TypeGenerator { get; }
    = new DualGenerator();
}
