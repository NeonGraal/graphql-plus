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

public interface ItestCnstPrntObjPrntDualField
  : ItestRefCnstPrntObjPrntDualField
{
}

public interface ItestRefCnstPrntObjPrntDual<Tref>
  : Itestref
{
  public testRefCnstPrntObjPrntDual RefCnstPrntObjPrntDual { get; set; }
}

public interface ItestRefCnstPrntObjPrntDualField<Tref>
  : ItestrefField
{
}

public interface ItestPrntCnstPrntObjPrntDual
{
  public testString AsString { get; set; }
  public testPrntCnstPrntObjPrntDual PrntCnstPrntObjPrntDual { get; set; }
}

public interface ItestPrntCnstPrntObjPrntDualField
{
}

public interface ItestAltCnstPrntObjPrntDual
  : ItestPrntCnstPrntObjPrntDual
{
  public testAltCnstPrntObjPrntDual AltCnstPrntObjPrntDual { get; set; }
}

public interface ItestAltCnstPrntObjPrntDualField
  : ItestPrntCnstPrntObjPrntDualField
{
  public testNumber alt { get; set; }
}
