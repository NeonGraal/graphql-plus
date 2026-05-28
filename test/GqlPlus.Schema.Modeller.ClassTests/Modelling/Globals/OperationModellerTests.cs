using GqlPlus.Ast.Operation;

namespace GqlPlus.Modelling.Globals;

public class OperationModellerTests
  : ModellerClassTestBase<IAstSchemaOperation, OperationModel>
{
  private readonly IModeller<IAstDirective, OpDirectiveModel> _directive = MFor<IAstDirective, OpDirectiveModel>();
  private readonly IModeller<IAstFragment, OpFragmentModel> _fragment = MFor<IAstFragment, OpFragmentModel>();
  private readonly IModeller<IAstModifier, ModifierModel> _modifier = MFor<IAstModifier, ModifierModel>();
  private readonly IModeller<IAstTypeRef, OpResultModel> _result = MFor<IAstTypeRef, OpResultModel>();
  private readonly IModeller<IAstSelection, OpSelectionModel> _selection = MFor<IAstSelection, OpSelectionModel>();
  private readonly IModeller<IAstVariable, OpVariableModel> _variable = MFor<IAstVariable, OpVariableModel>();

  public OperationModellerTests()
  {
    IModellerRepository modellers = A.Of<IModellerRepository>();
    ModellerForReturns(modellers, _directive);
    ModellerForReturns(modellers, _fragment);
    ModellerForReturns(modellers, _modifier);
    ModellerForReturns(modellers, _result);
    ModellerForReturns(modellers, _selection);
    ModellerForReturns(modellers, _variable);
    Modeller = new OperationModeller(modellers);
  }

  protected override IModeller<IAstSchemaOperation, OperationModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidOperation_ReturnsExpectedOperationModel(
    string name, string category, string contents, string[] aliases)
  {
    // Arrange
    IAstSchemaOperation ast = A.Named<IAstSchemaOperation>(name, contents);
    ast.Category.Returns(category);
    ast.Aliases.Returns(aliases);
    ast.Variables.Returns([]);
    ast.Directives.Returns([]);
    ast.Fragments.Returns([]);
    ast.Domain.Returns((IAstTypeRef?)null);
    ast.Modifiers.Returns([]);
    ast.Selections.Returns([]);

    ToModelsReturns(_directive, []);
    ToModelsReturns(_fragment, []);
    ToModelsReturns(_modifier, []);
    ToModelsReturns(_variable, []);

    // Act
    OperationModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Category.ShouldBe(category),
        r => r.Description.ShouldBe(contents),
        r => r.Aliases.ShouldBeEquivalentTo(aliases)
      );
  }
}

public class OpArgumentModellerTests
  : ModellerClassTestBase<IAstArg, OpArgumentModel>
{
  public OpArgumentModellerTests()
    => Modeller = new OpArgumentModeller();

  protected override IModeller<IAstArg, OpArgumentModel> Modeller { get; }

  [Fact]
  public void ToModel_WithValidArg_ReturnsExpectedArgumentModel()
  {
    // Arrange
    IAstArg ast = A.Error<IAstArg>();

    // Act
    OpArgumentModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldBeOfType<OpArgumentModel>();
  }
}

public class OpDirectiveModellerTests
  : ModellerClassTestBase<IAstDirective, OpDirectiveModel>
{
  public OpDirectiveModellerTests()
    => Modeller = new OpDirectiveModeller();

  protected override IModeller<IAstDirective, OpDirectiveModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidDirective_ReturnsExpectedDirectiveModel(string name)
  {
    // Arrange
    IAstDirective ast = A.Identified<IAstDirective>(name);

    // Act
    OpDirectiveModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name)
      );
  }
}

public class OpFragmentModellerTests
  : ModellerClassTestBase<IAstFragment, OpFragmentModel>
{
  public OpFragmentModellerTests()
    => Modeller = new OpFragmentModeller();

  protected override IModeller<IAstFragment, OpFragmentModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidFragment_ReturnsExpectedFragmentModel(string name, string typeName)
  {
    // Arrange
    IAstFragment ast = A.Identified<IAstFragment>(name);
    ast.OnType.Returns(typeName);

    // Act
    OpFragmentModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Type.Name.ShouldBe(typeName)
      );
  }
}

