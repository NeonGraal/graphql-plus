//HintName: test_constraint-alt-obj+Output_Impl.gen.cs
// Generated from constraint-alt-obj+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

public class testCnstAltObjOutp
  : ItestCnstAltObjOutp
{
}

public class testRefCnstAltObjOutp<TRef>
  : ItestRefCnstAltObjOutp<TRef>
{
}

public class testPrntCnstAltObjOutp
  : ItestPrntCnstAltObjOutp
{
}

public class testAltCnstAltObjOutp
  : testPrntCnstAltObjOutp
  , ItestAltCnstAltObjOutp
{
  public decimal Alt { get; set; }
}
