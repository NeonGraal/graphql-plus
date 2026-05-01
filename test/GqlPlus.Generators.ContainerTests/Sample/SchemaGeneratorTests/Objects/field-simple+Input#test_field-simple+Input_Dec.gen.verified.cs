//HintName: test_field-simple+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Input;

internal class testFieldSmplInpDecoder : IDecoder<ItestFieldSmplInpObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldSmplInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldSmplInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_simple_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_simple_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldSmplInpObject>(testFieldSmplInpDecoder.Factory);
}
