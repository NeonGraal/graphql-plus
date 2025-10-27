namespace GqlPlus.Modelling.Objects;

public class OutputModellerTests
  : ModellerObjectBaseTestBase<IGqlpObject<IGqlpOutputField>, TypeOutputModel, ObjBaseModel>
{
  public OutputModellerTests()
  {
    IModeller<IGqlpTypeParam, TypeParamModel> typeParam = MFor<IGqlpTypeParam, TypeParamModel>();
    IModeller<IGqlpAlternate, AlternateModel> alternate = MFor<IGqlpAlternate, AlternateModel>();
    IModeller<IGqlpOutputField, OutputFieldModel> objField = MFor<IGqlpOutputField, OutputFieldModel>();

    Modeller = new OutputModeller(new(typeParam, alternate, objField, ObjBase));
  }

  protected override IModeller<IGqlpObject<IGqlpOutputField>, TypeOutputModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidObject_ReturnsExpectedTypeOutputModel(string name, string[] aliases, string content)
  {
    // Arrange
    IGqlpObject<IGqlpOutputField> ast = A.Aliased<IGqlpObject<IGqlpOutputField>>(name, aliases, content);

    // Act
    TypeOutputModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(content),
        r => r.Aliases.ShouldBe(aliases));
  }
}
