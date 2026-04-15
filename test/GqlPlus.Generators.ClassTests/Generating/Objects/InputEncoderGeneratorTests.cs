using GqlPlus.Ast.Schema;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class InputEncoderGeneratorTests
  : GenerateObjectTestsBase<IAstInputField>
{
  public InputEncoderGeneratorTests()
    : base(TypeKind.Input)
  { }

  internal override GenerateForType<IAstObject<IAstInputField>> TypeGenerator { get; }
    = new InputEncoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enc;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
    => _ => result => result.ShouldBeNullOrWhiteSpace();

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => result => result.ShouldBeNullOrWhiteSpace();

  internal override ForType ForGeneratedBoth(string contains)
    => _ => result => result.ShouldBeNullOrWhiteSpace();

  internal override ForType ForGeneratedInterface(string contains)
    => _ => result => result.ShouldBeNullOrWhiteSpace();

  protected override ObjFieldBuilder<IAstInputField> MakeField(string name, string type)
    => new InputFieldBuilder(name, type);
}
