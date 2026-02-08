//HintName: test_constraint-parent-dual-grandparent+Input_Intf.gen.cs
// Generated from constraint-parent-dual-grandparent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

public interface ItestCnstPrntDualGrndInp
  : ItestRefCnstPrntDualGrndInp
{
}

public interface ItestCnstPrntDualGrndInpObject
  : ItestRefCnstPrntDualGrndInpObject
{
}

public interface ItestRefCnstPrntDualGrndInp<Tref>
  : Itestref
{
}

public interface ItestRefCnstPrntDualGrndInpObject<Tref>
  : ItestrefObject
{
}

public interface ItestGrndCnstPrntDualGrndInp
{
  public ItestString AsString { get; set; }
}

public interface ItestGrndCnstPrntDualGrndInpObject
{
}

public interface ItestPrntCnstPrntDualGrndInp
  : ItestGrndCnstPrntDualGrndInp
{
}

public interface ItestPrntCnstPrntDualGrndInpObject
  : ItestGrndCnstPrntDualGrndInpObject
{
}

public interface ItestAltCnstPrntDualGrndInp
  : ItestPrntCnstPrntDualGrndInp
{
}

public interface ItestAltCnstPrntDualGrndInpObject
  : ItestPrntCnstPrntDualGrndInpObject
{
  public ItestNumber Alt { get; set; }
}
