//HintName: test_Full_Enc.gen.cs
// Generated from {CurrentDirectory}Full.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Full;

internal class test_RequestEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_RequestObject>
{
  private readonly IEncoder<Itest_Identifier> _itest_Identifier = encoders.EncoderFor<Itest_Identifier>();
  private readonly IEncoder<Itest_Operation> _itest_Operation = encoders.EncoderFor<Itest_Operation>();
  private readonly IEncoder<Itest_Any> _itest_Any = encoders.EncoderFor<Itest_Any>();
  public Structured Encode(Itest_RequestObject input)
    => Structured.Empty()
      .AddEncoded("category", input.Category, _itest_Identifier)
      .AddEncoded("operation", input.Operation, _itest_Identifier)
      .AddEncoded("definition", input.Definition, _itest_Operation)
      .AddEncoded("parameters", input.Parameters, _itest_Any);
}

internal class test_IdentifierEncoder : IEncoder<Itest_Identifier>
{
  public Structured Encode(Itest_Identifier input)
    => new(input.Value);
}
