//HintName: test_constraint-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

internal class testCnstEnumOutpEncoder : IEncoder<ItestCnstEnumOutpObject>
{
  public Structured Encode(ItestCnstEnumOutpObject input)
    => Structured.Empty();
}

internal class testRefCnstEnumOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstEnumOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumOutpEncoder : IEncoder<testEnumCnstEnumOutp>
{
  public Structured Encode(testEnumCnstEnumOutp input)
    => new(input.ToString(), "_EnumCnstEnumOutp");
}

internal static class test_constraint_enum_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_enum_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstEnumOutpObject>(_ => new testCnstEnumOutpEncoder())
      .AddEncoder<testEnumCnstEnumOutp>(_ => new testEnumCnstEnumOutpEncoder());
}
