//HintName: test_generic-field-param+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

internal class testGnrcFieldParamInpDecoder
{
  public ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; set; }

  internal static testGnrcFieldParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcFieldParamInpDecoder<TRef>
{
}

internal class testAltGnrcFieldParamInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcFieldParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_field_param_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_field_param_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcFieldParamInpObject>(testGnrcFieldParamInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcFieldParamInpObject>(testAltGnrcFieldParamInpDecoder.Factory);
}
