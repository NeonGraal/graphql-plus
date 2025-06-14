namespace GqlPlus.Modelling.Globals;

public class DirectiveModellerTests
  : ModellerClassTestBase<IGqlpSchemaDirective, DirectiveModel>
{
  public DirectiveModellerTests()
  {
    IModeller<IGqlpInputParam, InputParamModel> parameter = MFor<IGqlpInputParam, InputParamModel>();

    Modeller = new DirectiveModeller(parameter);
  }

  protected override IModeller<IGqlpSchemaDirective, DirectiveModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidDirective_ReturnsExpectedDirectiveModel(string name, string contents, string[] aliases)
  {
    // Arrange
    IGqlpSchemaDirective ast = A.Named<IGqlpSchemaDirective>(name, contents);
    ast.Aliases.Returns(aliases);
    ast.DirectiveOption.Returns(DirectiveOption.Repeatable);
    ast.Locations.Returns(DirectiveLocation.Operation | DirectiveLocation.Fragment);
    ast.Params.Returns([]);

    // Act
    DirectiveModel result = Modeller.ToModel<DirectiveModel>(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.Aliases.ShouldBeEquivalentTo(aliases),
        r => r.Repeatable.ShouldBeTrue(),
        r => r.Locations.ShouldBe(DirectiveLocation.Operation | DirectiveLocation.Fragment)
      );
  }
}
