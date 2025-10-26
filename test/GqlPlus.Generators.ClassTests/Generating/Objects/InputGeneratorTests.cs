namespace GqlPlus.Generating.Objects;

public class InputGeneratorTests
  : GenerateObjectTestsBase<IGqlpInputObject, IGqlpInputField>
{
  public InputGeneratorTests()
    : base(TypeKind.Input)
  { }

  internal override GenerateForType<IGqlpInputObject> TypeGenerator { get; }
    = new InputGenerator();
}
