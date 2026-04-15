//HintName: test_field-type-descr+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Dual;

internal class testFieldTypeDescrDualEncoder : IEncoder<ItestFieldTypeDescrDualObject>
{
  public Structured Encode(ItestFieldTypeDescrDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal static class test_field_type_descr_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_type_descr_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldTypeDescrDualObject>(_ => new testFieldTypeDescrDualEncoder());
}
