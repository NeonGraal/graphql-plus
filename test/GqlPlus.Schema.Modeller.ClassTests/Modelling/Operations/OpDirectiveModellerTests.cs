using GqlPlus.Ast.Operation;

namespace GqlPlus.Modelling;

public class OpDirectiveModellerTests
  : ModellerClassTestBase<IAstDirective, OpDirectiveModel>
{
  public OpDirectiveModellerTests()
    => Modeller = new OpDirectiveModeller();

  protected override IModeller<IAstDirective, OpDirectiveModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidDirective_ReturnsExpectedDirectiveModel(string name)
  {
    // Arrange
    IAstDirective ast = A.Identified<IAstDirective>(name);

    // Act
    OpDirectiveModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name)
      );
  }
}
