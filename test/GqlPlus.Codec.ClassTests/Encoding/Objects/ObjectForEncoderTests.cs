using System.Diagnostics;

namespace GqlPlus.Encoding.Objects;

public class ObjectForEncoderTests
  : EncoderClassTestBase<ObjectForModel<TypeParamModel>>
{
  private readonly IEncoder<TypeParamModel> _typeParam;

  public ObjectForEncoderTests()
  {
    _typeParam = RFor<TypeParamModel>();

    Encoder = new ObjectForEncoder<TypeParamModel>(_typeParam);
  }

  protected override IEncoder<ObjectForModel<TypeParamModel>> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string input, string name)
  {
    EncodeReturnsMap(_typeParam, "_TypeParam", input);

    EncodeAndCheck(new(new(input, "", default!), name),
      TagAll("_ObjectFor(_TypeParam)",
        ":object=" + name,
        $":value=[_TypeParam]" + input.QuotedIdentifier()));
  }
}
