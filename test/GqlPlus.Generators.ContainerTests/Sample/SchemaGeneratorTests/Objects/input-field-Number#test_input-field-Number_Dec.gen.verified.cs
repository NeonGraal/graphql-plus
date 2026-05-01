//HintName: test_input-field-Number_Dec.gen.cs
// Generated from {CurrentDirectory}input-field-Number.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Number;

internal class testInpFieldNmbrDecoder : IDecoder<ItestInpFieldNmbrObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestInpFieldNmbrObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInpFieldNmbrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_input_field_NumberDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_input_field_NumberDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInpFieldNmbrObject>(testInpFieldNmbrDecoder.Factory);
}
