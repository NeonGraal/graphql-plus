using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Generating.Objects;

public class InputDecoderGeneratorTests
  : GenerateObjectTestsBase<IAstInputField>
{
  public InputDecoderGeneratorTests()
    : base(TypeKind.Input)
  { }

  internal override GenerateForType<IAstObject<IAstInputField>> TypeGenerator { get; }
    = new InputDecoderGenerator();
  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Dec;
  internal override GqlpBaseType BaseType => GqlpBaseType.Class;

  internal override ForType ForGeneratedCodeName(string name)
  {
    int bracketIdx = name.IndexOf('<', StringComparison.Ordinal);
    string baseName = bracketIdx >= 0 ? name[..bracketIdx] : name;
    return ForGeneratedDecoder("internal class " + TestPrefix + baseName + "Decoder");
  }

  internal override ForType ForGeneratedBoth(string contains)
    => ForGeneratedDecoder(GeneratorClassTestHelpers.MakeNullable(contains));

  protected override ObjFieldBuilder<IAstInputField> MakeField(string name, string type)
    => new InputFieldBuilder(name, type);
}
