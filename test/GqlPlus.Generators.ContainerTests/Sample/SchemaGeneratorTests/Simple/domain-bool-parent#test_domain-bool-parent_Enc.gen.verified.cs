//HintName: test_domain-bool-parent_Enc.gen.cs
// Generated from {CurrentDirectory}domain-bool-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_bool_parent;

internal class testDmnBoolPrntEncoder : IEncoder<ItestDmnBoolPrnt>
{
  public Structured Encode(ItestDmnBoolPrnt input)
    => input.Value!.Encode();

  internal static testDmnBoolPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnBoolPrntEncoder : IEncoder<ItestPrntDmnBoolPrnt>
{
  public Structured Encode(ItestPrntDmnBoolPrnt input)
    => input.Value!.Encode();

  internal static testPrntDmnBoolPrntEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_bool_parentEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_bool_parentEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnBoolPrnt>(testDmnBoolPrntEncoder.Factory)
      .AddEncoder<ItestPrntDmnBoolPrnt>(testPrntDmnBoolPrntEncoder.Factory);
}
