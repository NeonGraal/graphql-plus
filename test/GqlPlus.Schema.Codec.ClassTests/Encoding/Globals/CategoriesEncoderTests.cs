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
    IEncoderRepository repo = A.Of<IEncoderRepository>();
    repo.EncoderFor<CategoryModel>().Returns(_category);
    repo.EncoderFor<BaseTypeModel>().Returns(_baseType);
    Encoder = new CategoriesEncoder(repo);
  }

  protected override IEncoder<CategoriesModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidCategoriesModel_ReturnsStructured(string name)
  {
    // Arrange
    BaseTypeModel type = new TypeInputModel(name, string.Empty);
    CategoryModel category = new(name, new(TypeKindModel.Output, name, string.Empty), string.Empty);
    _baseType.Encode(type).Returns(name.Encode("Input"));
    _category.Encode(category).Returns(name.Encode("Category"));

    // Act
    EncodeAndCheck(new() {
      Type = type,
      And = category
    }, TagAll("_Categories",
        ":category=[Category]" + name,
        ":type=[Input]" + name));
  }
}
