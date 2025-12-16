namespace GqlPlus.Encoding.Globals;

public class CategoriesEncoderTests
  : EncoderClassTestBase<CategoriesModel>
{
  private readonly IEncoder<CategoryModel> _category;
  private readonly IEncoder<BaseTypeModel> _baseType;

  public CategoriesEncoderTests()
  {
    _category = RFor<CategoryModel>();
    _baseType = RFor<BaseTypeModel>();
    Encoder = new CategoriesEncoder(new(_category, _baseType));
  }

  protected override IEncoder<CategoriesModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidCategoriesModel_ReturnsStructured(string name)
  {
    // Arrange
    BaseTypeModel type = new TypeInputModel(name, "");
    CategoryModel category = new(name, new(TypeKindModel.Output, name, ""), "");
    _baseType.Encode(type).Returns(new Structured(name, "Input"));
    _category.Encode(category).Returns(new Structured(name, "Category"));

    // Act
    EncodeAndCheck(new() {
      Type = type,
      And = category
    }, TagAll("_Categories",
        ":category=[Category]" + name,
        ":type=[Input]" + name));
  }
}
