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

  // GetCategories tests

  private static CategoryModel MakeCategory(string name, CategoryOptionModel resolution = CategoryOptionModel.Parallel, string[]? aliases = null)
  {
    CategoryModel cat = new(name, new(TypeKindModel.Output, "Out", ""), "");
    cat.Resolution = resolution;
    if (aliases is not null) {
      cat.Aliases = aliases;
    }

    return cat;
  }

  [Fact]
  public void GetCategories_NullFilter_ReturnsAll()
  {
    SchemaModel schema = BuildSchema(categories: [
      MakeCategory("Cat1"),
      MakeCategory("Cat2"),
    ]);

    schema.GetCategories(null).Keys.ShouldBe(["Cat1", "Cat2"], ignoreOrder: true);
  }

  [Fact]
  public void GetCategories_EmptyFilter_ReturnsAll()
  {
    SchemaModel schema = BuildSchema(categories: [
      MakeCategory("Cat1"),
      MakeCategory("Cat2"),
    ]);
    CategoryFilterModel filter = new(new FilterModel([]));

    schema.GetCategories(filter).Keys.ShouldBe(["Cat1", "Cat2"], ignoreOrder: true);
  }

  [Fact]
  public void GetCategories_ResolutionFilter_ReturnsOnlyMatchingResolution()
  {
    SchemaModel schema = BuildSchema(categories: [
      MakeCategory("ParallelCat", CategoryOptionModel.Parallel),
      MakeCategory("SingleCat", CategoryOptionModel.Single),
    ]);
    CategoryFilterModel filter = new(new FilterModel([])) { Resolutions = [CategoryOptionModel.Parallel] };

    IMap<CategoriesModel> result = schema.GetCategories(filter);

    result.Keys.ShouldBe(["ParallelCat"]);
  }

  [Fact]
  public void GetCategories_NameFilter_ReturnsOnlyMatchingNames()
  {
    SchemaModel schema = BuildSchema(categories: [
      MakeCategory("SchemaCat"),
      MakeCategory("OtherCat"),
    ]);
    CategoryFilterModel filter = new(new FilterModel(["Schema*"]));

    IMap<CategoriesModel> result = schema.GetCategories(filter);

    result.Keys.ShouldBe(["SchemaCat"]);
  }

  [Fact]
  public void GetCategories_NameAndResolutionFilter_ReturnsBothApplied()
  {
    SchemaModel schema = BuildSchema(categories: [
      MakeCategory("SchemaCat", CategoryOptionModel.Parallel),
      MakeCategory("SchemaSequential", CategoryOptionModel.Sequential),
      MakeCategory("OtherCat", CategoryOptionModel.Parallel),
    ]);
    CategoryFilterModel filter = new(new FilterModel(["Schema*"])) { Resolutions = [CategoryOptionModel.Parallel] };

    IMap<CategoriesModel> result = schema.GetCategories(filter);

    result.Keys.ShouldBe(["SchemaCat"]);
  }

  // Minimal concrete type for testing (Enum kind)
  private sealed record class TestEnumType(string Name)
    : BaseTypeModel(TypeKindModel.Enum, Name, "");
}
