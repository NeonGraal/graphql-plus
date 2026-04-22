//HintName: test_Selections_Enc.gen.cs
// Generated from {CurrentDirectory}Selections.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Selections;

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

  internal static test_OpSpreadEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_SelectionsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_SelectionsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_OpSpreadObject>(test_OpSpreadEncoder.Factory);
}
