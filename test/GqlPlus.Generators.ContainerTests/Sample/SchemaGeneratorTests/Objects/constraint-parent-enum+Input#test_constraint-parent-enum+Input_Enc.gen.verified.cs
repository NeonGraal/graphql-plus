//HintName: test_constraint-parent-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

internal class testCnstPrntEnumInpEncoder : IEncoder<ItestCnstPrntEnumInpObject>
{
  public Structured Encode(ItestCnstPrntEnumInpObject input)
    => Structured.Empty();

  internal static testCnstPrntEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstPrntEnumInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstPrntEnumInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstPrntEnumInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstPrntEnumInpEncoder : IEncoder<testEnumCnstPrntEnumInp>
{
  public Structured Encode(testEnumCnstPrntEnumInp input)
    => input.EncodeEnum("EnumCnstPrntEnumInp");

  internal static testEnumCnstPrntEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstPrntEnumInpEncoder : IEncoder<testParentCnstPrntEnumInp>
{
  public Structured Encode(testParentCnstPrntEnumInp input)
    => input.EncodeEnum("ParentCnstPrntEnumInp");

  internal static testParentCnstPrntEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_parent_enum_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_enum_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstPrntEnumInpObject>(testCnstPrntEnumInpEncoder.Factory)
      .AddEncoder<testEnumCnstPrntEnumInp>(testEnumCnstPrntEnumInpEncoder.Factory)
      .AddEncoder<testParentCnstPrntEnumInp>(testParentCnstPrntEnumInpEncoder.Factory);
}
