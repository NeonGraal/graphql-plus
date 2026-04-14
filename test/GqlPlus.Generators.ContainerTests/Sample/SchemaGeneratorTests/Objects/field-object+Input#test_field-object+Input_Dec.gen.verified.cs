//HintName: test_field-object+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-object+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Input;

internal class testFieldObjInpDecoder
{
  public ItestFldFieldObjInp Field { get; set; }
}

internal class testFldFieldObjInpDecoder
{
  public decimal Field { get; set; }
}

internal static class test_field_object_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_object_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldObjInpObject>(r => new testFieldObjInpDecoder(r))
      .AddDecoder<ItestFldFieldObjInpObject>(r => new testFldFieldObjInpDecoder(r));
}
