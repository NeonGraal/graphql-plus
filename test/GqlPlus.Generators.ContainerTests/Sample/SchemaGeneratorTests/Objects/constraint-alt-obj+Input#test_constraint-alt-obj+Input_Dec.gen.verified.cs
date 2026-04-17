//HintName: test_constraint-alt-obj+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

internal class testCnstAltObjInpDecoder
{

  internal static testCnstAltObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltObjInpDecoder<TRef>
{
}

internal class testPrntCnstAltObjInpDecoder
{

  internal static testPrntCnstAltObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstAltObjInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstAltObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_alt_obj_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_alt_obj_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstAltObjInpObject>(testCnstAltObjInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstAltObjInpObject>(testPrntCnstAltObjInpDecoder.Factory)
      .AddDecoder<ItestAltCnstAltObjInpObject>(testAltCnstAltObjInpDecoder.Factory);
}
