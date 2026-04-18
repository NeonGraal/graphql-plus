//HintName: test_field-mod-param+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Input;

internal class testFieldModParamInpDecoder<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamInp> Field { get; set; }
}

internal class testFldFieldModParamInpDecoder
{
  public decimal Field { get; set; }

  internal static testFldFieldModParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_mod_param_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_mod_param_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFldFieldModParamInpObject>(testFldFieldModParamInpDecoder.Factory);
}
