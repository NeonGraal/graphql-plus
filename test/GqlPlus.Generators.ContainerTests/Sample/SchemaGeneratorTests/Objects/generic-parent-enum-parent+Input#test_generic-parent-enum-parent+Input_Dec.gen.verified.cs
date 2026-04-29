//HintName: test_generic-parent-enum-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Input;

internal class testGnrcPrntEnumPrntInpDecoder
{

  internal static testGnrcPrntEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumPrntInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntEnumPrntInpDecoder : IDecoder<testEnumGnrcPrntEnumPrntInp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntEnumPrntInp? output)
    => input.DecodeEnum("EnumGnrcPrntEnumPrntInp", out output);

  internal static testEnumGnrcPrntEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntInpDecoder : IDecoder<testParentGnrcPrntEnumPrntInp?>
{
  public IMessages Decoder(IValue input, out testParentGnrcPrntEnumPrntInp? output)
    => input.DecodeEnum("ParentGnrcPrntEnumPrntInp", out output);

  internal static testParentGnrcPrntEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntEnumPrntInpObject>(testGnrcPrntEnumPrntInpDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumPrntInp?>(testEnumGnrcPrntEnumPrntInpDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumPrntInp?>(testParentGnrcPrntEnumPrntInpDecoder.Factory);
}
