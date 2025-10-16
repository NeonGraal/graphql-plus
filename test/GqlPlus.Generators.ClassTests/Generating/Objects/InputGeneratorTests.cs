namespace GqlPlus.Generating.Objects;

public class InputGeneratorTests
  : ObjectGeneratorTestBase<IGqlpInputObject, IGqlpInputField>
{
  internal override GenerateForType<IGqlpInputObject> TypeGenerator { get; }
    = new InputGenerator();
}
