
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class InputGeneratorTests
  : GenerateObjectTestsBase<IGqlpInputField>
{
  public InputGeneratorTests()
    : base(TypeKind.Input)
  { }

  internal override GenerateForType<IGqlpObject<IGqlpInputField>> TypeGenerator { get; }
    = new InputGenerator();

  protected override ObjFieldBuilder<IGqlpInputField> MakeField(string name, string type)
    => new InputFieldBuilder(name, type);
}
