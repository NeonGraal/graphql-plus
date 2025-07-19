//HintName: Model_constraint-parent-obj-parent+Dual.gen.cs
// Generated from constraint-parent-obj-parent+Dual.graphql+

/*
*/

namespace GqlTest.Model_constraint_parent_obj_parent_Dual;

public interface ICnstPrntObjPrntDual
  : IRefCnstPrntObjPrntDual
{
}
public class DualCnstPrntObjPrntDual
  : DualRefCnstPrntObjPrntDual
  , ICnstPrntObjPrntDual
{
}

public interface IRefCnstPrntObjPrntDual<Tref>
  : Iref
{
}
public class DualRefCnstPrntObjPrntDual<Tref>
  : Dualref
  , IRefCnstPrntObjPrntDual<Tref>
{
}

public interface IPrntCnstPrntObjPrntDual
{
  String AsString { get; }
}
public class DualPrntCnstPrntObjPrntDual
  : IPrntCnstPrntObjPrntDual
{
  public String AsString { get; set; }
}

public interface IAltCnstPrntObjPrntDual
  : IPrntCnstPrntObjPrntDual
{
  Number alt { get; }
}
public class DualAltCnstPrntObjPrntDual
  : DualPrntCnstPrntObjPrntDual
  , IAltCnstPrntObjPrntDual
{
  public Number alt { get; set; }
}
