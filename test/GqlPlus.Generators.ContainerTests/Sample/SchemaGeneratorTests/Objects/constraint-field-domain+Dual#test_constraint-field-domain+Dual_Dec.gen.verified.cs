//HintName: test_constraint-field-domain+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Dual;

internal class testCnstFieldDmnDualDecoder
{
}

internal class testRefCnstFieldDmnDualDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testDomCnstFieldDmnDualDecoder
{
}

internal static class test_constraint_field_domain_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_field_domain_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstFieldDmnDualObject>(_ => new testCnstFieldDmnDualDecoder())
      .AddDecoder<ItestDomCnstFieldDmnDual>(_ => new testDomCnstFieldDmnDualDecoder());
}
