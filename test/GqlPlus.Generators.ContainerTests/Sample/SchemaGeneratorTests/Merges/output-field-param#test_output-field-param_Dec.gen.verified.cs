//HintName: test_output-field-param_Dec.gen.cs
// Generated from {CurrentDirectory}output-field-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_field_param;

internal class testOutpFieldParam1Decoder : NullDecoder<ItestOutpFieldParam1Object>
{

  internal static testOutpFieldParam1Decoder Factory(IDecoderRepository _) => new();
}

internal class testOutpFieldParam2Decoder : NullDecoder<ItestOutpFieldParam2Object>
{

  internal static testOutpFieldParam2Decoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpFieldParamDecoder : NullDecoder<ItestFldOutpFieldParamObject>
{

  internal static testFldOutpFieldParamDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_output_field_paramDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_field_paramDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestOutpFieldParam1Object>(testOutpFieldParam1Decoder.Factory)
      .AddDecoder<ItestOutpFieldParam2Object>(testOutpFieldParam2Decoder.Factory)
      .AddDecoder<ItestFldOutpFieldParamObject>(testFldOutpFieldParamDecoder.Factory);
}
