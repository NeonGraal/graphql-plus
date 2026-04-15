//HintName: test_generic-parent-string-dom+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Dual;

internal class testGnrcPrntStrDomDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntStrDomDualObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual>> _itestFieldGnrcPrntStrDomDual = encoders.EncoderFor<ItestFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual>>();
  public Structured Encode(ItestGnrcPrntStrDomDualObject input)
    => _itestFieldGnrcPrntStrDomDual.Encode(input);
}

internal class testFieldGnrcPrntStrDomDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntStrDomDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntStrDomDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomGnrcPrntStrDomDualEncoder : IEncoder<ItestDomGnrcPrntStrDomDual>
{
  public Structured Encode(ItestDomGnrcPrntStrDomDual input)
    => new(input.Value);
}

internal static class test_generic_parent_string_dom_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_string_dom_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntStrDomDualObject>(r => new testGnrcPrntStrDomDualEncoder(r))
      .AddEncoder<ItestDomGnrcPrntStrDomDual>(_ => new testDomGnrcPrntStrDomDualEncoder());
}
