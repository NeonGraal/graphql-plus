//HintName: test_constraint-field-obj+Dual_Intf.gen.cs
// Generated from constraint-field-obj+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

public interface ItestCnstFieldObjDual
  : ItestRefCnstFieldObjDual
{
  public testCnstFieldObjDual CnstFieldObjDual { get; set; }
}

public interface ItestCnstFieldObjDualObject
  : ItestRefCnstFieldObjDualObject
{
}

public interface ItestRefCnstFieldObjDual<Tref>
{
  public testRefCnstFieldObjDual RefCnstFieldObjDual { get; set; }
}

public interface ItestRefCnstFieldObjDualObject<Tref>
{
  public Tref field { get; set; }
}

public interface ItestPrntCnstFieldObjDual
{
  public testString AsString { get; set; }
  public testPrntCnstFieldObjDual PrntCnstFieldObjDual { get; set; }
}

public interface ItestPrntCnstFieldObjDualObject
{
}

public interface ItestAltCnstFieldObjDual
  : ItestPrntCnstFieldObjDual
{
  public testAltCnstFieldObjDual AltCnstFieldObjDual { get; set; }
}

public interface ItestAltCnstFieldObjDualObject
  : ItestPrntCnstFieldObjDualObject
{
  public testNumber alt { get; set; }
}
