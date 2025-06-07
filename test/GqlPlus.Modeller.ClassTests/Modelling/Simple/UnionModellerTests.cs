
namespace GqlPlus.Modelling.Simple;

public class UnionModellerTests
  : ModellerClassTestBase<IGqlpUnion, TypeUnionModel>
{
  protected override IModeller<IGqlpUnion, TypeUnionModel> Modeller { get; } = new UnionModeller();

  [Theory, RepeatData]
  public void ToModel_WithValidUnion_ReturnsExpectedTypeUnionModel(
    string name,
    string parent,
    string contents,
    string[] aliases)
  {
    // Arrange
    IGqlpUnion ast = A.Aliased<IGqlpUnion>(name, aliases, contents);
    ast.Parent.Returns(parent);
    ast.Items.Returns([]);

    // Act
    TypeUnionModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull();
    result.Name.ShouldBe(name);
    result.Description.ShouldBe(contents);
    result.Aliases.ShouldBe(aliases);
    result.Parent.ShouldNotBeNull()
      .TypeName.ShouldBe(parent);
  }
}
