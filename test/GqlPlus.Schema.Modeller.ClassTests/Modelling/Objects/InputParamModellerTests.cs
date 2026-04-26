using GqlPlus.Building;
using GqlPlus.Building.Schema;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class InputParamModellerTests
  : ModellerClassTestBase<IAstInputParam, InputParamModel>
{
  private readonly IModifierModeller _modifier;
  private readonly IModeller<IAstConstant, ConstantModel> _constant;

  protected override IModeller<IAstInputParam, InputParamModel> Modeller { get; }

  public InputParamModellerTests()
  {
    _modifier = A.Of<IModifierModeller>();
    _constant = MFor<IAstConstant, ConstantModel>();
    IModellerRepository modellers = A.Of<IModellerRepository>();
    modellers.ModifierModeller.Returns(_modifier);
    modellers.ModellerFor<IAstConstant, ConstantModel>().Returns(_constant);
    Modeller = new InputParamModeller(modellers);
  }

  [Theory, RepeatData]
  public void ToModel_WithValidInputParam_ReturnsExpectedInputParamModel(string paramType, string content, string text)
  {
    // Arrange
    IAstInputParam ast = A.InputParam(paramType)
      .WithDescr(content)
      .WithType(t => t.IsTypeParam())
      .WithModifier(ModifierKind.Opt)
      .AsInputParam;
    IAstConstant constant = A.Constant(text);
    ast.DefaultValue.Returns(constant);

    ModifierModel[] modifiers = [new(ModifierKind.Optional)];
    ToModelsReturns(_modifier, ast.Modifiers, modifiers);

    ConstantModel defaultValue = new(SimpleModel.Str(text));
    TryModelReturns(_constant, ast.DefaultValue!, defaultValue);

    // Act
    InputParamModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(paramType),
        r => r.Description.ShouldBe(content),
        r => r.IsTypeParam.ShouldBeTrue(),
        r => r.Modifiers.ShouldBe(modifiers),
        r => r.DefaultValue.ShouldBe(defaultValue));
  }

  [Theory, RepeatData]
  public void ToModel_WithNoModifiersOrDefaultValue_ReturnsInputParamModelWithoutModifiersOrDefaultValue(string paramType, string content)
  {
    // Arrange
    IAstInputParam ast = A.InputParam(paramType).WithDescr(content).AsInputParam;
    ast.Modifiers.Returns([]);

    // Act
    InputParamModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(paramType),
        r => r.Description.ShouldBe(content),
        r => r.IsTypeParam.ShouldBeFalse(),
        r => r.Modifiers.ShouldBeEmpty(),
        r => r.DefaultValue.ShouldBeNull());
  }
}