public class OpResultModellerTests
  : ModellerClassTestBase<IAstTypeRef, OpResultModel>
{
  public OpResultModellerTests()
    => Modeller = new OpResultModeller();

  protected override IModeller<IAstTypeRef, OpResultModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidTypeRef_ReturnsExpectedResultModel(string typeName)
  {
    // Arrange
    IAstTypeRef ast = A.Named<IAstTypeRef>(typeName);

    // Act
    OpResultModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Domain.Name.ShouldBe(typeName)
      );
  }
}

public class OpSelectionModellerTests
  : ModellerClassTestBase<IAstSelection, OpSelectionModel>
{
  private readonly IModeller<IAstArg, OpArgumentModel> _argument = MFor<IAstArg, OpArgumentModel>();
  private readonly IModeller<IAstDirective, OpDirectiveModel> _directive = MFor<IAstDirective, OpDirectiveModel>();
  private readonly IModeller<IAstModifier, ModifierModel> _modifier = MFor<IAstModifier, ModifierModel>();

  public OpSelectionModellerTests()
  {
    IModellerRepository modellers = A.Of<IModellerRepository>();
    ModellerForReturns(modellers, _argument);
    ModellerForReturns(modellers, _directive);
    ModellerForReturns(modellers, _modifier);
    Modeller = new OpSelectionModeller(modellers);
  }

  protected override IModeller<IAstSelection, OpSelectionModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidField_ReturnsExpectedFieldSelectionModel(string name, string alias)
  {
    // Arrange
    IAstField ast = A.Identified<IAstField>(name);
    ast.FieldAlias.Returns(alias);
    ast.Arg.Returns((IAstArg?)null);
    ast.Directives.Returns([]);
    ast.Modifiers.Returns([]);

    ToModelsReturns(_directive, []);
    ToModelsReturns(_modifier, []);

    // Act
    OpSelectionModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<OpFieldSelectionModel>()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Alias.ShouldBe(alias)
      );
  }

  [Theory, RepeatData]
  public void ToModel_WithValidInline_ReturnsExpectedInlineSelectionModel(string typeName)
  {
    // Arrange
    IAstInline ast = A.Error<IAstInline>();
    ast.OnType.Returns(typeName);
    ast.Directives.Returns([]);
    ast.Modifiers.Returns([]);

    ToModelsReturns(_directive, []);
    ToModelsReturns(_modifier, []);

    // Act
    OpSelectionModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<OpInlineSelectionModel>()
      .ShouldSatisfyAllConditions(
        r => r.Type.ShouldNotBeNull(),
        r => r.Type!.Name.ShouldBe(typeName)
      );
  }

  [Theory, RepeatData]
  public void ToModel_WithValidSpread_ReturnsExpectedSpreadSelectionModel(string name)
  {
    // Arrange
    IAstSpread ast = A.Identified<IAstSpread>(name);
    ast.Directives.Returns([]);
    ast.Modifiers.Returns([]);

    ToModelsReturns(_directive, []);
    ToModelsReturns(_modifier, []);

    // Act
    OpSelectionModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<OpSpreadSelectionModel>()
      .ShouldSatisfyAllConditions(
        r => r.Fragment.ShouldBe(name)
      );
  }
}

public class OpVariableModellerTests
  : ModellerClassTestBase<IAstVariable, OpVariableModel>
{
  public OpVariableModellerTests()
    => Modeller = new OpVariableModeller();

  protected override IModeller<IAstVariable, OpVariableModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidVariable_ReturnsExpectedVariableModel(string name, string typeName)
  {
    // Arrange
    IAstVariable ast = A.Identified<IAstVariable>(name);
    ast.Type.Returns(typeName);

    // Act
    OpVariableModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Type.ShouldNotBeNull(),
        r => r.Type!.Name.ShouldBe(typeName)
      );
  }
}
