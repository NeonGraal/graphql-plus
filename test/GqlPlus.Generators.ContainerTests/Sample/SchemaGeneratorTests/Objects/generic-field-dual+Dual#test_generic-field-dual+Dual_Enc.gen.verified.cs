//HintName: test_generic-field-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

internal class testGnrcFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualDualObject>
{
  private readonly IEncoder<ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual>> _itestRefGnrcFieldDualDual = encoders.EncoderFor<ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual>>();
  public Structured Encode(ItestGnrcFieldDualDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldDualDual);

  internal static testGnrcFieldDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldDualDualEncoder<TRef> : IEncoder<ItestRefGnrcFieldDualDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldDualDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcFieldDualDualEncoder : IEncoder<ItestAltGnrcFieldDualDualObject>
{
  public Structured Encode(ItestAltGnrcFieldDualDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

  internal static testAltGnrcFieldDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_field_dual_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_field_dual_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcFieldDualDualObject>(testGnrcFieldDualDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldDualDualObject>(testAltGnrcFieldDualDualEncoder.Factory);
}
