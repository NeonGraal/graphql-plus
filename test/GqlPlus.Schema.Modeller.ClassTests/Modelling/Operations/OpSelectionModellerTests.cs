using GqlPlus.Ast.Operation;

namespace GqlPlus.Modelling;

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

  [Theory, RepeatData]
  public void ToModel_WithFieldAndArgument_SetsArgument(string name)
  {
    // Arrange
    IAstField ast = A.Identified<IAstField>(name);
    IAstArg argAst = A.Of<IAstArg>();
    ast.FieldAlias.Returns((string?)null);
    ast.Arg.Returns(argAst);
    ast.Directives.Returns([]);
    ast.Modifiers.Returns([]);

    OpArgumentModel argModel = new();
    TryModelReturns(_argument, argAst, argModel);
    ToModelsReturns(_directive, []);
    ToModelsReturns(_modifier, []);

    // Act
    OpSelectionModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<OpFieldSelectionModel>()
      .Argument.ShouldBe(argModel);
  }

  [Theory, RepeatData]
  public void ToModel_WithFieldAndNullArgument_ArgumentIsNull(string name)
  {
    // Arrange
    IAstField ast = A.Identified<IAstField>(name);
    ast.FieldAlias.Returns((string?)null);
    ast.Arg.Returns((IAstArg?)null);
    ast.Directives.Returns([]);
    ast.Modifiers.Returns([]);

    ToModelsReturns(_directive, []);
    ToModelsReturns(_modifier, []);

    // Act
    OpSelectionModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<OpFieldSelectionModel>()
      .Argument.ShouldBeNull();
  }

  [Theory, RepeatData]
  public void ToModel_WithDirectivesOnField_SetsDirectives(string name, string dirName)
  {
    // Arrange
    IAstField ast = A.Identified<IAstField>(name);
    ast.FieldAlias.Returns((string?)null);
    ast.Arg.Returns((IAstArg?)null);
    ast.Directives.Returns([]);
    ast.Modifiers.Returns([]);

    OpDirectiveModel dirModel = new(dirName, "");
    ToModelsReturns(_directive, [dirModel]);
    ToModelsReturns(_modifier, []);

    // Act
    OpSelectionModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.Directives.ShouldBe([dirModel]);
  }

  [Theory, RepeatData]
  public void ToModel_WithModifiersOnField_SetsModifiers(string name)
  {
    // Arrange
    IAstField ast = A.Identified<IAstField>(name);
    ast.FieldAlias.Returns((string?)null);
    ast.Arg.Returns((IAstArg?)null);
    ast.Directives.Returns([]);
    ast.Modifiers.Returns([]);

    ModifierModel[] modifiers = [new(ModifierKindModel.List)];
    ToModelsReturns(_directive, []);
    ToModelsReturns(_modifier, modifiers);

    // Act
    OpSelectionModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.Modifiers.ShouldBe(modifiers);
  }

  [Fact]
  public void ToModel_WithUnsupportedSelection_ThrowsNotSupportedException()
  {
    // Arrange
    IAstSelection ast = A.Of<IAstSelection>();

    // Act & Assert
    Should.Throw<NotSupportedException>(() => Modeller.ToModel(ast, TypeKinds));
  }
}
