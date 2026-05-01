//HintName: test_constraint-alt-domain+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Output;

internal class testDomCnstAltDmnOutpDecoder : IDecoder<ItestDomCnstAltDmnOutp>
{

  public IMessages Decode(IValue input, out ItestDomCnstAltDmnOutp? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomCnstAltDmnOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_alt_domain_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_alt_domain_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDomCnstAltDmnOutp>(testDomCnstAltDmnOutpDecoder.Factory);
}
