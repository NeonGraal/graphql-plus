using GqlPlus.Ast.Operation;

namespace GqlPlus.Modelling;

public class OpFragmentModellerTests
  : ModellerClassTestBase<IAstFragment, OpFragmentModel>
{
  public OpFragmentModellerTests()
    => Modeller = new OpFragmentModeller();

  protected override IModeller<IAstFragment, OpFragmentModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidFragment_ReturnsExpectedFragmentModel(string name, string typeName)
  {
    // Arrange
    IAstFragment ast = A.Identified<IAstFragment>(name);
    ast.OnType.Returns(typeName);

    // Act
    OpFragmentModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Type.Name.ShouldBe(typeName)
      );
  }
}
