namespace GqlPlus.Generating.Objects;

public class InputGeneratorTests
  : ObjectGeneratorTestBase<IGqlpInputObject, IGqlpInputField>
{
  public override string ExpectedTypePrefix => "Input";
  internal override GenerateForType<IGqlpInputObject> TypeGenerator { get; }
    = new InputGenerator();
}
