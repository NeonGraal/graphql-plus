namespace GqlPlus.Modelling;

public class SpecialTypeModellerTests
  : ModellerClassTestBase<IGqlpTypeSpecial, SpecialTypeModel>
{
  protected override IModeller<IGqlpTypeSpecial, SpecialTypeModel> Modeller { get; }
    = new SpecialTypeModeller();

  [Theory, RepeatData]
  public void ToModel_WithValidSpecialType_ReturnsExpectedSpecialTypeModel(string name, string contents, string[] aliases)
  {
    // Arrange
    IGqlpTypeSpecial ast = A.Aliased<IGqlpTypeSpecial>(name, aliases, contents);

    // Act
    SpecialTypeModel result = Modeller.ToModel<SpecialTypeModel>(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull().
      ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.Aliases.ShouldBeEquivalentTo(aliases));
  }
}
