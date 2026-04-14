//HintName: test_Output_Dec.gen.cs
// Generated from {CurrentDirectory}Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Output;

internal class test_OutputFieldDecoder
{
}

internal class test_OutputFieldTypeDecoder
{
  public Itest_InputFieldType? Parameter { get; set; }
}

internal static class test_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_OutputFieldObject>(_ => new test_OutputFieldDecoder())
      .AddDecoder<Itest_OutputFieldTypeObject>(r => new test_OutputFieldTypeDecoder(r));
}
