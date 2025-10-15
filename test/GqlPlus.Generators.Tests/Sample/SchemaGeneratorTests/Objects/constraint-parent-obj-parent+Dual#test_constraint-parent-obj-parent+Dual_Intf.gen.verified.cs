//HintName: test_constraint-parent-obj-parent+Dual_Intf.gen.cs
// Generated from constraint-parent-obj-parent+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

public interface ItestCnstPrntObjPrntDual
  : ItestRefCnstPrntObjPrntDual
{
}

public interface ItestRefCnstPrntObjPrntDual<Tref>
  : Itestref
{
}

public interface ItestPrntCnstPrntObjPrntDual
{
  String AsString { get; }
}

public interface ItestAltCnstPrntObjPrntDual
  : ItestPrntCnstPrntObjPrntDual
{
  Number alt { get; }
}
