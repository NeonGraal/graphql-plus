//HintName: test_constraint-alt-obj+Dual_Impl.gen.cs
// Generated from constraint-alt-obj+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

public class testCnstAltObjDual
  : ItestCnstAltObjDual
{
}

public class testRefCnstAltObjDual<TRef>
  : ItestRefCnstAltObjDual<TRef>
{
}

public class testPrntCnstAltObjDual
  : ItestPrntCnstAltObjDual
{
}

public class testAltCnstAltObjDual
  : testPrntCnstAltObjDual
  , ItestAltCnstAltObjDual
{
  public decimal Alt { get; set; }
}
