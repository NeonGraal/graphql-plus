//HintName: test_constraint-field-obj+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

internal class testCnstFieldObjOutpDecoder
{
}

internal class testRefCnstFieldObjOutpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testPrntCnstFieldObjOutpDecoder
{
}

internal class testAltCnstFieldObjOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_field_obj_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_field_obj_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstFieldObjOutpObject>(_ => new testCnstFieldObjOutpDecoder())
      .AddDecoder<ItestPrntCnstFieldObjOutpObject>(_ => new testPrntCnstFieldObjOutpDecoder())
      .AddDecoder<ItestAltCnstFieldObjOutpObject>(r => new testAltCnstFieldObjOutpDecoder(r));
}
