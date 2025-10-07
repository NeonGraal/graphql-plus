namespace GqlPlus.Generating.Objects;

public class DualGeneratorTests
  : ObjectGeneratorTestBase<IGqlpDualObject, IGqlpDualField>
{
  public override string ExpectedTypePrefix => "Dual";
  internal override GenerateForType<IGqlpDualObject> TypeGenerator { get; }
    = new DualGenerator();
}
