using GqlPlus.Ast.Operation;

namespace GqlPlus.Modelling;

public class OpVariableModellerTests
  : ModellerClassTestBase<IAstVariable, OpVariableModel>
{
  public OpVariableModellerTests()
    => Modeller = new OpVariableModeller();

  protected override IModeller<IAstVariable, OpVariableModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidVariable_ReturnsExpectedVariableModel(string name, string typeName)
  {
    // Arrange
    IAstVariable ast = A.Identified<IAstVariable>(name);
    ast.Type.Returns(typeName);

    // Act
    OpVariableModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Type.ShouldNotBeNull(),
        r => r.Type!.Name.ShouldBe(typeName)
      );
  }
}
