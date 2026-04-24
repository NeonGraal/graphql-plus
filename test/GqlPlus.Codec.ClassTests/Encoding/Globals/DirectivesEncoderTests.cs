namespace GqlPlus.Encoding.Globals;

public class DirectivesEncoderTests
  : EncoderClassTestBase<DirectivesModel>
{
  public DirectivesEncoderTests()
  {
    _directive = RFor<DirectiveModel>();
    _baseType = RFor<BaseTypeModel>();
    IEncoderRepository repo = A.Of<IEncoderRepository>();
    repo.EncoderFor<DirectiveModel>().Returns(_directive);
    repo.EncoderFor<BaseTypeModel>().Returns(_baseType);
    Encoder = new DirectivesEncoder(repo);
  }

  private readonly IEncoder<DirectiveModel> _directive;
  private readonly IEncoder<BaseTypeModel> _baseType;

  protected override IEncoder<DirectivesModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidDirectivesModel_ReturnsStructured(string name)
  {
    // Arrange
    BaseTypeModel type = new TypeInputModel(name, string.Empty);
    DirectiveModel directive = new(name, string.Empty);
    _baseType.Encode(type).Returns(name.Encode("Input"));
    _directive.Encode(directive).Returns(name.Encode("Directive"));

    // Act
    EncodeAndCheck(new() {
      Type = type,
      And = directive
    }, TagAll("_Directives",
        ":directive=[Directive]" + name,
        ":type=[Input]" + name));
  }
}
