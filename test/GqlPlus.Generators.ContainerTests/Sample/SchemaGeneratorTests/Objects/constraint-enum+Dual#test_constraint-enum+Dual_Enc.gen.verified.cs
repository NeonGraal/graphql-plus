//HintName: test_constraint-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

internal class testCnstEnumDualEncoder : IEncoder<ItestCnstEnumDualObject>
{
  public Structured Encode(ItestCnstEnumDualObject input)
    => Structured.Empty();
}

internal class testRefCnstEnumDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstEnumDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumDualEncoder : IEncoder<testEnumCnstEnumDual>
{
  public Structured Encode(testEnumCnstEnumDual input)
    => new(input.ToString(), "_EnumCnstEnumDual");
}

internal static class test_constraint_enum_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_enum_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstEnumDualObject>(_ => new testCnstEnumDualEncoder())
      .AddEncoder<testEnumCnstEnumDual>(_ => new testEnumCnstEnumDualEncoder());
}
