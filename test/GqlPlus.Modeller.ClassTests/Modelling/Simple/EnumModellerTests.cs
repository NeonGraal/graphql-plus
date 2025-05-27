namespace GqlPlus.Modelling.Simple;

public class EnumModellerTests
  : ModellerClassTestBase<IGqlpEnum, TypeEnumModel>
{
  protected override IModeller<IGqlpEnum, TypeEnumModel> Modeller { get; } = new EnumModeller();

  [Theory, RepeatData]
  public void ToModel_WithValidEnum_ReturnsExpectedTypeEnumModel(
    string name,
    string parent,
    string contents,
    string[] aliases)
  {
    // Arrange
    IGqlpEnum ast = For<IGqlpEnum>();
    ast.Name.Returns(name);
    ast.Description.Returns(contents);
    ast.Aliases.Returns(aliases);
    ast.Parent.Returns(parent);

    // Act
    TypeEnumModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.Aliases.ShouldBe(aliases),
        r => r.Parent.ShouldNotBeNull()
          .TypeName.ShouldBe(parent));
  }
}
