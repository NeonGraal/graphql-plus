//HintName: test_constraint-parent-obj-parent+Dual_Intf.gen.cs
// Generated from constraint-parent-obj-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

public interface ItestCnstPrntObjPrntDual
  : ItestRefCnstPrntObjPrntDual
{
  public ItestCnstPrntObjPrntDualObject AsCnstPrntObjPrntDual { get; set; }
}

public interface ItestCnstPrntObjPrntDualObject
  : ItestRefCnstPrntObjPrntDualObject
{
}

public interface ItestRefCnstPrntObjPrntDual<Tref>
  : Itestref
{
  public ItestRefCnstPrntObjPrntDualObject AsRefCnstPrntObjPrntDual { get; set; }
}

public interface ItestRefCnstPrntObjPrntDualObject<Tref>
  : ItestrefObject
{
}

public interface ItestPrntCnstPrntObjPrntDual
{
  public ItestString AsString { get; set; }
  public ItestPrntCnstPrntObjPrntDualObject AsPrntCnstPrntObjPrntDual { get; set; }
}

public interface ItestPrntCnstPrntObjPrntDualObject
{
}

public interface ItestAltCnstPrntObjPrntDual
  : ItestPrntCnstPrntObjPrntDual
{
  public ItestAltCnstPrntObjPrntDualObject AsAltCnstPrntObjPrntDual { get; set; }
}

public interface ItestAltCnstPrntObjPrntDualObject
  : ItestPrntCnstPrntObjPrntDualObject
{
  public ItestNumber Alt { get; set; }
}
