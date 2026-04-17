//HintName: test_constraint-enum-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

internal class testCnstEnumPrntDualEncoder : IEncoder<ItestCnstEnumPrntDualObject>
{
  public Structured Encode(ItestCnstEnumPrntDualObject input)
    => Structured.Empty();

  internal static testCnstEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstEnumPrntDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumPrntDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstEnumPrntDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumPrntDualEncoder : IEncoder<testEnumCnstEnumPrntDual>
{
  public Structured Encode(testEnumCnstEnumPrntDual input)
    => new(input.ToString(), "_EnumCnstEnumPrntDual");

  internal static testEnumCnstEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstEnumPrntDualEncoder : IEncoder<testParentCnstEnumPrntDual>
{
  public Structured Encode(testParentCnstEnumPrntDual input)
    => new(input.ToString(), "_ParentCnstEnumPrntDual");

  internal static testParentCnstEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_enum_parent_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_enum_parent_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstEnumPrntDualObject>(testCnstEnumPrntDualEncoder.Factory)
      .AddEncoder<testEnumCnstEnumPrntDual>(testEnumCnstEnumPrntDualEncoder.Factory)
      .AddEncoder<testParentCnstEnumPrntDual>(testParentCnstEnumPrntDualEncoder.Factory);
}
