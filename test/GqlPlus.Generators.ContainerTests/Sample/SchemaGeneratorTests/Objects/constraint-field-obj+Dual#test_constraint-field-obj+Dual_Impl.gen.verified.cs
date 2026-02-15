//HintName: test_constraint-field-obj+Dual_Impl.gen.cs
// Generated from constraint-field-obj+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

public class testCnstFieldObjDual
  : testRefCnstFieldObjDual<ItestAltCnstFieldObjDual>
  , ItestCnstFieldObjDual
{
}

public class testRefCnstFieldObjDual<TRef>
  : ItestRefCnstFieldObjDual<TRef>
{
  public TRef Field { get; set; }
}

public class testPrntCnstFieldObjDual
  : ItestPrntCnstFieldObjDual
{
}

public class testAltCnstFieldObjDual
  : testPrntCnstFieldObjDual
  , ItestAltCnstFieldObjDual
{
  public decimal Alt { get; set; }
}
