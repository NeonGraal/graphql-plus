//HintName: test_descr-double_Enc.gen.cs
// Generated from {CurrentDirectory}descr-double.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_descr_double;

internal class testDescrDblEncoder : IEncoder<ItestDescrDblObject>
{
  public Structured Encode(ItestDescrDblObject input)
    => Structured.Empty();
}

internal static class test_descr_doubleEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_descr_doubleEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDescrDblObject>(_ => new testDescrDblEncoder());
}
