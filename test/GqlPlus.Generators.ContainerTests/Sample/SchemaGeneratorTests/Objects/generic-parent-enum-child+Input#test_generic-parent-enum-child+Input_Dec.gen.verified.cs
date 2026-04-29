//HintName: test_generic-parent-enum-child+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Input;

internal class testGnrcPrntEnumChildInpDecoder
{

  internal static testGnrcPrntEnumChildInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumChildInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntEnumChildInpDecoder : IDecoder<testEnumGnrcPrntEnumChildInp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntEnumChildInp? output)
    => input.DecodeEnum("EnumGnrcPrntEnumChildInp", out output);

  internal static testEnumGnrcPrntEnumChildInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildInpDecoder : IDecoder<testParentGnrcPrntEnumChildInp?>
{
  public IMessages Decoder(IValue input, out testParentGnrcPrntEnumChildInp? output)
    => input.DecodeEnum("ParentGnrcPrntEnumChildInp", out output);

  internal static testParentGnrcPrntEnumChildInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_child_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_child_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntEnumChildInpObject>(testGnrcPrntEnumChildInpDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumChildInp?>(testEnumGnrcPrntEnumChildInpDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumChildInp?>(testParentGnrcPrntEnumChildInpDecoder.Factory);
}
