//HintName: test_constraint-alt-obj+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

internal class testCnstAltObjOutpDecoder
{
}

internal class testRefCnstAltObjOutpDecoder<TRef>
{
}

internal class testPrntCnstAltObjOutpDecoder
{
}

internal class testAltCnstAltObjOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_alt_obj_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_alt_obj_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstAltObjOutpObject>(_ => new testCnstAltObjOutpDecoder())
      .AddDecoder<ItestPrntCnstAltObjOutpObject>(_ => new testPrntCnstAltObjOutpDecoder())
      .AddDecoder<ItestAltCnstAltObjOutpObject>(r => new testAltCnstAltObjOutpDecoder(r));
}
