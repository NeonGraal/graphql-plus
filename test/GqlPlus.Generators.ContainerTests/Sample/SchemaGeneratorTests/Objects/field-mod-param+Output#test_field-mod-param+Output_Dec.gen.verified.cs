//HintName: test_field-mod-param+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

internal class testFieldModParamOutpDecoder<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamOutp> Field { get; set; }
}

internal class testFldFieldModParamOutpDecoder
{
  public decimal Field { get; set; }
}

internal static class test_field_mod_param_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_mod_param_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFldFieldModParamOutpObject>(r => new testFldFieldModParamOutpDecoder(r));
}
