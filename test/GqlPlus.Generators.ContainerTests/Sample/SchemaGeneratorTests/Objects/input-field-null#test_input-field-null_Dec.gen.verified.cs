//HintName: test_input-field-null_Dec.gen.cs
// Generated from {CurrentDirectory}input-field-null.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_null;

internal class testInpFieldNullDecoder : IDecoder<ItestInpFieldNullObject>
{
  public ItestFldInpFieldNull? Field { get; set; }

  public IMessages Decode(IValue input, out ItestInpFieldNullObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInpFieldNullDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldInpFieldNullDecoder : IDecoder<ItestFldInpFieldNullObject>
{

  public IMessages Decode(IValue input, out ItestFldInpFieldNullObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldInpFieldNullDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_input_field_nullDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_input_field_nullDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInpFieldNullObject>(testInpFieldNullDecoder.Factory)
      .AddDecoder<ItestFldInpFieldNullObject>(testFldInpFieldNullDecoder.Factory);
}
