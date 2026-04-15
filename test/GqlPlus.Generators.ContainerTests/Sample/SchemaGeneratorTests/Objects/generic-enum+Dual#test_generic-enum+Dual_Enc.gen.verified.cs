//HintName: test_generic-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

internal class testGnrcEnumDualEncoder : IEncoder<ItestGnrcEnumDualObject>
{
  public Structured Encode(ItestGnrcEnumDualObject input)
    => Structured.Empty();
}

internal class testRefGnrcEnumDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcEnumDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefGnrcEnumDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcEnumDualEncoder : IEncoder<testEnumGnrcEnumDual>
{
  public Structured Encode(testEnumGnrcEnumDual input)
    => new(input.ToString(), "_EnumGnrcEnumDual");
}

internal static class test_generic_enum_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_enum_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcEnumDualObject>(_ => new testGnrcEnumDualEncoder())
      .AddEncoder<testEnumGnrcEnumDual>(_ => new testEnumGnrcEnumDualEncoder());
}
