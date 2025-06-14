namespace GqlPlus.Modelling.Objects;

public class InputParamModellerTests
  : ModellerClassTestBase<IGqlpInputParam, InputParamModel>
{
  private readonly IModifierModeller _modifier;
  private readonly IModeller<IGqlpConstant, ConstantModel> _constant;

  protected override IModeller<IGqlpInputParam, InputParamModel> Modeller { get; }

  public InputParamModellerTests()
  {
    _modifier = A.Of<IModifierModeller>();
    _constant = MFor<IGqlpConstant, ConstantModel>();

    Modeller = new InputParamModeller(_modifier, _constant);
  }

  [Theory, RepeatData]
  public void ToModel_WithValidInputParam_ReturnsExpectedInputParamModel(string paramType, string content, string text)
  {
    // Arrange
    IGqlpInputParam ast = A.InputParam(paramType, content, true);
    IGqlpModifier modifier = A.Modifier(ModifierKind.Opt);
    ast.Modifiers.Returns([modifier]);
    IGqlpConstant constant = A.Constant(text);
    ast.DefaultValue.Returns(constant);

    ModifierModel[] modifiers = [new(ModifierKind.Optional)];
    ToModelsReturns(_modifier, ast.Modifiers, modifiers);

    ConstantModel defaultValue = new(SimpleModel.Str("", text));
    TryModelReturns(_constant, ast.DefaultValue!, defaultValue);

    // Act
    InputParamModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Input.ShouldBe(paramType),
        r => r.Description.ShouldBe(content),
        r => r.IsTypeParam.ShouldBeTrue(),
        r => r.Modifiers.ShouldBe(modifiers),
        r => r.DefaultValue.ShouldBe(defaultValue));
  }

  [Theory, RepeatData]
  public void ToModel_WithNoModifiersOrDefaultValue_ReturnsInputParamModelWithoutModifiersOrDefaultValue(string paramType, string content)
  {
    // Arrange
    IGqlpInputParam ast = A.InputParam(paramType, content);
    ast.Modifiers.Returns([]);

    // Act
    InputParamModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Input.ShouldBe(paramType),
        r => r.Description.ShouldBe(content),
        r => r.IsTypeParam.ShouldBeFalse(),
        r => r.Modifiers.ShouldBeEmpty(),
        r => r.DefaultValue.ShouldBeNull());
  }
}
