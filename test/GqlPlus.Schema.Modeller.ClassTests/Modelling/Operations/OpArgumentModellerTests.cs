using GqlPlus.Ast.Operation;

namespace GqlPlus.Modelling;

public class OpArgumentModellerTests
  : ModellerClassTestBase<IAstArg, OpArgumentModel>
{
  public OpArgumentModellerTests()
    => Modeller = new OpArgumentModeller();

  protected override IModeller<IAstArg, OpArgumentModel> Modeller { get; }

  [Fact]
  public void ToModel_WithValidArg_ReturnsExpectedArgumentModel()
  {
    // Arrange
    IAstArg ast = A.Error<IAstArg>();

    // Act
    OpArgumentModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldBeOfType<OpArgumentModel>();
  }
}
