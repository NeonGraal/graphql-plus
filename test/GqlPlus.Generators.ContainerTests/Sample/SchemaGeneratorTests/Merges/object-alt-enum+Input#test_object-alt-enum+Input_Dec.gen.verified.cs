//HintName: test_object-alt-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object-alt-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_enum_Input;

internal class testObjAltEnumInpDecoder
{

  internal static testObjAltEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_alt_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_alt_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjAltEnumInpObject>(testObjAltEnumInpDecoder.Factory);
}
