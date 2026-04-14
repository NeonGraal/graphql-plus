//HintName: test_object-field+Output_Dec.gen.cs
// Generated from {CurrentDirectory}object-field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Output;

internal class testObjFieldOutpDecoder
{
  public ItestFldObjFieldOutp Field { get; set; }
}

internal class testFldObjFieldOutpDecoder
{
}

internal static class test_object_field_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldOutpObject>(r => new testObjFieldOutpDecoder(r))
      .AddDecoder<ItestFldObjFieldOutpObject>(_ => new testFldObjFieldOutpDecoder());
}
