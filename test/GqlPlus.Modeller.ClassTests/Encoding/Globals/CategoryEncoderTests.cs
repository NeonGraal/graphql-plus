﻿namespace GqlPlus.Encoding.Globals;

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
  public void Encode_WithValidCategoryModel_ReturnsStructured(string name, string outputName, string contents)
  {
    // Arrange
    TypeRefModel<TypeKindModel> output = new(TypeKindModel.Output, outputName, "");
    ModifierModel modifier = new(ModifierKind.List);
    _output.Encode(output).Returns(new Structured(outputName, "Output"));
    _modifiers.Encode(modifier).Returns(new Structured("List"));

    // Act
    EncodeAndCheck(new(name, output, contents) {
      Modifiers = [modifier],
    }, [
        "!_Category",
        "description: " + contents.Quoted("'"),
        "modifiers: [List]",
        "name: " + name,
        "output: !Output " + outputName,
        "resolution: !_Resolution Parallel"
        ]);
  }
}
