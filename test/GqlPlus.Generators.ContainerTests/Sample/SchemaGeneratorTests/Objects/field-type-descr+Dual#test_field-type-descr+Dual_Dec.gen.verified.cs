//HintName: test_field-type-descr+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Dual;

internal class testFieldTypeDescrDualDecoder
{
  public decimal Field { get; set; }
}

internal static class test_field_type_descr_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_type_descr_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldTypeDescrDualObject>(_ => new testFieldTypeDescrDualDecoder());
}
