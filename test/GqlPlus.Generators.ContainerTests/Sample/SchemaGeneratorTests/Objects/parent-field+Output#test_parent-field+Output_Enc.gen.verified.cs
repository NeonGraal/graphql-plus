//HintName: test_parent-field+Output_Enc.gen.cs
// Generated from {CurrentDirectory}parent-field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

internal class testPrntFieldOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntFieldOutpObject>
{
  private readonly IEncoder<ItestRefPrntFieldOutpObject> _itestRefPrntFieldOutp = encoders.EncoderFor<ItestRefPrntFieldOutpObject>();
  public Structured Encode(ItestPrntFieldOutpObject input)
    => _itestRefPrntFieldOutp.Encode(input)
      .Add("field", input.Field);
}

internal class testRefPrntFieldOutpEncoder : IEncoder<ItestRefPrntFieldOutpObject>
{
  public Structured Encode(ItestRefPrntFieldOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

internal static class test_parent_field_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_parent_field_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntFieldOutpObject>(r => new testPrntFieldOutpEncoder(r))
      .AddEncoder<ItestRefPrntFieldOutpObject>(_ => new testRefPrntFieldOutpEncoder());
}
