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
  {
    int bracketIdx = name.IndexOf('<', StringComparison.Ordinal);
    string baseName = bracketIdx >= 0 ? name[..bracketIdx] : name;
    return ForGeneratedEncoder("internal class " + TestPrefix + baseName + "Encoder");
  }

  protected override ObjFieldBuilder<IAstInputField> MakeField(string name, string type)
    => new InputFieldBuilder(name, type);
}
