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

  [Theory, RepeatData]
  public void ToModel_WithVariables_MapsVariablesByName(string name, string var1Name, string var2Name)
  {
    if (var1Name == var2Name) {
      return; // skip degenerate case: duplicate names would cause a map key collision
    }

    // Arrange
    IAstSchemaOperation ast = A.Named<IAstSchemaOperation>(name, "");
    ast.Category.Returns("");
    ast.Aliases.Returns([]);
    IAstVariable var1Ast = A.Identified<IAstVariable>(var1Name);
    IAstVariable var2Ast = A.Identified<IAstVariable>(var2Name);
    ast.Variables.Returns(new IAstVariable[] { var1Ast, var2Ast });
    ast.Directives.Returns([]);
    ast.Fragments.Returns([]);
    ast.Domain.Returns((IAstTypeRef?)null);
    ast.Modifiers.Returns([]);
    ast.Selections.Returns([]);

    OpVariableModel varModel1 = new(var1Name, null, null, "");
    OpVariableModel varModel2 = new(var2Name, null, null, "");
    ToModelsReturns(_variable, [varModel1, varModel2]);
    ToModelsReturns(_directive, []);
    ToModelsReturns(_fragment, []);
    ToModelsReturns(_modifier, []);

    // Act
    OperationModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.Variables.ShouldSatisfyAllConditions(
      v => v.ShouldContainKeyAndValue(var1Name, varModel1),
      v => v.ShouldContainKeyAndValue(var2Name, varModel2)
    );
  }

  [Theory, RepeatData]
  public void ToModel_WithFragments_MapsFragmentsByName(string name, string fragName, string typeName)
  {
    // Arrange
    IAstSchemaOperation ast = A.Named<IAstSchemaOperation>(name, "");
    ast.Category.Returns("");
    ast.Aliases.Returns([]);
    ast.Variables.Returns([]);
    ast.Directives.Returns([]);
    IAstFragment fragAst = A.Identified<IAstFragment>(fragName);
    fragAst.Selections.Returns([]);
    ast.Fragments.Returns([fragAst]);
    ast.Domain.Returns((IAstTypeRef?)null);
    ast.Modifiers.Returns([]);
    ast.Selections.Returns([]);

    OpFragmentModel fragModel = new(fragName, typeName.TypeRef(TypeKindModel.Output), "");
    ToModelsReturns(_fragment, [fragModel]);
    ToModelsReturns(_directive, []);
    ToModelsReturns(_modifier, []);
    ToModelsReturns(_variable, []);

    // Act
    OperationModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.Fragments.ShouldContainKeyAndValue(fragName, fragModel);
  }

  [Theory, RepeatData]
  public void ToModel_WithAllSelectionTypesAtTwoLevels_ReturnsNestedSelections(
    string name, string fieldName, string typeName, string spreadName,
    string subFieldName, string subSpreadName)
  {
    // Arrange
    IAstSchemaOperation ast = A.Named<IAstSchemaOperation>(name, "");
    ast.Category.Returns("");
    ast.Aliases.Returns([]);
    ast.Variables.Returns([]);
    ast.Directives.Returns([]);
    ast.Fragments.Returns([]);
    ast.Domain.Returns((IAstTypeRef?)null);
    ast.Modifiers.Returns([]);

    // Level 0: field (with sub-selections), inline, spread – all three types
    IAstField field1Ast = A.Identified<IAstField>(fieldName);
    IAstInline inline1Ast = A.Error<IAstInline>();
    inline1Ast.OnType.Returns(typeName);
    IAstSpread spread1Ast = A.Identified<IAstSpread>(spreadName);
    ast.Selections.Returns(new IAstSelection[] { field1Ast, inline1Ast, spread1Ast });

    // Level 1 sub-selections from field1: subField, subInline, subSpread – all three types
    IAstField subFieldAst = A.Identified<IAstField>(subFieldName);
    IAstInline subInlineAst = A.Error<IAstInline>();
    subInlineAst.OnType.Returns(typeName);
    IAstSpread subSpreadAst = A.Identified<IAstSpread>(subSpreadName);
    field1Ast.Selections.Returns(new IAstSelection[] { subFieldAst, subInlineAst, subSpreadAst });
    subFieldAst.Selections.Returns([]);
    subInlineAst.Selections.Returns([]);
    inline1Ast.Selections.Returns([]);

    OpFieldSelectionModel field1Model = new(fieldName, "");
    OpInlineSelectionModel inline1Model = new(null, "");
    OpSpreadSelectionModel spread1Model = new(spreadName, "");
    OpFieldSelectionModel subFieldModel = new(subFieldName, "");
    OpInlineSelectionModel subInlineModel = new(null, "");
    OpSpreadSelectionModel subSpreadModel = new(subSpreadName, "");

    ToModelReturns(_selection, field1Ast, field1Model);
    ToModelReturns(_selection, inline1Ast, inline1Model);
    ToModelReturns(_selection, spread1Ast, spread1Model);
    ToModelReturns(_selection, subFieldAst, subFieldModel);
    ToModelReturns(_selection, subInlineAst, subInlineModel);
    ToModelReturns(_selection, subSpreadAst, subSpreadModel);
    ToModelsReturns(_directive, []);
    ToModelsReturns(_fragment, []);
    ToModelsReturns(_modifier, []);
    ToModelsReturns(_variable, []);

    // Act
    OperationModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.Selections.ShouldSatisfyAllConditions(
      s => s[""].ShouldBe(new OpSelectionModel[] { field1Model, inline1Model, spread1Model }),
      s => s[".1"].ShouldBe(new OpSelectionModel[] { subFieldModel, subInlineModel, subSpreadModel })
    );
  }

  [Theory, RepeatData]
  public void ToModel_WithInlineContainingSubSelections_ReturnsInlineTwoLevelSelections(
    string name, string typeName, string spreadName)
  {
    // Arrange
    IAstSchemaOperation ast = A.Named<IAstSchemaOperation>(name, "");
    ast.Category.Returns("");
    ast.Aliases.Returns([]);
    ast.Variables.Returns([]);
    ast.Directives.Returns([]);
    ast.Fragments.Returns([]);
    ast.Domain.Returns((IAstTypeRef?)null);
    ast.Modifiers.Returns([]);

    // Level 0: a single inline selection (IAstInline also implements IAstSelections)
    IAstInline inlineAst = A.Error<IAstInline>();
    inlineAst.OnType.Returns(typeName);
    ast.Selections.Returns(new IAstSelection[] { inlineAst });

    // Level 1 sub-selection from inline: a spread
    IAstSpread spreadAst = A.Identified<IAstSpread>(spreadName);
    inlineAst.Selections.Returns(new IAstSelection[] { spreadAst });

    OpInlineSelectionModel inlineModel = new(null, "");
    OpSpreadSelectionModel spreadModel = new(spreadName, "");

    ToModelReturns(_selection, inlineAst, inlineModel);
    ToModelReturns(_selection, spreadAst, spreadModel);
    ToModelsReturns(_directive, []);
    ToModelsReturns(_fragment, []);
    ToModelsReturns(_modifier, []);
    ToModelsReturns(_variable, []);

    // Act
    OperationModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.Selections.ShouldSatisfyAllConditions(
      s => s[""].ShouldBe(new OpSelectionModel[] { inlineModel }),
      s => s[".1"].ShouldBe(new OpSelectionModel[] { spreadModel })
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
