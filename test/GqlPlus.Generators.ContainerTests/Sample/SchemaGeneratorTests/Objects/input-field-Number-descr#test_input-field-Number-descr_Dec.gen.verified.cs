//HintName: test_input-field-Number-descr_Dec.gen.cs
// Generated from {CurrentDirectory}input-field-Number-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Number_descr;

internal class testInpFieldNmbrDescrDecoder : IDecoder<ItestInpFieldNmbrDescrObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestInpFieldNmbrDescrObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInpFieldNmbrDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_input_field_Number_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_input_field_Number_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInpFieldNmbrDescrObject>(testInpFieldNmbrDescrDecoder.Factory);
}
