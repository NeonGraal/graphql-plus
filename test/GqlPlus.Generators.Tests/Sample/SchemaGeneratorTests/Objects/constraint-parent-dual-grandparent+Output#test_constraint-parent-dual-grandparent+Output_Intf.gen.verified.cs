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

public interface ItestCnstPrntDualGrndOutpObject
  : ItestRefCnstPrntDualGrndOutpObject
{
}

public interface ItestRefCnstPrntDualGrndOutp<Tref>
  : Itestref
{
  public testRefCnstPrntDualGrndOutp RefCnstPrntDualGrndOutp { get; set; }
}

public interface ItestRefCnstPrntDualGrndOutpObject<Tref>
  : ItestrefObject
{
}

public interface ItestGrndCnstPrntDualGrndOutp
{
  public testString AsString { get; set; }
  public testGrndCnstPrntDualGrndOutp GrndCnstPrntDualGrndOutp { get; set; }
}

public interface ItestGrndCnstPrntDualGrndOutpObject
{
}

public interface ItestPrntCnstPrntDualGrndOutp
  : ItestGrndCnstPrntDualGrndOutp
{
  public testPrntCnstPrntDualGrndOutp PrntCnstPrntDualGrndOutp { get; set; }
}

public interface ItestPrntCnstPrntDualGrndOutpObject
  : ItestGrndCnstPrntDualGrndOutpObject
{
}

public interface ItestAltCnstPrntDualGrndOutp
  : ItestPrntCnstPrntDualGrndOutp
{
  public testAltCnstPrntDualGrndOutp AltCnstPrntDualGrndOutp { get; set; }
}

public interface ItestAltCnstPrntDualGrndOutpObject
  : ItestPrntCnstPrntDualGrndOutpObject
{
  public testNumber alt { get; set; }
}
