//HintName: test_constraint-parent-dual-grandparent+Output_Intf.gen.cs
// Generated from constraint-parent-dual-grandparent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Output;

public interface ItestCnstPrntDualGrndOutp
  : ItestRefCnstPrntDualGrndOutp
{
  public ItestCnstPrntDualGrndOutpObject AsCnstPrntDualGrndOutp { get; set; }
}

public interface ItestCnstPrntDualGrndOutpObject
  : ItestRefCnstPrntDualGrndOutpObject
{
}

public interface ItestRefCnstPrntDualGrndOutp<Tref>
  : Itestref
{
  public ItestRefCnstPrntDualGrndOutpObject AsRefCnstPrntDualGrndOutp { get; set; }
}

public interface ItestRefCnstPrntDualGrndOutpObject<Tref>
  : ItestrefObject
{
}

public interface ItestGrndCnstPrntDualGrndOutp
{
  public ItestString AsString { get; set; }
  public ItestGrndCnstPrntDualGrndOutpObject AsGrndCnstPrntDualGrndOutp { get; set; }
}

public interface ItestGrndCnstPrntDualGrndOutpObject
{
}

public interface ItestPrntCnstPrntDualGrndOutp
  : ItestGrndCnstPrntDualGrndOutp
{
  public ItestPrntCnstPrntDualGrndOutpObject AsPrntCnstPrntDualGrndOutp { get; set; }
}

public interface ItestPrntCnstPrntDualGrndOutpObject
  : ItestGrndCnstPrntDualGrndOutpObject
{
}

public interface ItestAltCnstPrntDualGrndOutp
  : ItestPrntCnstPrntDualGrndOutp
{
  public ItestAltCnstPrntDualGrndOutpObject AsAltCnstPrntDualGrndOutp { get; set; }
}

public interface ItestAltCnstPrntDualGrndOutpObject
  : ItestPrntCnstPrntDualGrndOutpObject
{
  public ItestNumber Alt { get; set; }
}
