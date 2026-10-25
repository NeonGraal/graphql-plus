//HintName: test_constraint-parent-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

internal class testCnstPrntEnumDualEncoder : IEncoder<ItestCnstPrntEnumDualObject>
{
  public IGqlpValue Encode(ItestCnstPrntEnumDualObject input)
    => new GqlpUnit();

  internal static testCnstPrntEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstPrntEnumDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstPrntEnumDualObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefCnstPrntEnumDualObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstPrntEnumDualEncoder : IEncoder<testEnumCnstPrntEnumDual>
{
  public IGqlpValue Encode(testEnumCnstPrntEnumDual input)
    => input.EncodeEnum("EnumCnstPrntEnumDual");

  internal static testEnumCnstPrntEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstPrntEnumDualEncoder : IEncoder<testParentCnstPrntEnumDual>
{
  public IGqlpValue Encode(testParentCnstPrntEnumDual input)
    => input.EncodeEnum("ParentCnstPrntEnumDual");

  internal static testParentCnstPrntEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_parent_enum_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_enum_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstPrntEnumDualObject>(testCnstPrntEnumDualEncoder.Factory)
      .AddEncoder<testEnumCnstPrntEnumDual>(testEnumCnstPrntEnumDualEncoder.Factory)
      .AddEncoder<testParentCnstPrntEnumDual>(testParentCnstPrntEnumDualEncoder.Factory);
}
