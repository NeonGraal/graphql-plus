//HintName: test_field-descr+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Dual;

internal class testFieldDescrDualDecoder
{
  public string Field { get; set; }
}

internal static class test_field_descr_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_descr_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldDescrDualObject>(r => new testFieldDescrDualDecoder(r));
}
