//HintName: test_domain-bool-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-bool-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_bool_parent;

internal class testDmnBoolPrntDecoder : IDecoder<ItestDmnBoolPrnt>
{

  public IMessages Decode(IValue input, out ItestDmnBoolPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnBoolPrntDecoder : IDecoder<ItestPrntDmnBoolPrnt>
{

  public IMessages Decode(IValue input, out ItestPrntDmnBoolPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnBoolPrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_bool_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_bool_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnBoolPrnt>(testDmnBoolPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnBoolPrnt>(testPrntDmnBoolPrntDecoder.Factory);
}
