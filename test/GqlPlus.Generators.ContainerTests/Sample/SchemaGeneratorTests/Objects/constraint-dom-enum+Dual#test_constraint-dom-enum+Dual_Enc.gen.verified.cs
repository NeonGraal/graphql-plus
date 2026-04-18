//HintName: test_constraint-dom-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

internal class testCnstDomEnumDualEncoder : IEncoder<ItestCnstDomEnumDualObject>
{
  public Structured Encode(ItestCnstDomEnumDualObject input)
    => Structured.Empty();

  internal static testCnstDomEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstDomEnumDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstDomEnumDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstDomEnumDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstDomEnumDualEncoder : IEncoder<testEnumCnstDomEnumDual>
{
  public Structured Encode(testEnumCnstDomEnumDual input)
    => new(input.ToString(), "_EnumCnstDomEnumDual");

  internal static testEnumCnstDomEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testJustCnstDomEnumDualEncoder : IEncoder<ItestJustCnstDomEnumDual>
{
  public Structured Encode(ItestJustCnstDomEnumDual input)
    => new(input.ToString(), "testEnumCnstDomEnumDual");

  internal static testJustCnstDomEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_dom_enum_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_dom_enum_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstDomEnumDualObject>(testCnstDomEnumDualEncoder.Factory)
      .AddEncoder<testEnumCnstDomEnumDual>(testEnumCnstDomEnumDualEncoder.Factory)
      .AddEncoder<ItestJustCnstDomEnumDual>(testJustCnstDomEnumDualEncoder.Factory);
}
