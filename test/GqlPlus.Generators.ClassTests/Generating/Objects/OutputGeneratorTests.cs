namespace GqlPlus.Generating.Objects;

public class OutputGeneratorTests
  : TypeGeneratorClassTestBase<IGqlpOutputObject, IGqlpObjBase>
{
  public override string ExpectedTypePrefix => "Output";
  internal override GenerateForType<IGqlpOutputObject> TypeGenerator { get; }
    = new OutputGenerator();
}
