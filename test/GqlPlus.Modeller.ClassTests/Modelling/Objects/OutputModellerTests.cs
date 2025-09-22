﻿namespace GqlPlus.Modelling.Objects;

public class OutputModellerTests
  : ModellerObjectBaseTestBase<IGqlpOutputObject, TypeOutputModel, ObjBaseModel>
{
  public OutputModellerTests()
  {
    IModeller<IGqlpTypeParam, TypeParamModel> typeParam = MFor<IGqlpTypeParam, TypeParamModel>();
    IModeller<IGqlpObjAlt, ObjAlternateModel> objAlt = MFor<IGqlpObjAlt, ObjAlternateModel>();
    IModeller<IGqlpOutputField, OutputFieldModel> objField = MFor<IGqlpOutputField, OutputFieldModel>();

    Modeller = new OutputModeller(new(typeParam, objAlt, objField, ObjBase));
  }

  protected override IModeller<IGqlpOutputObject, TypeOutputModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidObject_ReturnsExpectedTypeOutputModel(string name, string[] aliases, string content)
  {
    // Arrange
    IGqlpOutputObject ast = A.Aliased<IGqlpOutputObject>(name, aliases, content);

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
