namespace GqlPlus.Modelling.Objects;

public class TypeParamModellerTests
  : ModellerClassTestBase<IGqlpTypeParam, TypeParamModel>
{
  public TypeParamModellerTests()
    => Modeller = new TypeParamModeller();

  protected override IModeller<IGqlpTypeParam, TypeParamModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidConstraint_ReturnsExpectedTypeParamModel(string name, string constraint)
  {
    // Arrange
    IGqlpTypeParam ast = A.TypeParam(name, constraint);
    TypeKinds.TryGetValue(constraint, out TypeKindModel _).Returns(OutValue(TypeKindModel.Special, 1));

    // Act
    TypeParamModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Constraint.ShouldNotBeNull()
          .TypeKind.ShouldBe(TypeKindModel.Special));
  }

  [Theory, RepeatData]
  public void ToModel_WithInvalidConstraint_ReturnsExpectedTypeParamModel(string name, string constraint)
  {
    // Arrange
    IGqlpTypeParam ast = A.TypeParam(name, constraint);

    // Act
    TypeParamModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Constraint.ShouldBeNull());
  }
}
