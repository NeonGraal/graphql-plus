//HintName: test_constraint-enum-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

internal class testCnstEnumPrntInpDecoder
{
}

internal class testRefCnstEnumPrntInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstEnumPrntInpDecoder
{
  public string parentCnstEnumPrntInp { get; set; }
  public string cnstEnumPrntInp { get; set; }
}

internal class testParentCnstEnumPrntInpDecoder
{
  public string parentCnstEnumPrntInp { get; set; }
}

internal static class test_constraint_enum_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_enum_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstEnumPrntInpObject>(_ => new testCnstEnumPrntInpDecoder())
      .AddDecoder<testEnumCnstEnumPrntInp>(_ => new testEnumCnstEnumPrntInpDecoder())
      .AddDecoder<testParentCnstEnumPrntInp>(_ => new testParentCnstEnumPrntInpDecoder());
}
