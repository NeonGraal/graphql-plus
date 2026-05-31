using GqlPlus.Ast.Operation;

namespace GqlPlus.Modelling;

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
    ast.Variables.Returns([var1Ast, var2Ast]);
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
    ast.Selections.Returns([field1Ast, inline1Ast, spread1Ast]);

    // Level 1 sub-selections from field1: subField, subInline, subSpread – all three types
    IAstField subFieldAst = A.Identified<IAstField>(subFieldName);
    IAstInline subInlineAst = A.Error<IAstInline>();
    subInlineAst.OnType.Returns(typeName);
    IAstSpread subSpreadAst = A.Identified<IAstSpread>(subSpreadName);
    field1Ast.Selections.Returns([subFieldAst, subInlineAst, subSpreadAst]);
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
      s => s[""].ShouldBe([field1Model, inline1Model, spread1Model]),
      s => s[".1"].ShouldBe([subFieldModel, subInlineModel, subSpreadModel])
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
    ast.Selections.Returns([inlineAst]);

    // Level 1 sub-selection from inline: a spread
    IAstSpread spreadAst = A.Identified<IAstSpread>(spreadName);
    inlineAst.Selections.Returns([spreadAst]);

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
      s => s[""].ShouldBe([inlineModel]),
      s => s[".1"].ShouldBe([spreadModel])
    );
  }

  [Theory, RepeatData]
  public void ToModel_WithDomain_SetsResult(string name, string domainName)
  {
    // Arrange
    IAstTypeRef domain = A.Named<IAstTypeRef>(domainName);
    IAstSchemaOperation ast = A.Named<IAstSchemaOperation>(name, "");
    ast.Category.Returns("");
    ast.Aliases.Returns([]);
    ast.Variables.Returns([]);
    ast.Directives.Returns([]);
    ast.Fragments.Returns([]);
    ast.Domain.Returns(domain);
    ast.Modifiers.Returns([]);
    ast.Selections.Returns([]);

    OpResultModel resultModel = new(domainName.TypeRef(TypeKindModel.Output));
    ToModelReturns(_result, domain, resultModel);
    ToModelsReturns(_directive, []);
    ToModelsReturns(_fragment, []);
    ToModelsReturns(_modifier, []);
    ToModelsReturns(_variable, []);

    // Act
    OperationModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.Result.ShouldBe(resultModel);
  }

  [Theory, RepeatData]
  public void ToModel_WithNullDomain_ResultIsNull(string name)
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
    ast.Selections.Returns([]);

    ToModelsReturns(_directive, []);
    ToModelsReturns(_fragment, []);
    ToModelsReturns(_modifier, []);
    ToModelsReturns(_variable, []);

    // Act
    OperationModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.Result.ShouldBeNull();
  }

  [Theory, RepeatData]
  public void ToModel_WithWhitespaceDomainName_ResultIsNull(string name)
  {
    // Arrange
    IAstTypeRef domain = A.Named<IAstTypeRef>(" ");
    IAstSchemaOperation ast = A.Named<IAstSchemaOperation>(name, "");
    ast.Category.Returns("");
    ast.Aliases.Returns([]);
    ast.Variables.Returns([]);
    ast.Directives.Returns([]);
    ast.Fragments.Returns([]);
    ast.Domain.Returns(domain);
    ast.Modifiers.Returns([]);
    ast.Selections.Returns([]);

    ToModelsReturns(_directive, []);
    ToModelsReturns(_fragment, []);
    ToModelsReturns(_modifier, []);
    ToModelsReturns(_variable, []);

    // Act
    OperationModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.Result.ShouldBeNull();
  }

  [Theory, RepeatData]
  public void ToModel_WithDirectives_MapsDirectives(string name, string directiveName)
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
    ast.Selections.Returns([]);

    OpDirectiveModel directiveModel = new(directiveName, "");
    ToModelsReturns(_directive, [directiveModel]);
    ToModelsReturns(_fragment, []);
    ToModelsReturns(_modifier, []);
    ToModelsReturns(_variable, []);

    // Act
    OperationModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.Directives.ShouldBe([directiveModel]);
  }

  [Theory, RepeatData]
  public void ToModel_WithModifiers_MapsModifiers(string name)
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
    ast.Selections.Returns([]);

    ModifierModel[] modifiers = [new(ModifierKindModel.List)];
    ToModelsReturns(_directive, []);
    ToModelsReturns(_fragment, []);
    ToModelsReturns(_modifier, modifiers);
    ToModelsReturns(_variable, []);

    // Act
    OperationModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.Modifiers.ShouldBe(modifiers);
  }

  [Theory, RepeatData]
  public void ToModel_WithFragmentSelections_MapsSelectionsUnderFragmentKey(
    string name, string fragName, string fieldName)
  {
    // Arrange
    IAstSchemaOperation ast = A.Named<IAstSchemaOperation>(name, "");
    ast.Category.Returns("");
    ast.Aliases.Returns([]);
    ast.Variables.Returns([]);
    ast.Directives.Returns([]);
    ast.Domain.Returns((IAstTypeRef?)null);
    ast.Modifiers.Returns([]);
    ast.Selections.Returns([]);

    IAstFragment fragAst = A.Identified<IAstFragment>(fragName);
    IAstField fieldAst = A.Identified<IAstField>(fieldName);
    fieldAst.Selections.Returns([]);
    fragAst.Selections.Returns([fieldAst]);
    ast.Fragments.Returns([fragAst]);

    OpFieldSelectionModel fieldModel = new(fieldName, "");
    OpFragmentModel fragModel = new(fragName, fragName.TypeRef(TypeKindModel.Output), "");
    ToModelsReturns(_fragment, [fragModel]);
    ToModelReturns(_selection, fieldAst, fieldModel);
    ToModelsReturns(_directive, []);
    ToModelsReturns(_modifier, []);
    ToModelsReturns(_variable, []);

    // Act
    OperationModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.Selections.ShouldSatisfyAllConditions(
      s => s.ShouldContainKey(fragName),
      s => s[fragName].ShouldBe([fieldModel])
    );
  }
}
