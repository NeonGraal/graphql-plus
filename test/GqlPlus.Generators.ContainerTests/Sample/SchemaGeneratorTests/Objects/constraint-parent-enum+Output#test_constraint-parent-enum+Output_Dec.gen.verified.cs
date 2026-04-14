//HintName: test_constraint-parent-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

internal class testEnumCnstPrntEnumOutpDecoder
{
  public string parentCnstPrntEnumOutp { get; set; }
  public string cnstPrntEnumOutp { get; set; }
}

internal class testParentCnstPrntEnumOutpDecoder
{
  public string parentCnstPrntEnumOutp { get; set; }
}

internal static class test_constraint_parent_enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumCnstPrntEnumOutp>(_ => new testEnumCnstPrntEnumOutpDecoder())
      .AddDecoder<testParentCnstPrntEnumOutp>(_ => new testParentCnstPrntEnumOutpDecoder());
}
