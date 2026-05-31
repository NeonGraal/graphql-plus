namespace GqlPlus.Modelling;

public class OpResultModellerTests
  : ModellerClassTestBase<IAstTypeRef, OpResultModel>
{
  public OpResultModellerTests()
    => Modeller = new OpResultModeller();

  protected override IModeller<IAstTypeRef, OpResultModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidTypeRef_ReturnsExpectedResultModel(string typeName)
  {
    // Arrange
    IAstTypeRef ast = A.Named<IAstTypeRef>(typeName);

    // Act
    OpResultModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Domain.Name.ShouldBe(typeName)
      );
  }
}
