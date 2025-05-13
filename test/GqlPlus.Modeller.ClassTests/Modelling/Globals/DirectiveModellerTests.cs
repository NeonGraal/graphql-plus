namespace GqlPlus.Modelling.Globals;

public class DirectiveModellerTests
  : ModellerClassTestBase
{
  private readonly DirectiveModeller _sut;

  public DirectiveModellerTests()
  {
    IModeller<IGqlpInputParam, InputParamModel> parameter = For<IModeller<IGqlpInputParam, InputParamModel>>();
    _sut = new DirectiveModeller(parameter);
  }

  [Fact]
  public void ToModel_WithValidDirective_ReturnsExpectedDirectiveModel()
  {
    // Arrange
    IGqlpSchemaDirective ast = For<IGqlpSchemaDirective>();
    ast.Name.Returns("DirectiveName");
    ast.Description.Returns("Directive description");
    ast.Aliases.Returns(["Alias1", "Alias2"]);
    ast.DirectiveOption.Returns(DirectiveOption.Repeatable);
    ast.Locations.Returns(DirectiveLocation.Operation | DirectiveLocation.Fragment);
    ast.Params.Returns([]);

    // Act
    DirectiveModel result = _sut.ToModel<DirectiveModel>(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull();
    result.Name.ShouldBe("DirectiveName");
    result.Description.ShouldBe("Directive description");
    result.Aliases.ShouldContain("Alias1");
    result.Aliases.ShouldContain("Alias2");
    result.Repeatable.ShouldBeTrue();
    result.Locations.ShouldBe(DirectiveLocation.Operation | DirectiveLocation.Fragment);
  }
}
