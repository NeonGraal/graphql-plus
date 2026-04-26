namespace GqlPlus.Modelling.Objects;

public class DualModellerTests
  : ModellerObjectBaseTestBase<IAstObject<IAstDualField>, TypeDualModel, ObjBaseModel>
{
  public DualModellerTests()
  {
    IModeller<IAstTypeParam, TypeParamModel> typeParam = MFor<IAstTypeParam, TypeParamModel>();
    IModeller<IAstAlternate, AlternateModel> alternate = MFor<IAstAlternate, AlternateModel>();
    IModeller<IAstDualField, DualFieldModel> objField = MFor<IAstDualField, DualFieldModel>();

    IModellerRepository modellers = A.Of<IModellerRepository>();
    modellers.ModellerFor<IAstTypeParam, TypeParamModel>().Returns(typeParam);
    modellers.ModellerFor<IAstAlternate, AlternateModel>().Returns(alternate);
    modellers.ModellerFor<IAstDualField, DualFieldModel>().Returns(objField);
    modellers.ModellerFor<IAstObjBase, ObjBaseModel>().Returns(ObjBase);
    Modeller = new DualModeller(modellers);
  }

  protected override IModeller<IAstObject<IAstDualField>, TypeDualModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidObject_ReturnsExpectedTypeDualModel(string name, string[] aliases, string content)
  {
    // Arrange
    IAstObject<IAstDualField> ast = A.Aliased<IAstObject<IAstDualField>>(name, aliases, content);

    // Act
    TypeDualModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(content),
        r => r.Aliases.ShouldBe(aliases));
  }
}
