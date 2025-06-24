namespace GqlPlus.Encoding;

public class SpecialTypeEncoderTests
  : EncoderClassTestBase<SpecialTypeModel>
{
  protected override IEncoder<SpecialTypeModel> Encoder => _special;

  private readonly SpecialTypeEncoder _special = new();

  [Theory, RepeatData]
  public void Encode_WithValidSpecialTypeModel_ReturnsStructured(string name, string content)
    => EncodeAndCheck(new(name, content), SpecialTypeExpected(name, content));

  private static string[] SpecialTypeExpected(string name, string content)
    => ["!_SpecialType",
        $"description: '{content}'",
        "name: " + name,
        "typeKind: !_TypeKind Special"
        ];

  [Fact]
  public void ForType_WithSpecialTypeModel_ReturnsTrue()
  {
    SpecialTypeModel model = new("Test", "This is a test");

    _special.ForType(model).ShouldBeTrue();
  }

  [Fact]
  public void ForType_WithOtherTypeModel_ReturnsFalse()
  {
    TypeEnumModel model = new("Test", "This is a test");

    _special.ForType(model).ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void TypeEncode_WithSpecialTypeModel_ReturnsExpected(string name, string content)
  {
    SpecialTypeModel model = new(name, content);

    Structured result = _special.TypeEncode(model);

    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe(SpecialTypeExpected(name, content));
  }
}
