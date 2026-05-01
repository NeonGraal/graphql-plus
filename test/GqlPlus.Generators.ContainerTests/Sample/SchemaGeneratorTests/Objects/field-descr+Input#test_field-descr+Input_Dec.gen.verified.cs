//HintName: test_field-descr+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Input;

internal class testFieldDescrInpDecoder : IDecoder<ItestFieldDescrInpObject>
{
  public string? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldDescrInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_descr_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_descr_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldDescrInpObject>(testFieldDescrInpDecoder.Factory);
}
