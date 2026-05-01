//HintName: test_constraint-parent-dual-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Output;

internal class testPrntCnstPrntDualPrntOutpDecoder : IDecoder<ItestPrntCnstPrntDualPrntOutpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstPrntDualPrntOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstPrntDualPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_parent_dual_parent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_dual_parent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntCnstPrntDualPrntOutpObject>(testPrntCnstPrntDualPrntOutpDecoder.Factory);
}
