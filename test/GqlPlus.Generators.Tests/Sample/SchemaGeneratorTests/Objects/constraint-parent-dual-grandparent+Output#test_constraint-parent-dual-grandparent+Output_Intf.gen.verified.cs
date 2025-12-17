//HintName: test_constraint-parent-dual-grandparent+Output_Intf.gen.cs
// Generated from constraint-parent-dual-grandparent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Output;

public interface ItestCnstPrntDualGrndOutp
  : ItestRefCnstPrntDualGrndOutp
{
  public testCnstPrntDualGrndOutp CnstPrntDualGrndOutp { get; set; }
}

public interface ItestCnstPrntDualGrndOutpField
  : ItestRefCnstPrntDualGrndOutpField
{
}

public interface ItestRefCnstPrntDualGrndOutp<Tref>
  : Itestref
{
  public testRefCnstPrntDualGrndOutp RefCnstPrntDualGrndOutp { get; set; }
}

public interface ItestRefCnstPrntDualGrndOutpField<Tref>
  : ItestrefField
{
}

public interface ItestGrndCnstPrntDualGrndOutp
{
  public testString AsString { get; set; }
  public testGrndCnstPrntDualGrndOutp GrndCnstPrntDualGrndOutp { get; set; }
}

public interface ItestGrndCnstPrntDualGrndOutpField
{
}

public interface ItestPrntCnstPrntDualGrndOutp
  : ItestGrndCnstPrntDualGrndOutp
{
  public testPrntCnstPrntDualGrndOutp PrntCnstPrntDualGrndOutp { get; set; }
}

public interface ItestPrntCnstPrntDualGrndOutpField
  : ItestGrndCnstPrntDualGrndOutpField
{
}

public interface ItestAltCnstPrntDualGrndOutp
  : ItestPrntCnstPrntDualGrndOutp
{
  public testAltCnstPrntDualGrndOutp AltCnstPrntDualGrndOutp { get; set; }
}

public interface ItestAltCnstPrntDualGrndOutpField
  : ItestPrntCnstPrntDualGrndOutpField
{
  public testNumber alt { get; set; }
}
