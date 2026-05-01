//HintName: test_constraint-parent-dual-grandparent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Output;

internal class testGrndCnstPrntDualGrndOutpDecoder : IDecoder<ItestGrndCnstPrntDualGrndOutpObject>
{

  public IMessages Decode(IValue input, out ItestGrndCnstPrntDualGrndOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGrndCnstPrntDualGrndOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndOutpDecoder : IDecoder<ItestPrntCnstPrntDualGrndOutpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstPrntDualGrndOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstPrntDualGrndOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_parent_dual_grandparent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_dual_grandparent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGrndCnstPrntDualGrndOutpObject>(testGrndCnstPrntDualGrndOutpDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntDualGrndOutpObject>(testPrntCnstPrntDualGrndOutpDecoder.Factory);
}
