//HintName: test_constraint-parent-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

internal class testCnstPrntEnumOutpEncoder : IEncoder<ItestCnstPrntEnumOutpObject>
{
  public Structured Encode(ItestCnstPrntEnumOutpObject input)
    => Structured.Empty();
}

internal class testRefCnstPrntEnumOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstPrntEnumOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstPrntEnumOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstPrntEnumOutpEncoder : IEncoder<testEnumCnstPrntEnumOutp>
{
  public Structured Encode(testEnumCnstPrntEnumOutp input)
    => new(input.ToString(), "_EnumCnstPrntEnumOutp");
}

internal class testParentCnstPrntEnumOutpEncoder : IEncoder<testParentCnstPrntEnumOutp>
{
  public Structured Encode(testParentCnstPrntEnumOutp input)
    => new(input.ToString(), "_ParentCnstPrntEnumOutp");
}

internal static class test_constraint_parent_enum_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_enum_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstPrntEnumOutpObject>(_ => new testCnstPrntEnumOutpEncoder())
      .AddEncoder<testEnumCnstPrntEnumOutp>(_ => new testEnumCnstPrntEnumOutpEncoder())
      .AddEncoder<testParentCnstPrntEnumOutp>(_ => new testParentCnstPrntEnumOutpEncoder());
}
