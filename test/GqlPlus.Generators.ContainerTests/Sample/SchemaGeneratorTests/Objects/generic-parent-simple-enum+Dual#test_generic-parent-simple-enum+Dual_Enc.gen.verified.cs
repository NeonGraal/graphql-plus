//HintName: test_generic-parent-simple-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Dual;

internal class testGnrcPrntSmplEnumDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntSmplEnumDualObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>> _itestFieldGnrcPrntSmplEnumDual = encoders.EncoderFor<ItestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>>();
  public Structured Encode(ItestGnrcPrntSmplEnumDualObject input)
    => _itestFieldGnrcPrntSmplEnumDual.Encode(input);

  internal static testGnrcPrntSmplEnumDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntSmplEnumDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntSmplEnumDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntSmplEnumDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntSmplEnumDualEncoder : IEncoder<testEnumGnrcPrntSmplEnumDual>
{
  public Structured Encode(testEnumGnrcPrntSmplEnumDual input)
    => new(input.ToString(), "_EnumGnrcPrntSmplEnumDual");

  internal static testEnumGnrcPrntSmplEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_simple_enum_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_simple_enum_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntSmplEnumDualObject>(testGnrcPrntSmplEnumDualEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntSmplEnumDual>(testEnumGnrcPrntSmplEnumDualEncoder.Factory);
}
