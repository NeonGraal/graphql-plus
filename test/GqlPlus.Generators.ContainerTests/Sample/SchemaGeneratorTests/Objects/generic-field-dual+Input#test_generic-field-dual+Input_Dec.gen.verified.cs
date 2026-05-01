//HintName: test_generic-field-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

internal class testGnrcFieldDualInpDecoder : IDecoder<ItestGnrcFieldDualInpObject>
{
  public ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp>? Field { get; set; }

  public IMessages Decode(IValue input, out ItestGnrcFieldDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcFieldDualInpDecoder<TRef>
{
}

internal class testAltGnrcFieldDualInpDecoder : IDecoder<ItestAltGnrcFieldDualInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcFieldDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_field_dual_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_field_dual_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcFieldDualInpObject>(testGnrcFieldDualInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcFieldDualInpObject>(testAltGnrcFieldDualInpDecoder.Factory);
}
