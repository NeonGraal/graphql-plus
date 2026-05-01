//HintName: test_generic-field-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

internal class testGnrcFieldDualDualDecoder : IDecoder<ItestGnrcFieldDualDualObject>
{
  public ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual>? Field { get; set; }

  public IMessages Decode(IValue input, out ItestGnrcFieldDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcFieldDualDualDecoder<TRef>
{
}

internal class testAltGnrcFieldDualDualDecoder : IDecoder<ItestAltGnrcFieldDualDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcFieldDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_field_dual_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_field_dual_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcFieldDualDualObject>(testGnrcFieldDualDualDecoder.Factory)
      .AddDecoder<ItestAltGnrcFieldDualDualObject>(testAltGnrcFieldDualDualDecoder.Factory);
}
