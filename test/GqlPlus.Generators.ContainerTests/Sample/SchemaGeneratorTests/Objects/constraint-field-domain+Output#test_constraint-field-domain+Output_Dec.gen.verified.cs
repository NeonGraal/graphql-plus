//HintName: test_constraint-field-domain+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Output;

internal class testDomCnstFieldDmnOutpDecoder
{
}

internal static class test_constraint_field_domain_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_field_domain_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDomCnstFieldDmnOutp>(_ => new testDomCnstFieldDmnOutpDecoder());
}
