namespace GqlPlus.Generating.Objects;

public class OutputGeneratorTests
  : ObjectGeneratorTestBase<IGqlpOutputObject, IGqlpOutputField>
{
  public override string ExpectedTypePrefix => "Output";
  internal override GenerateForType<IGqlpOutputObject> TypeGenerator { get; }
    = new OutputGenerator();
}
