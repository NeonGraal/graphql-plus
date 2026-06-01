namespace GqlPlus.Models;

public class SchemaModelFilterTests
{
  private static SchemaModel BuildSchema(
    IEnumerable<BaseTypeModel>? types = null,
    IEnumerable<CategoryModel>? categories = null,
    IEnumerable<DirectiveModel>? directives = null,
    IEnumerable<OperationModel>? operations = null,
    IEnumerable<SettingModel>? settings = null)
    => new(
      "test",
      categories ?? [],
      directives ?? [],
      operations ?? [],
      settings ?? [],
      types ?? [],
      null);

  // GetTypes tests

  [Fact]
  public void GetTypes_NullFilter_ReturnsAll()
  {
    SchemaModel schema = BuildSchema([
      new SpecialTypeModel("Alpha", ""),
      new SpecialTypeModel("Beta", ""),
    ]);

    schema.GetTypes(null).Keys.ShouldBe(["Alpha", "Beta"], ignoreOrder: true);
  }

  [Fact]
  public void GetTypes_EmptyFilter_ReturnsAll()
  {
    SchemaModel schema = BuildSchema([
      new SpecialTypeModel("Alpha", ""),
      new SpecialTypeModel("Beta", ""),
    ]);
    TypeFilterModel filter = new(new FilterModel([]));

    schema.GetTypes(filter).Keys.ShouldBe(["Alpha", "Beta"], ignoreOrder: true);
  }

  [Fact]
  public void GetTypes_KindFilter_ReturnsOnlyMatchingKind()
  {
    BaseTypeModel enumType = new TestEnumType("MyEnum");
    BaseTypeModel specialType = new SpecialTypeModel("MySpecial", "");

    SchemaModel schema = BuildSchema([enumType, specialType]);
    TypeFilterModel filter = new(new FilterModel([])) { Kinds = [TypeKindModel.Enum] };

    IMap<BaseTypeModel> result = schema.GetTypes(filter);

    result.Keys.ShouldBe(["MyEnum"]);
  }

  [Fact]
  public void GetTypes_NameFilter_ReturnsOnlyMatchingNames()
  {
    SchemaModel schema = BuildSchema([
      new SpecialTypeModel("TypeDual", ""),
      new SpecialTypeModel("TypeInput", ""),
      new SpecialTypeModel("OtherType", ""),
    ]);
    TypeFilterModel filter = new(new FilterModel(["*Dual*"]));

    IMap<BaseTypeModel> result = schema.GetTypes(filter);

    result.Keys.ShouldBe(["TypeDual"]);
  }

  [Fact]
  public void GetTypes_MultipleNameFilters_ReturnsUnionOfMatches()
  {
    SchemaModel schema = BuildSchema([
      new SpecialTypeModel("TypeDual", ""),
      new SpecialTypeModel("TypeInput", ""),
      new SpecialTypeModel("OtherType", ""),
    ]);
    TypeFilterModel filter = new(new FilterModel(["*Dual*", "*Input*"]));

    IMap<BaseTypeModel> result = schema.GetTypes(filter);

    result.Keys.ShouldBe(["TypeDual", "TypeInput"], ignoreOrder: true);
  }

  [Fact]
  public void GetTypes_NameAndKindFilter_ReturnsBothApplied()
  {
    BaseTypeModel enumType = new TestEnumType("MyEnum");
    SchemaModel schema = BuildSchema([
      enumType,
      new SpecialTypeModel("MySpecial", ""),
      new SpecialTypeModel("OtherSpecial", ""),
    ]);
    TypeFilterModel filter = new(new FilterModel(["My*"])) { Kinds = [TypeKindModel.Enum] };

    IMap<BaseTypeModel> result = schema.GetTypes(filter);

    result.Keys.ShouldBe(["MyEnum"]);
  }

  // Minimal concrete type for testing (Enum kind)
  private sealed record class TestEnumType(string Name)
    : BaseTypeModel(TypeKindModel.Enum, Name, "");
}
