namespace GqlPlus.Modelling.Objects;

public class OutputModellerTests
  : ModellerClassTestBase<IGqlpOutputObject, TypeOutputModel>
{
  public OutputModellerTests()
  {
    IModeller<IGqlpOutputAlternate, OutputAlternateModel> objAlt = MFor<IGqlpOutputAlternate, OutputAlternateModel>();
    IModeller<IGqlpOutputField, OutputFieldModel> objField = MFor<IGqlpOutputField, OutputFieldModel>();
    IModeller<IGqlpOutputBase, OutputBaseModel> objBase = MFor<IGqlpOutputBase, OutputBaseModel>();

    Modeller = new OutputModeller(objAlt, objField, objBase);
  }

  protected override IModeller<IGqlpOutputObject, TypeOutputModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidObject_ReturnsExpectedTypeOutputModel(string name, string[] aliases, string content)
  {
    // Arrange
    IGqlpOutputObject ast = For<IGqlpOutputObject>();
    ast.Name.Returns(name);
    ast.Description.Returns(content);
    ast.Aliases.Returns(aliases);

    // Act
    TypeOutputModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(content),
        r => r.Aliases.ShouldBe(aliases));
  }
}
