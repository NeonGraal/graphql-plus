//HintName: test_constraint-parent-dual-grandparent+Input_Intf.gen.cs
// Generated from constraint-parent-dual-grandparent+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

public interface ItestCnstPrntDualGrndInp
  : ItestRefCnstPrntDualGrndInp
{
  public testCnstPrntDualGrndInp CnstPrntDualGrndInp { get; set; }
}

public interface ItestCnstPrntDualGrndInpField
  : ItestRefCnstPrntDualGrndInpField
{
}

public interface ItestRefCnstPrntDualGrndInp<Tref>
  : Itestref
{
  public testRefCnstPrntDualGrndInp RefCnstPrntDualGrndInp { get; set; }
}

public interface ItestRefCnstPrntDualGrndInpField<Tref>
  : ItestrefField
{
}

public interface ItestGrndCnstPrntDualGrndInp
{
  public testString AsString { get; set; }
  public testGrndCnstPrntDualGrndInp GrndCnstPrntDualGrndInp { get; set; }
}

public interface ItestGrndCnstPrntDualGrndInpField
{
}

public interface ItestPrntCnstPrntDualGrndInp
  : ItestGrndCnstPrntDualGrndInp
{
  public testPrntCnstPrntDualGrndInp PrntCnstPrntDualGrndInp { get; set; }
}

public interface ItestPrntCnstPrntDualGrndInpField
  : ItestGrndCnstPrntDualGrndInpField
{
}

public interface ItestAltCnstPrntDualGrndInp
  : ItestPrntCnstPrntDualGrndInp
{
  public testAltCnstPrntDualGrndInp AltCnstPrntDualGrndInp { get; set; }
}

public interface ItestAltCnstPrntDualGrndInpField
  : ItestPrntCnstPrntDualGrndInpField
{
  public testNumber alt { get; set; }
}
