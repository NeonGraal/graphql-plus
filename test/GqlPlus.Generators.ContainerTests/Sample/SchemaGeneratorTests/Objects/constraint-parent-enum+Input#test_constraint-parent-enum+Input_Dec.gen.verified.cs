//HintName: test_constraint-parent-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

internal class testCnstPrntEnumInpDecoder : NullDecoder<ItestCnstPrntEnumInpObject>
{

  internal static testCnstPrntEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntEnumInpDecoder<TType>
{
  public TType Field { get; set; } = default!;
}

internal class testEnumCnstPrntEnumInpDecoder : NullDecoder<testEnumCnstPrntEnumInp>
{
  public string parentCnstPrntEnumInp { get; set; } = default!;
  public string cnstPrntEnumInp { get; set; } = default!;

  internal static testEnumCnstPrntEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstPrntEnumInpDecoder : NullDecoder<testParentCnstPrntEnumInp>
{
  public string parentCnstPrntEnumInp { get; set; } = default!;

  internal static testParentCnstPrntEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_parent_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntEnumInpObject>(testCnstPrntEnumInpDecoder.Factory)
      .AddDecoder<testEnumCnstPrntEnumInp>(testEnumCnstPrntEnumInpDecoder.Factory)
      .AddDecoder<testParentCnstPrntEnumInp>(testParentCnstPrntEnumInpDecoder.Factory);
}
