//HintName: test_constraint-parent-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

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

internal static class test_constraint_parent_enum_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_enum_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumCnstPrntEnumInp>(_ => new testEnumCnstPrntEnumInpEncoder())
      .AddEncoder<testParentCnstPrntEnumInp>(_ => new testParentCnstPrntEnumInpEncoder());
}
