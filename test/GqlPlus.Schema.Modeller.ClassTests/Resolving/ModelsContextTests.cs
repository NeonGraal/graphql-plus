namespace GqlPlus.Resolving;

public class ModelsContextTests
{
  private readonly ModelsContext _context = [];

  [Fact]
  public void Errors_Default_IsEmpty()
    => _context.Errors.ShouldBeEmpty();

  [Fact]
  public void TypeKinds_Default_ReturnsSelf()
    => ((IModelsContext)_context).TypeKinds.ShouldBeSameAs(_context);

  [Theory, RepeatData]
  public void AddModels_SingleModel_AddsModelByNameToTypes(string name)
  {
    TypeEnumModel model = new(name, "");

    _context.AddModels([model]);

    _context.Types.ShouldContainKey(name);
    _context.Types[name].ShouldBe(model);
  }

  [Theory, RepeatData]
  public void AddModels_ModelWithAliases_AddsEachAliasToTypes(string name, string alias)
  {
    TypeEnumModel model = new(name, "") { Aliases = [alias] };

    _context.AddModels([model]);

    _context.Types.ShouldContainKey(alias);
    _context.Types[alias].ShouldBe(model);
  }

  [Theory, RepeatData]
  public void AddModels_DuplicateAlias_PreservesFirstModel(string name1, string name2, string alias)
  {
    this.SkipEqual(name1, name2);
    this.SkipEqual(name2, alias);

    TypeEnumModel first = new(name1, "") { Aliases = [alias] };
    TypeEnumModel second = new(name2, "") { Aliases = [alias] };

    _context.AddModels([first, second]);

    _context.Types[alias].ShouldBe(first);
  }

  [Theory, RepeatData]
  public void TryGetType_NullName_ReturnsFalse(string label)
  {
    bool result = _context.TryGetType<TypeEnumModel>(label, null, out TypeEnumModel? model);

    result.ShouldBeFalse();
    model.ShouldBeNull();
    _context.Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void TryGetType_UnknownName_ReturnsFalseAndAddsError(string label, string name)
  {
    bool result = _context.TryGetType<TypeEnumModel>(label, name, out TypeEnumModel? model);

    result.ShouldBeFalse();
    model.ShouldBeNull();
    _context.Errors.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void TryGetType_UnknownName_CanErrorFalse_ReturnsFalseWithNoError(string label, string name)
  {
    bool result = _context.TryGetType<TypeEnumModel>(label, name, out TypeEnumModel? model, canError: false);

    result.ShouldBeFalse();
    model.ShouldBeNull();
    _context.Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void TryGetType_KnownNameMatchingType_ReturnsTrueWithModel(string label, string name)
  {
    TypeEnumModel expected = new(name, "");
    _context.AddModels([expected]);

    bool result = _context.TryGetType<TypeEnumModel>(label, name, out TypeEnumModel? model);

    result.ShouldBeTrue();
    model.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void TryGetType_KnownNameWrongType_ReturnsFalseAndAddsError(string label, string name)
  {
    TypeEnumModel stored = new(name, "");
    _context.AddModels([stored]);

    bool result = _context.TryGetType<SpecialTypeModel>(label, name, out SpecialTypeModel? model);

    result.ShouldBeFalse();
    model.ShouldBeNull();
    _context.Errors.ShouldNotBeEmpty();
  }
}
