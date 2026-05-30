namespace GqlPlus.Encoding;

public class OpSelectionEncoderTests
  : EncoderClassTestBase<OpSelectionModel>
{
  public OpSelectionEncoderTests()
  {
    _argument = RFor<OpArgumentModel>();
    _directive = RFor<OpDirectiveModel>();
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
  private readonly IEncoder<OpDirectiveModel> _directive;
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

  [Theory, RepeatData]
  public void Encode_WithFieldAlias_IncludesAlias(string field, string alias)
  {
    EncodeAndCheck(new OpFieldSelectionModel(field, string.Empty) { Alias = alias }, [
        "[_OpFieldSelection]:alias=" + alias,
        "[_OpFieldSelection]:name=" + field,
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithFieldArgument_IncludesArgument(string field, string argValue)
  {
    // Arrange
    OpArgumentModel argModel = new();
    _argument.Encode(argModel).Returns(argValue.Encode("_OpArgument"));

    EncodeAndCheck(new OpFieldSelectionModel(field, string.Empty) { Argument = argModel }, [
        "[_OpFieldSelection]:argument=[_OpArgument]" + argValue,
        "[_OpFieldSelection]:name=" + field,
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithFieldDirectives_IncludesDirectives(string field, string dirName)
  {
    // Arrange
    OpDirectiveModel dirModel = new(dirName, "");
    _directive.Encode(dirModel).Returns(dirName.Encode("_OpDirective"));

    EncodeAndCheck(new OpFieldSelectionModel(field, string.Empty) { Directives = [dirModel] }, [
        "[_OpFieldSelection]:directives.0=[_OpDirective]" + dirName,
        "[_OpFieldSelection]:name=" + field,
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithFieldModifiers_IncludesModifiers(string field)
  {
    // Arrange
    ModifierModel modifier = new(ModifierKindModel.List);
    _modifier.Encode(modifier).Returns("List".Encode());

    EncodeAndCheck(new OpFieldSelectionModel(field, string.Empty) { Modifiers = [modifier] }, [
        "[_OpFieldSelection]:modifiers.0=List",
        "[_OpFieldSelection]:name=" + field,
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithSpreadDirectives_IncludesDirectives(string fragment, string dirName)
  {
    // Arrange
    OpDirectiveModel dirModel = new(dirName, "");
    _directive.Encode(dirModel).Returns(dirName.Encode("_OpDirective"));

    EncodeAndCheck(new OpSpreadSelectionModel(fragment, string.Empty) { Directives = [dirModel] }, [
        "[_OpSpreadSelection]:directives.0=[_OpDirective]" + dirName,
        "[_OpSpreadSelection]:fragment=" + fragment,
      ]);
  }
}
