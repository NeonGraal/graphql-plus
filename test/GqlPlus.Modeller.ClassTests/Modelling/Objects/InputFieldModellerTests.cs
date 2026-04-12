using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Building.Schema;

namespace GqlPlus.Modelling.Objects;

public class InputFieldModellerTests
  : ModellerObjectBaseTestBase<IAstInputField, InputFieldModel, ObjBaseModel>
{
  private readonly IModeller<IAstConstant, ConstantModel> _constant = MFor<IAstConstant, ConstantModel>();

  public InputFieldModellerTests()
  {
    IModifierModeller modifier = A.Of<IModifierModeller>();
    IModellerRepository modellers = A.Of<IModellerRepository>();
    modellers.ModifierModeller.Returns(modifier);
    modellers.ModellerFor<IAstObjBase, ObjBaseModel>().Returns(ObjBase);
    modellers.ModellerFor<IAstConstant, ConstantModel>().Returns(_constant);
    Modeller = new InputFieldModeller(modellers);
  }

  protected override IModeller<IAstInputField, InputFieldModel> Modeller { get; }

  [Theory, RepeatData]
  public void FieldModel_WithValidField_ReturnsExpectedInputFieldModel(string name, string contents, string typeName)
  {
    // Arrange
    IAstInputField ast = A.InputField(name, typeName).WithDescr(contents).AsInputField;

    ObjBaseModel typeModel = new(typeName, "");
    ToModelReturns(ObjBase, typeModel);

    // Act
    InputFieldModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.Type.ShouldBe(typeModel),
        r => r.Default.ShouldBeNull()
      );
  }

  [Theory, RepeatData]
  public void FieldModel_WithValidDefault_ReturnsExpectedInputFieldModel(string name, string contents, string typeName, string defaultValue)
  {
    // Arrange
    IAstInputField ast = A.InputField(name, typeName)
      .WithDescr(contents)
      .WithDefault(A.Constant(defaultValue))
      .AsInputField;

    ObjBaseModel typeModel = new(typeName, "");
    ToModelReturns(ObjBase, typeModel);

    ConstantModel defaultModel = new(new SimpleModel(defaultValue));
    TryModelReturns(_constant, defaultModel);

    // Act
    InputFieldModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.Type.ShouldBe(typeModel),
        r => r.Default.ShouldBe(defaultModel)
      );
  }
}
