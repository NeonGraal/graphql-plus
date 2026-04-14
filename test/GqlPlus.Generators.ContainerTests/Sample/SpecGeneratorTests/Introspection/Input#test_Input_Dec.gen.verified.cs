//HintName: test_Input_Dec.gen.cs
// Generated from {CurrentDirectory}Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Input;

internal class test_InputFieldDecoder
{
}

internal class test_InputFieldTypeDecoder
{
  public GqlpValue? DefaultValue { get; set; }
}

internal static class test_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_InputFieldObject>(_ => new test_InputFieldDecoder())
      .AddDecoder<Itest_InputFieldTypeObject>(r => new test_InputFieldTypeDecoder(r));
}
