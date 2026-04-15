//HintName: test_Result_Enc.gen.cs
// Generated from {CurrentDirectory}Result.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Result;

internal class test_OpSpreadEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OpSpreadObject>
{
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  private readonly IEncoder<Itest_OpDirective> _itest_OpDirective = encoders.EncoderFor<Itest_OpDirective>();
  public Structured Encode(Itest_OpSpreadObject input)
    => Structured.Empty()
      .AddEncoded("fragment", input.Fragment, _itest_Identifier)
      .AddList("directives", input.Directives, _itest_OpDirective);
}

internal static class test_ResultEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_ResultEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_OpSpreadObject>(r => new test_OpSpreadEncoder(r));
}
