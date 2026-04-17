//HintName: test_generic-field-param+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

internal class testGnrcFieldParamDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamDualObject>
{
  private readonly IEncoder<ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>> _itestRefGnrcFieldParamDual = encoders.EncoderFor<ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>>();
  public Structured Encode(ItestGnrcFieldParamDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamDual);

  internal static testGnrcFieldParamDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldParamDualEncoder<TRef> : IEncoder<ItestRefGnrcFieldParamDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldParamDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcFieldParamDualEncoder : IEncoder<ItestAltGnrcFieldParamDualObject>
{
  public Structured Encode(ItestAltGnrcFieldParamDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

  internal static testAltGnrcFieldParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_field_param_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_field_param_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcFieldParamDualObject>(testGnrcFieldParamDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldParamDualObject>(testAltGnrcFieldParamDualEncoder.Factory);
}
