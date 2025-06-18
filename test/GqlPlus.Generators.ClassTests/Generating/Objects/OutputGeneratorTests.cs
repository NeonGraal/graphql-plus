
namespace GqlPlus.Generating.Objects;

public class OutputGeneratorTests
  : TypeGeneratorClassTestBase<IGqlpOutputObject>
{
  public override string ExpectedTypePrefix => "Output";
  internal override GenerateForType<IGqlpOutputObject> TypeGenerator { get; }
    = new OutputGenerator();
}
