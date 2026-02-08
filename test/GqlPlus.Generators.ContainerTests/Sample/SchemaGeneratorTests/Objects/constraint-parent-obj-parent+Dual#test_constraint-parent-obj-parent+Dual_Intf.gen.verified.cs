//HintName: test_constraint-parent-obj-parent+Dual_Intf.gen.cs
// Generated from constraint-parent-obj-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

public interface ItestCnstPrntObjPrntDual
  : ItestRefCnstPrntObjPrntDual
{
}

public interface ItestCnstPrntObjPrntDualObject
  : ItestRefCnstPrntObjPrntDualObject
{
}

public interface ItestRefCnstPrntObjPrntDual<Tref>
  : Itestref
{
}

public interface ItestRefCnstPrntObjPrntDualObject<Tref>
  : ItestrefObject
{
}

public interface ItestPrntCnstPrntObjPrntDual
{
  public ItestString AsString { get; set; }
}

public interface ItestPrntCnstPrntObjPrntDualObject
{
}

public interface ItestAltCnstPrntObjPrntDual
  : ItestPrntCnstPrntObjPrntDual
{
}

public interface ItestAltCnstPrntObjPrntDualObject
  : ItestPrntCnstPrntObjPrntDualObject
{
  public ItestNumber Alt { get; set; }
}
