//HintName: test_constraint-parent-obj-parent+Input_Intf.gen.cs
// Generated from constraint-parent-obj-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Input;

public interface ItestCnstPrntObjPrntInp
  : ItestRefCnstPrntObjPrntInp
{
}

public interface ItestCnstPrntObjPrntInpObject
  : ItestRefCnstPrntObjPrntInpObject
{
}

public interface ItestRefCnstPrntObjPrntInp<Tref>
  : Itestref
{
}

public interface ItestRefCnstPrntObjPrntInpObject<Tref>
  : ItestrefObject
{
}

public interface ItestPrntCnstPrntObjPrntInp
{
  public ItestString AsString { get; set; }
}

public interface ItestPrntCnstPrntObjPrntInpObject
{
}

public interface ItestAltCnstPrntObjPrntInp
  : ItestPrntCnstPrntObjPrntInp
{
}

public interface ItestAltCnstPrntObjPrntInpObject
  : ItestPrntCnstPrntObjPrntInpObject
{
  public ItestNumber Alt { get; set; }
}
