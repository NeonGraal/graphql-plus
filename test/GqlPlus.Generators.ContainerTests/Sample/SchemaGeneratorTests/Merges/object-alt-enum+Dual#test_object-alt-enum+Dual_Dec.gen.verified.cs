//HintName: test_object-alt-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}object-alt-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_enum_Dual;

internal class testObjAltEnumDualDecoder
{
}

internal static class test_object_alt_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_alt_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjAltEnumDualObject>(_ => new testObjAltEnumDualDecoder());
}
