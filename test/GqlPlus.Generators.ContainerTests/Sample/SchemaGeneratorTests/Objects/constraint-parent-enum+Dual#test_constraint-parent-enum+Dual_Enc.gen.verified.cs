//HintName: test_constraint-parent-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

internal class testCnstPrntEnumDualEncoder : IEncoder<ItestCnstPrntEnumDualObject>
{
  public Structured Encode(ItestCnstPrntEnumDualObject input)
    => Structured.Empty();
}

internal class testRefCnstPrntEnumDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstPrntEnumDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstPrntEnumDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstPrntEnumDualEncoder : IEncoder<testEnumCnstPrntEnumDual>
{
  public Structured Encode(testEnumCnstPrntEnumDual input)
    => new(input.ToString(), "_EnumCnstPrntEnumDual");
}

internal class testParentCnstPrntEnumDualEncoder : IEncoder<testParentCnstPrntEnumDual>
{
  public Structured Encode(testParentCnstPrntEnumDual input)
    => new(input.ToString(), "_ParentCnstPrntEnumDual");
}

internal static class test_constraint_parent_enum_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_enum_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstPrntEnumDualObject>(_ => new testCnstPrntEnumDualEncoder())
      .AddEncoder<testEnumCnstPrntEnumDual>(_ => new testEnumCnstPrntEnumDualEncoder())
      .AddEncoder<testParentCnstPrntEnumDual>(_ => new testParentCnstPrntEnumDualEncoder());
}
