using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling.Globals;

public class DirectiveModellerTests
  : ModellerClassTestBase<IAstSchemaDirective, DirectiveModel>
{
  public DirectiveModellerTests()
  {
    IModeller<IAstInputParam, InputParamModel> parameter = MFor<IAstInputParam, InputParamModel>();
    IModellerRepository modellers = A.Of<IModellerRepository>();
    modellers.ModellerFor<IAstInputParam, InputParamModel>().Returns(parameter);
    Modeller = new DirectiveModeller(modellers);
  }

  protected override IModeller<IAstSchemaDirective, DirectiveModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidDirective_ReturnsExpectedDirectiveModel(string name, string contents, string[] aliases)
  {
    // Arrange
    IAstSchemaDirective ast = A.Named<IAstSchemaDirective>(name, contents);
    ast.Aliases.Returns(aliases);
    ast.DirectiveOption.Returns(DirectiveOption.Repeatable);
    ast.Locations.Returns(DirectiveLocation.Operation | DirectiveLocation.Fragment);

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
