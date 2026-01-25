namespace GqlPlus.Encoding.Globals;

public class CategoryEncoderTests
  : EncoderClassTestBase<CategoryModel>
{
  private readonly IEncoder<ModifierModel> _modifiers;
  private readonly IEncoder<TypeRefModel<TypeKindModel>> _output;

  public CategoryEncoderTests()
  {
    _modifiers = RFor<ModifierModel>();
    _output = RFor<TypeRefModel<TypeKindModel>>();
    Encoder = new CategoryEncoder(_modifiers, _output);
  }

  protected override IEncoder<CategoryModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidCategoryModel_ReturnsStructured(string name, string outputName, string contents, string description)
  {
    // Arrange
    TypeRefModel<TypeKindModel> output = new(TypeKindModel.Output, outputName, description);
    ModifierModel modifier = new(ModifierKind.List);
    _output.Encode(output).Returns(new Structured(outputName, "Output"));
    _modifiers.Encode(modifier).Returns(new Structured("List"));

    // Act
    EncodeAndCheck(new(name, output, contents) {
      Modifiers = [modifier],
    }, [
        "[_Category]:description=" + contents.QuotedIdentifier(),
        "[_Category]:modifiers.0=List",
        "[_Category]:name=" + name,
        "[_Category]:output=[Output]" + outputName,
        "[_Category]:resolution=[_Resolution]Parallel"
        ]);
  }
}
