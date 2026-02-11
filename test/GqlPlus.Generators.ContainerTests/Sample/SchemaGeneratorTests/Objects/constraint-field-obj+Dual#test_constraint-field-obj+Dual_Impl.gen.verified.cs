//HintName: test_constraint-field-obj+Dual_Impl.gen.cs
// Generated from constraint-field-obj+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

public class testCnstFieldObjDual
  : testRefCnstFieldObjDual<ItestAltCnstFieldObjDual>
  , ItestCnstFieldObjDual
{
  public ItestCnstFieldObjDualObject AsCnstFieldObjDual { get; set; }
}

public class testRefCnstFieldObjDual<TRef>
  : ItestRefCnstFieldObjDual<TRef>
{
  public TRef Field { get; set; }
  public ItestRefCnstFieldObjDualObject AsRefCnstFieldObjDual { get; set; }
}

public class testPrntCnstFieldObjDual
  : ItestPrntCnstFieldObjDual
{
  public string AsString { get; set; }
  public ItestPrntCnstFieldObjDualObject AsPrntCnstFieldObjDual { get; set; }
}

public class testAltCnstFieldObjDual
  : testPrntCnstFieldObjDual
  , ItestAltCnstFieldObjDual
{
  public decimal Alt { get; set; }
  public ItestAltCnstFieldObjDualObject AsAltCnstFieldObjDual { get; set; }
}
