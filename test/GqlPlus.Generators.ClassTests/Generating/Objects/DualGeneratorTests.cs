
namespace GqlPlus.Generating.Objects;

public class DualGeneratorTests
  : TypeGeneratorClassTestBase<IGqlpDualObject>
{
  public override string ExpectedTypePrefix => "Dual";
  internal override GenerateForType<IGqlpDualObject> TypeGenerator { get; }
    = new DualGenerator();
}
