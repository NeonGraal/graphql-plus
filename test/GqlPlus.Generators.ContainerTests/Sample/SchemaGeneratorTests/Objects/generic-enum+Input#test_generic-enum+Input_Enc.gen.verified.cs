//HintName: test_generic-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

internal class testGnrcEnumInpEncoder : IEncoder<ItestGnrcEnumInpObject>
{
  public Structured Encode(ItestGnrcEnumInpObject input)
    => Structured.Empty();

  internal static testGnrcEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcEnumInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcEnumInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefGnrcEnumInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcEnumInpEncoder : IEncoder<testEnumGnrcEnumInp>
{
  public Structured Encode(testEnumGnrcEnumInp input)
    => input.EncodeEnum("EnumGnrcEnumInp");

  internal static testEnumGnrcEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_enum_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_enum_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcEnumInpObject>(testGnrcEnumInpEncoder.Factory)
      .AddEncoder<testEnumGnrcEnumInp>(testEnumGnrcEnumInpEncoder.Factory);
}
