//HintName: test_generic-value+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

internal class testGnrcValueDualEncoder : IEncoder<ItestGnrcValueDualObject>
{
  public Structured Encode(ItestGnrcValueDualObject input)
    => Structured.Empty();

  internal static testGnrcValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcValueDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcValueDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefGnrcValueDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcValueDualEncoder : IEncoder<testEnumGnrcValueDual>
{
  public Structured Encode(testEnumGnrcValueDual input)
    => new(input.ToString(), "_EnumGnrcValueDual");

  internal static testEnumGnrcValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_value_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_value_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcValueDualObject>(testGnrcValueDualEncoder.Factory)
      .AddEncoder<testEnumGnrcValueDual>(testEnumGnrcValueDualEncoder.Factory);
}
