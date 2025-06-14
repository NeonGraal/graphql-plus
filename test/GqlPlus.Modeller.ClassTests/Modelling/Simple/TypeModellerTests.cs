namespace GqlPlus.Modelling.Simple;

public abstract class TypeModellerTests<TAst, TModel>(
  TypeKindModel kind
) : ModellerClassTestBase<TAst, TModel>
  where TAst : class, IGqlpSimple
  where TModel : BaseTypeModel
{
  private ITypeModeller TypeModeller => (ITypeModeller)Modeller;

  [Theory, RepeatData]
  public void ToModel_WithValidType_ReturnsExpectedTypeModel(string name, string contents, string[] aliases)
  {
    // Arrange
    TAst ast = A.Aliased<TAst>(name, aliases, contents);

    // Act
    TModel result = Modeller.ToModel<TModel>(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.Aliases.ShouldBeEquivalentTo(aliases));
  }

  [Theory, RepeatData]
  public void ToTypeModel_WithValidType_ReturnsExpectedTypeModel(string name)
  {
    // Arrange
    TAst ast = A.Named<TAst>(name);

    // Act
    BaseTypeModel result = TypeModeller.ToTypeModel(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<TModel>()
      .Name.ShouldBe(name);
  }

  [Fact]
  public void Kind_ReturnsExpected()
  {
    TypeKindModel result = TypeModeller.Kind;

    result.ShouldBe(kind);
  }

  [Fact]
  public void ForTypeValid_ReturnsTrue()
  {
    IGqlpType ast = A.Error<TAst>();

    bool result = TypeModeller.ForType(ast);

    result.ShouldBeTrue();
  }

  [Fact]
  public void ForTypeInvalid_ReturnsTrue()
  {
    IGqlpType ast = A.Error<IGqlpType>();

    bool result = TypeModeller.ForType(ast);

    result.ShouldBeFalse();
  }
}
