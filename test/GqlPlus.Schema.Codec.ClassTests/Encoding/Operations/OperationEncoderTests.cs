namespace GqlPlus.Encoding;

public class OperationEncoderTests
  : EncoderClassTestBase<OperationModel>
{
  private readonly IEncoder<OpDirectiveModel> _directives;
  private readonly IEncoder<OpFragmentModel> _fragments;
  private readonly IEncoder<ModifierModel> _modifiers;
  private readonly IEncoder<OpResultModel> _result;
  private readonly IEncoder<OpSelectionModel> _selections;
  private readonly IEncoder<OpVariableModel> _variables;

  public OperationEncoderTests()
  {
    _directives = RFor<OpDirectiveModel>();
    _fragments = RFor<OpFragmentModel>();
    _modifiers = RFor<ModifierModel>();
    _result = RFor<OpResultModel>();
    _selections = RFor<OpSelectionModel>();
    _variables = RFor<OpVariableModel>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderForReturns(_directives);
    encoders.EncoderForReturns(_fragments);
    encoders.EncoderForReturns(_modifiers);
    encoders.EncoderForReturns(_result);
    encoders.EncoderForReturns(_selections);
    encoders.EncoderForReturns(_variables);
    Encoder = new OperationEncoder(encoders);
  }

  protected override IEncoder<OperationModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidOperationModel_ReturnsStructured(string name, string category)
  {
    // Act
    EncodeAndCheck(new(name, category, string.Empty), [
        "[_Operation]:category=" + category,
        "[_Operation]:name=" + name,
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithDirectives_IncludesDirectives(string name, string category, string directiveName)
  {
    // Arrange
    OpDirectiveModel dirModel = new(directiveName, "");
    _directives.Encode(dirModel).Returns(directiveName.Encode("_OpDirective"));

    // Act
    EncodeAndCheck(new(name, category, string.Empty) {
      Directives = [dirModel]
    }, [
        "[_Operation]:category=" + category,
        "[_Operation]:directives.0=[_OpDirective]" + directiveName,
        "[_Operation]:name=" + name,
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithFragments_IncludesFragments(string name, string category, string fragName)
  {
    // Arrange
    TypeRefModel<TypeKindModel> typeRef = fragName.TypeRef(TypeKindModel.Output);
    OpFragmentModel fragModel = new(fragName, typeRef, "");
    _fragments.Encode(fragModel).Returns(fragName.Encode("_OpFragment"));

    // Act
    EncodeAndCheck(new(name, category, string.Empty) {
      Fragments = new Map<OpFragmentModel> { [fragName] = fragModel }
    }, [
        "[_Operation]:category=" + category,
        "[_Operation]:fragments[_Map(_Fragments)]:[_Name]" + fragName + "=[_OpFragment]" + fragName,
        "[_Operation]:name=" + name,
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithVariables_IncludesVariables(string name, string category, string varName)
  {
    // Arrange
    OpVariableModel varModel = new(varName, null, null, "");
    _variables.Encode(varModel).Returns(varName.Encode("_OpVariable"));

    // Act
    EncodeAndCheck(new(name, category, string.Empty) {
      Variables = new Map<OpVariableModel> { [varName] = varModel }
    }, [
        "[_Operation]:category=" + category,
        "[_Operation]:name=" + name,
        "[_Operation]:variables[_Map(_Variables)]:[_Name]" + varName + "=[_OpVariable]" + varName,
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithModifiers_IncludesModifiers(string name, string category)
  {
    // Arrange
    ModifierModel modifier = new(ModifierKindModel.List);
    _modifiers.Encode(modifier).Returns("List".Encode());

    // Act
    EncodeAndCheck(new(name, category, string.Empty) {
      Modifiers = [modifier]
    }, [
        "[_Operation]:category=" + category,
        "[_Operation]:modifiers.0=List",
        "[_Operation]:name=" + name,
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithResult_IncludesResult(string name, string category, string resultName)
  {
    // Arrange
    OpResultModel resultModel = new(resultName.TypeRef(TypeKindModel.Output));
    _result.Encode(resultModel).Returns(resultName.Encode("_OpResult"));

    // Act
    EncodeAndCheck(new(name, category, string.Empty) {
      Result = resultModel
    }, [
        "[_Operation]:category=" + category,
        "[_Operation]:name=" + name,
        "[_Operation]:result=[_OpResult]" + resultName,
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithSelections_IncludesSelections(string name, string category, string fieldName)
  {
    // Arrange
    OpFieldSelectionModel selectionModel = new(fieldName, "");
    _selections.Encode(selectionModel).Returns(fieldName.Encode("_OpFieldSelection"));

    // Act
    EncodeAndCheck(new(name, category, string.Empty) {
      Selections = new Map<OpSelectionModel[]> { [""] = [selectionModel] }
    }, [
        "[_Operation]:category=" + category,
        "[_Operation]:name=" + name,
        "[_Operation]:selections[_Map(_Selections)][_Selections].0=[_OpFieldSelection]" + fieldName,
      ]);
  }
}
