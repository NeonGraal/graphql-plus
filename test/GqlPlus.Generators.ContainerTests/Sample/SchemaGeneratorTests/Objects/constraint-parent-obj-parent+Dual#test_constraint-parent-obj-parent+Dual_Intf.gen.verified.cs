//HintName: test_constraint-parent-obj-parent+Dual_Intf.gen.cs
// Generated from constraint-parent-obj-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

public interface ItestCnstPrntObjPrntDual
  : ItestRefCnstPrntObjPrntDual
{
  public testCnstPrntObjPrntDual CnstPrntObjPrntDual { get; set; }
}

public interface ItestCnstPrntObjPrntDualObject
  : ItestRefCnstPrntObjPrntDualObject
{
}

public interface ItestRefCnstPrntObjPrntDual<Tref>
  : Itestref
{
  public testRefCnstPrntObjPrntDual RefCnstPrntObjPrntDual { get; set; }
}

public interface ItestRefCnstPrntObjPrntDualObject<Tref>
  : ItestrefObject
{
}

public interface ItestPrntCnstPrntObjPrntDual
{
  public testString AsString { get; set; }
  public testPrntCnstPrntObjPrntDual PrntCnstPrntObjPrntDual { get; set; }
}

public interface ItestPrntCnstPrntObjPrntDualObject
{
}

public interface ItestAltCnstPrntObjPrntDual
  : ItestPrntCnstPrntObjPrntDual
{
  public testAltCnstPrntObjPrntDual AltCnstPrntObjPrntDual { get; set; }
}

public interface ItestAltCnstPrntObjPrntDualObject
  : ItestPrntCnstPrntObjPrntDualObject
{
  public testNumber alt { get; set; }
}
