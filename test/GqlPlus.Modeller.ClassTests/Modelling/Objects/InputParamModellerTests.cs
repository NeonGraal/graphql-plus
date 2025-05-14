using GqlPlus.Ast;

namespace GqlPlus.Modelling.Objects;

public class InputParamModellerTests
  : ModellerClassTestBase<IGqlpInputParam, InputParamModel>
{
  private readonly IModifierModeller _modifier;
  private readonly IModeller<IGqlpConstant, ConstantModel> _constant;

  protected override IModeller<IGqlpInputParam, InputParamModel> Modeller { get; }

  public InputParamModellerTests()
  {
    _modifier = For<IModifierModeller>();
    _constant = MFor<IGqlpConstant, ConstantModel>();

    Modeller = new InputParamModeller(_modifier, _constant);
  }

  [Theory, RepeatData]
  public void ToModel_WithValidInputParam_ReturnsExpectedInputParamModel(string paramType, string content)
  {
    // Arrange
    IGqlpInputParam ast = For<IGqlpInputParam>();
    IGqlpInputBase type = For<IGqlpInputBase>();
    type.Input.Returns(paramType);
    type.IsTypeParam.Returns(true);
    ast.Type.Returns(type);
    ast.Description.Returns(content);
    ast.Modifiers.Returns([For<IGqlpModifier>()]);
    ast.DefaultValue.Returns(For<IGqlpConstant>());

    ModifierModel[] modifiers = [new ModifierModel(ModifierKind.Optional)];
    _modifier.ToModels<ModifierModel>(ast.Modifiers, TypeKinds).Returns(modifiers);

    ConstantModel defaultValue = new(SimpleModel.Str("", "DefaultValue"));
    _constant.TryModel(ast.DefaultValue, TypeKinds).Returns(defaultValue);

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
    IGqlpInputParam ast = For<IGqlpInputParam>();
    IGqlpInputBase type = For<IGqlpInputBase>();
    type.Input.Returns(paramType);
    ast.Type.Returns(type);
    ast.Description.Returns(content);
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
