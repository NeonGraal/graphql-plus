//HintName: test_domain-number-range_Dec.gen.cs
// Generated from {CurrentDirectory}domain-number-range.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_range;

internal class testDmnNmbrRangeDecoder : IDecoder<ItestDmnNmbrRange>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrRange? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrRangeDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_number_rangeDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_number_rangeDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnNmbrRange>(testDmnNmbrRangeDecoder.Factory);
}
