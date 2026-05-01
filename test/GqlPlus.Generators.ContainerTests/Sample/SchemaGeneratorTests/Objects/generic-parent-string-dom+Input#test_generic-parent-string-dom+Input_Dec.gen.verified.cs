//HintName: test_generic-parent-string-dom+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Input;

internal class testGnrcPrntStrDomInpDecoder : IDecoder<ItestGnrcPrntStrDomInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntStrDomInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntStrDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntStrDomInpDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testDomGnrcPrntStrDomInpDecoder : IDecoder<ItestDomGnrcPrntStrDomInp>
{

  public IMessages Decode(IValue input, out ItestDomGnrcPrntStrDomInp? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomGnrcPrntStrDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_string_dom_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_string_dom_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntStrDomInpObject>(testGnrcPrntStrDomInpDecoder.Factory)
      .AddDecoder<ItestDomGnrcPrntStrDomInp>(testDomGnrcPrntStrDomInpDecoder.Factory);
}
