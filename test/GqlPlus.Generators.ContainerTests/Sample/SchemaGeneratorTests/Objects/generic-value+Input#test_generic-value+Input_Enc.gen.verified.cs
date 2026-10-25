//HintName: test_generic-value+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

internal class testGnrcValueInpEncoder : IEncoder<ItestGnrcValueInpObject>
{
  public IGqlpValue Encode(ItestGnrcValueInpObject input)
    => new GqlpUnit();

  internal static testGnrcValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcValueInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcValueInpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefGnrcValueInpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcValueInpEncoder : IEncoder<testEnumGnrcValueInp>
{
  public IGqlpValue Encode(testEnumGnrcValueInp input)
    => input.EncodeEnum("EnumGnrcValueInp");

  internal static testEnumGnrcValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_value_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_value_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcValueInpObject>(testGnrcValueInpEncoder.Factory)
      .AddEncoder<testEnumGnrcValueInp>(testEnumGnrcValueInpEncoder.Factory);
}
