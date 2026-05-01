//HintName: test_field+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Input;

internal class testFieldInpDecoder : IDecoder<ItestFieldInpObject>
{
  public string? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldInpObject>(testFieldInpDecoder.Factory);
}
