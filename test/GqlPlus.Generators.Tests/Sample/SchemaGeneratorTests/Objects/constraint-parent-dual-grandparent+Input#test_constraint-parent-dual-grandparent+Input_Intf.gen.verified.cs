//HintName: test_constraint-parent-dual-grandparent+Input_Intf.gen.cs
// Generated from constraint-parent-dual-grandparent+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

public interface ItestCnstPrntDualGrndInp
  : ItestRefCnstPrntDualGrndInp
{
}

public interface ItestRefCnstPrntDualGrndInp<Tref>
  : Itestref
{
}

public interface ItestGrndCnstPrntDualGrndInp
{
  String AsString { get; }
}

public interface ItestPrntCnstPrntDualGrndInp
  : ItestGrndCnstPrntDualGrndInp
{
}

public interface ItestAltCnstPrntDualGrndInp
  : ItestPrntCnstPrntDualGrndInp
{
  Number alt { get; }
}
