
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
    IGqlpUnion ast = For<IGqlpUnion>();
    ast.Name.Returns(name);
    ast.Description.Returns(contents);
    ast.Aliases.Returns(aliases);
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
      .Name.ShouldBe(parent);
  }
}
