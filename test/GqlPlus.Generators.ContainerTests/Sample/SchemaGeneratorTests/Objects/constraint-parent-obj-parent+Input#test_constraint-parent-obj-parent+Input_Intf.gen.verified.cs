//HintName: test_constraint-parent-obj-parent+Input_Intf.gen.cs
// Generated from constraint-parent-obj-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Input;

public interface ItestCnstPrntObjPrntInp
  : ItestRefCnstPrntObjPrntInp<ItestAltCnstPrntObjPrntInp>
{
  ItestCnstPrntObjPrntInpObject AsCnstPrntObjPrntInp { get; }
}

public interface ItestCnstPrntObjPrntInpObject
  : ItestRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp>
{
}

public interface ItestRefCnstPrntObjPrntInp<TRef>
  : Itestref
{
  ItestRefCnstPrntObjPrntInpObject AsRefCnstPrntObjPrntInp { get; }
}

public interface ItestRefCnstPrntObjPrntInpObject<TRef>
  : ItestrefObject
{
}

public interface ItestPrntCnstPrntObjPrntInp
{
  string AsString { get; }
  ItestPrntCnstPrntObjPrntInpObject AsPrntCnstPrntObjPrntInp { get; }
}

public interface ItestPrntCnstPrntObjPrntInpObject
{
}

public interface ItestAltCnstPrntObjPrntInp
  : ItestPrntCnstPrntObjPrntInp
{
  ItestAltCnstPrntObjPrntInpObject AsAltCnstPrntObjPrntInp { get; }
}

public interface ItestAltCnstPrntObjPrntInpObject
  : ItestPrntCnstPrntObjPrntInpObject
{
  decimal Alt { get; }
}
