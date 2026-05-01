//HintName: test_generic-parent-string-dom+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Dual;

internal class testGnrcPrntStrDomDualDecoder : IDecoder<ItestGnrcPrntStrDomDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntStrDomDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntStrDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntStrDomDualDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testDomGnrcPrntStrDomDualDecoder : IDecoder<ItestDomGnrcPrntStrDomDual>
{

  public IMessages Decode(IValue input, out ItestDomGnrcPrntStrDomDual? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomGnrcPrntStrDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_string_dom_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_string_dom_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntStrDomDualObject>(testGnrcPrntStrDomDualDecoder.Factory)
      .AddDecoder<ItestDomGnrcPrntStrDomDual>(testDomGnrcPrntStrDomDualDecoder.Factory);
}
