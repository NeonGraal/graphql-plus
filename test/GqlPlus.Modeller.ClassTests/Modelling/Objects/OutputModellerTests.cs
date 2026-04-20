using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling.Objects;

public class OutputModellerTests
  : ModellerObjectBaseTestBase<IAstObject<IAstOutputField>, TypeOutputModel, ObjBaseModel>
{
  public OutputModellerTests()
  {
    IModeller<IAstTypeParam, TypeParamModel> typeParam = MFor<IAstTypeParam, TypeParamModel>();
    IModeller<IAstAlternate, AlternateModel> alternate = MFor<IAstAlternate, AlternateModel>();
    IModeller<IAstOutputField, OutputFieldModel> objField = MFor<IAstOutputField, OutputFieldModel>();

    IModellerRepository modellers = A.Of<IModellerRepository>();
    modellers.ModellerFor<IAstTypeParam, TypeParamModel>().Returns(typeParam);
    modellers.ModellerFor<IAstAlternate, AlternateModel>().Returns(alternate);
    modellers.ModellerFor<IAstOutputField, OutputFieldModel>().Returns(objField);
    modellers.ModellerFor<IAstObjBase, ObjBaseModel>().Returns(ObjBase);
    Modeller = new OutputModeller(modellers);
  }

  protected override IModeller<IAstObject<IAstOutputField>, TypeOutputModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidObject_ReturnsExpectedTypeOutputModel(string name, string[] aliases, string content)
  {
    // Arrange
    IAstObject<IAstOutputField> ast = A.Aliased<IAstObject<IAstOutputField>>(name, aliases, content);

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
