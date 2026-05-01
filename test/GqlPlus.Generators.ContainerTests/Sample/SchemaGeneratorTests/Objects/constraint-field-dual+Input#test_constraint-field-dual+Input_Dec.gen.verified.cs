//HintName: test_constraint-field-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

internal class testCnstFieldDualInpDecoder : IDecoder<ItestCnstFieldDualInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstFieldDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldDualInpDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testPrntCnstFieldDualInpDecoder : IDecoder<ItestPrntCnstFieldDualInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstFieldDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstFieldDualInpDecoder : IDecoder<ItestAltCnstFieldDualInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstFieldDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_field_dual_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_field_dual_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstFieldDualInpObject>(testCnstFieldDualInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstFieldDualInpObject>(testPrntCnstFieldDualInpDecoder.Factory)
      .AddDecoder<ItestAltCnstFieldDualInpObject>(testAltCnstFieldDualInpDecoder.Factory);
}
