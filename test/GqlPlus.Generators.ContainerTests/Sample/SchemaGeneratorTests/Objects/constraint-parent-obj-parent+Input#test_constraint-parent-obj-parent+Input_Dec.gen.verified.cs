//HintName: test_constraint-parent-obj-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Input;

internal class testCnstPrntObjPrntInpDecoder
{

  internal static testCnstPrntObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntObjPrntInpDecoder<TRef>
{
}

internal class testPrntCnstPrntObjPrntInpDecoder
{

  internal static testPrntCnstPrntObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstPrntObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_parent_obj_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_obj_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntObjPrntInpObject>(testCnstPrntObjPrntInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntObjPrntInpObject>(testPrntCnstPrntObjPrntInpDecoder.Factory)
      .AddDecoder<ItestAltCnstPrntObjPrntInpObject>(testAltCnstPrntObjPrntInpDecoder.Factory);
}
