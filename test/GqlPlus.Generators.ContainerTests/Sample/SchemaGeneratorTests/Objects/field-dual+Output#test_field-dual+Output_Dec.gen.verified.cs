//HintName: test_field-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Output;

internal class testFldFieldDualOutpDecoder : IDecoder<ItestFldFieldDualOutpObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFldFieldDualOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldFieldDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_dual_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_dual_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFldFieldDualOutpObject>(testFldFieldDualOutpDecoder.Factory);
}
