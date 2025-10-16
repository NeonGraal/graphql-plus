namespace GqlPlus.Generating.Objects;

public class OutputGeneratorTests
  : ObjectGeneratorTestBase<IGqlpOutputObject, IGqlpOutputField>
{
  internal override GenerateForType<IGqlpOutputObject> TypeGenerator { get; }
    = new OutputGenerator();
}
