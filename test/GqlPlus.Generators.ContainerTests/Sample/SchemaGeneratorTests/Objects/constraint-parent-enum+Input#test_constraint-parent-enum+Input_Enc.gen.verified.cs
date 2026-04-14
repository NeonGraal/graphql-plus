//HintName: test_constraint-parent-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

internal class testCnstPrntEnumInpEncoder : IEncoder<ItestCnstPrntEnumInpObject>
{
  public Structured Encode(ItestCnstPrntEnumInpObject input)
    => Structured.Empty();
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
    => new(input.ToString(), "_EnumCnstPrntEnumInp");
}

internal class testParentCnstPrntEnumInpEncoder : IEncoder<testParentCnstPrntEnumInp>
{
  public Structured Encode(testParentCnstPrntEnumInp input)
    => new(input.ToString(), "_ParentCnstPrntEnumInp");
}
