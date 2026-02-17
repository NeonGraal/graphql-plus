//HintName: test_constraint-field-obj+Output_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

public class testCnstFieldObjOutp
  : testRefCnstFieldObjOutp<ItestAltCnstFieldObjOutp>
  , ItestCnstFieldObjOutp
{
}

public class testRefCnstFieldObjOutp<TRef>
  : ItestRefCnstFieldObjOutp<TRef>
{
  public TRef Field { get; set; }
}

public class testPrntCnstFieldObjOutp
  : ItestPrntCnstFieldObjOutp
{
}

public class testAltCnstFieldObjOutp
  : testPrntCnstFieldObjOutp
  , ItestAltCnstFieldObjOutp
{
  public decimal Alt { get; set; }
}
