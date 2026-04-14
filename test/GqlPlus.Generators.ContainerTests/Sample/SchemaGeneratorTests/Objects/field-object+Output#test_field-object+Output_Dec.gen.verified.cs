//HintName: test_field-object+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-object+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Output;

internal class testFieldObjOutpDecoder
{
  public ItestFldFieldObjOutp Field { get; set; }
}

internal class testFldFieldObjOutpDecoder
{
  public decimal Field { get; set; }
}

internal static class test_field_object_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_object_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldObjOutpObject>(r => new testFieldObjOutpDecoder(r))
      .AddDecoder<ItestFldFieldObjOutpObject>(r => new testFldFieldObjOutpDecoder(r));
}
