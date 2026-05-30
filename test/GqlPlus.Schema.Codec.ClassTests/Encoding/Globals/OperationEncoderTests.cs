namespace GqlPlus.Encoding.Globals;

public class OperationsEncoderTests
  : EncoderClassTestBase<OperationsModel>
{
  private readonly IEncoder<OperationModel> _operation;
  private readonly IEncoder<BaseTypeModel> _type;

  public OperationsEncoderTests()
  {
    _operation = RFor<OperationModel>();
    _type = RFor<BaseTypeModel>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderForReturns(_operation);
    encoders.EncoderForReturns(_type);
    Encoder = new OperationsEncoder(encoders);
  }

  protected override IEncoder<OperationsModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidOperationsModel_ReturnsStructured(string name, string opName)
  {
    // Arrange
    BaseTypeModel type = new TypeInputModel(name, string.Empty);
    OperationModel operation = new(opName, "query", string.Empty);
    _type.Encode(type).Returns(name.Encode("Input"));
    _operation.Encode(operation).Returns(opName.Encode("Operation"));

    // Act
    EncodeAndCheck(new() {
      Type = type,
      And = operation
    }, TagAll("_Operations",
        ":operation=[Operation]" + opName,
        ":type=[Input]" + name));
  }
}

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
}

public class OpDirectiveEncoderTests
  : EncoderClassTestBase<OpDirectiveModel>
{
  public OpDirectiveEncoderTests()
    => Encoder = new OpDirectiveEncoder();

  protected override IEncoder<OpDirectiveModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidDirectiveModel_ReturnsStructured(string name)
  {
    // Act
    EncodeAndCheck(new(name, string.Empty), [
        "[_OpDirective]:name=" + name,
      ]);
  }
}

public class OpFragmentEncoderTests
  : EncoderClassTestBase<OpFragmentModel>
{
  private readonly IEncoder<OpDirectiveModel> _directives;
  private readonly IEncoder<TypeRefModel<TypeKindModel>> _type;

  public OpFragmentEncoderTests()
  {
    _directives = RFor<OpDirectiveModel>();
    _type = RFor<TypeRefModel<TypeKindModel>>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderForReturns(_directives);
    encoders.EncoderForReturns(_type);
    Encoder = new OpFragmentEncoder(encoders);
  }

  protected override IEncoder<OpFragmentModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidFragmentModel_ReturnsStructured(string name, string typeName)
  {
    // Arrange
    TypeRefModel<TypeKindModel> typeRef = typeName.TypeRef(TypeKindModel.Output);
    _type.Encode(typeRef).Returns(typeName.Encode("TypeRef"));

    // Act
    EncodeAndCheck(new(name, typeRef, string.Empty), [
        "[_OpFragment]:name=" + name,
        "[_OpFragment]:type=[TypeRef]" + typeName,
      ]);
  }
}

public class OpResultEncoderTests
  : EncoderClassTestBase<OpResultModel>
{
  private readonly IEncoder<TypeRefModel<TypeKindModel>> _domain;

  public OpResultEncoderTests()
  {
    _domain = RFor<TypeRefModel<TypeKindModel>>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderForReturns(_domain);
    Encoder = new OpResultEncoder(encoders);
  }

  protected override IEncoder<OpResultModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidResultModel_ReturnsStructured(string typeName)
  {
    // Arrange
    TypeRefModel<TypeKindModel> domainRef = typeName.TypeRef(TypeKindModel.Output);
    _domain.Encode(domainRef).Returns(typeName.Encode("TypeRef"));

    // Act
    EncodeAndCheck(new(domainRef), [
        "[_OpResult]:domain=[TypeRef]" + typeName,
      ]);
  }
}

public class OpSelectionEncoderTests
  : EncoderClassTestBase<OpSelectionModel>
{
  public OpSelectionEncoderTests()
  {
    _argument = RFor<OpArgumentModel>();
    _directive = RFor<DirectiveModel>();
    _modifier = RFor<ModifierModel>();
    _type = RFor<TypeRefModel<TypeKindModel>>();
    IEncoderRepository repo = A.Of<IEncoderRepository>();
    repo.EncoderForReturns(_argument);
    repo.EncoderForReturns(_directive);
    repo.EncoderForReturns(_modifier);
    repo.EncoderForReturns(_type);
    Encoder = new OpSelectionEncoder(repo);
  }

  private readonly IEncoder<OpArgumentModel> _argument;
  private readonly IEncoder<DirectiveModel> _directive;
  private readonly IEncoder<ModifierModel> _modifier;
  private readonly IEncoder<TypeRefModel<TypeKindModel>> _type;

  protected override IEncoder<OpSelectionModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithFieldSelectionModel_ReturnsStructured(string field)
  {
    EncodeAndCheck(new OpFieldSelectionModel(field, string.Empty), [
        $"[_OpFieldSelection]:name={field}",
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithInlineSelectionModel_ReturnsStructured(string type)
  {
    EncodeAndCheck(new OpInlineSelectionModel(new TypeRefModel<TypeKindModel>(TypeKindModel.Output, type, ""), string.Empty),
      ["=[_OpInlineSelection]"]);
  }

  [Theory, RepeatData]
  public void Encode_WithSpreadSelectionModel_ReturnsStructured(string fragment)
  {
    EncodeAndCheck(new OpSpreadSelectionModel(fragment, string.Empty),
      [$"[_OpSpreadSelection]:fragment={fragment}"]);
  }
}

public class OpVariableEncoderTests
  : EncoderClassTestBase<OpVariableModel>
{
  private readonly IEncoder<OpDirectiveModel> _directives;
  private readonly IEncoder<ConstantModel> _constant;
  private readonly IEncoder<TypeRefModel<TypeKindModel>> _type;

  public OpVariableEncoderTests()
  {
    _directives = RFor<OpDirectiveModel>();
    _constant = RFor<ConstantModel>();
    _type = RFor<TypeRefModel<TypeKindModel>>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderForReturns(_directives);
    encoders.EncoderForReturns(_constant);
    encoders.EncoderForReturns(_type);
    Encoder = new OpVariableEncoder(encoders);
  }

  protected override IEncoder<OpVariableModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidVariableModel_ReturnsStructured(string name, string typeName)
  {
    // Arrange
    TypeRefModel<TypeKindModel> typeRef = typeName.TypeRef(TypeKindModel.Input);
    _type.Encode(typeRef).Returns(typeName.Encode("TypeRef"));

    // Act
    EncodeAndCheck(new(name, typeRef, null, string.Empty), [
        "[_OpVariable]:name=" + name,
        "[_OpVariable]:type=[TypeRef]" + typeName,
      ]);
  }
}
