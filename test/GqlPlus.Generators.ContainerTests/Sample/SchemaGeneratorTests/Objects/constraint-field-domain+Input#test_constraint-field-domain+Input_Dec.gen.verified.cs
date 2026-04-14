//HintName: test_constraint-field-domain+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Input;

internal class testCnstFieldDmnInpDecoder
{
}

internal class testRefCnstFieldDmnInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testDomCnstFieldDmnInpDecoder
{
}

internal static class test_constraint_field_domain_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_field_domain_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstFieldDmnInpObject>(_ => new testCnstFieldDmnInpDecoder())
      .AddDecoder<ItestDomCnstFieldDmnInp>(_ => new testDomCnstFieldDmnInpDecoder());
}
