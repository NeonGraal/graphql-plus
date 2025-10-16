namespace GqlPlus.Generating.Objects;

public class DualGeneratorTests
  : ObjectGeneratorTestBase<IGqlpDualObject, IGqlpDualField>
{
  internal override GenerateForType<IGqlpDualObject> TypeGenerator { get; }
    = new DualGenerator();
}
