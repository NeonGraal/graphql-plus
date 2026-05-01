//HintName: test_constraint-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

internal class testCnstEnumInpEncoder : IEncoder<ItestCnstEnumInpObject>
{
  public Structured Encode(ItestCnstEnumInpObject input)
    => Structured.Empty();

  internal static testCnstEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstEnumInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstEnumInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumInpEncoder : IEncoder<testEnumCnstEnumInp>
{
  public Structured Encode(testEnumCnstEnumInp input)
    => input.EncodeEnum("EnumCnstEnumInp");

  internal static testEnumCnstEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_enum_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_enum_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstEnumInpObject>(testCnstEnumInpEncoder.Factory)
      .AddEncoder<testEnumCnstEnumInp>(testEnumCnstEnumInpEncoder.Factory);
}
