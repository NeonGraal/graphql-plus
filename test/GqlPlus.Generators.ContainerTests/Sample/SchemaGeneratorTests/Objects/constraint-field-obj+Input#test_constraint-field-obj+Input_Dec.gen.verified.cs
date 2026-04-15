//HintName: test_constraint-field-obj+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

internal class testCnstFieldObjInpDecoder
{
}

internal class testRefCnstFieldObjInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testPrntCnstFieldObjInpDecoder
{
}

internal class testAltCnstFieldObjInpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_field_obj_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_field_obj_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstFieldObjInpObject>(_ => new testCnstFieldObjInpDecoder())
      .AddDecoder<ItestPrntCnstFieldObjInpObject>(_ => new testPrntCnstFieldObjInpDecoder())
      .AddDecoder<ItestAltCnstFieldObjInpObject>(_ => new testAltCnstFieldObjInpDecoder());
}
