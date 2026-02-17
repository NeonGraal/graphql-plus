//HintName: test_constraint-alt-obj+Input_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

public class testCnstAltObjInp
  : ItestCnstAltObjInp
{
}

public class testRefCnstAltObjInp<TRef>
  : ItestRefCnstAltObjInp<TRef>
{
}

public class testPrntCnstAltObjInp
  : ItestPrntCnstAltObjInp
{
}

public class testAltCnstAltObjInp
  : testPrntCnstAltObjInp
  , ItestAltCnstAltObjInp
{
  public decimal Alt { get; set; }
}
