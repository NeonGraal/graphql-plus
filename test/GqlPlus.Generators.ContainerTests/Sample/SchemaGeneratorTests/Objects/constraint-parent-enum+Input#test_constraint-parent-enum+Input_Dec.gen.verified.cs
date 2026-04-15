//HintName: test_constraint-parent-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

internal class testCnstPrntEnumInpDecoder
{
}

internal class testRefCnstPrntEnumInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstPrntEnumInpDecoder
{
  public string parentCnstPrntEnumInp { get; set; }
  public string cnstPrntEnumInp { get; set; }
}

internal class testParentCnstPrntEnumInpDecoder
{
  public string parentCnstPrntEnumInp { get; set; }
}

internal static class test_constraint_parent_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntEnumInpObject>(_ => new testCnstPrntEnumInpDecoder())
      .AddDecoder<testEnumCnstPrntEnumInp>(_ => new testEnumCnstPrntEnumInpDecoder())
      .AddDecoder<testParentCnstPrntEnumInp>(_ => new testParentCnstPrntEnumInpDecoder());
}
