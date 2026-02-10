//HintName: test_constraint-parent-dual-grandparent+Input_Intf.gen.cs
// Generated from constraint-parent-dual-grandparent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

public interface ItestCnstPrntDualGrndInp
  : ItestRefCnstPrntDualGrndInp
{
  public ItestCnstPrntDualGrndInpObject AsCnstPrntDualGrndInp { get; set; }
}

public interface ItestCnstPrntDualGrndInpObject
  : ItestRefCnstPrntDualGrndInpObject
{
}

public interface ItestRefCnstPrntDualGrndInp<Tref>
  : Itestref
{
  public ItestRefCnstPrntDualGrndInpObject AsRefCnstPrntDualGrndInp { get; set; }
}

public interface ItestRefCnstPrntDualGrndInpObject<Tref>
  : ItestrefObject
{
}

public interface ItestGrndCnstPrntDualGrndInp
{
  public string AsString { get; set; }
  public ItestGrndCnstPrntDualGrndInpObject AsGrndCnstPrntDualGrndInp { get; set; }
}

public interface ItestGrndCnstPrntDualGrndInpObject
{
}

public interface ItestPrntCnstPrntDualGrndInp
  : ItestGrndCnstPrntDualGrndInp
{
  public ItestPrntCnstPrntDualGrndInpObject AsPrntCnstPrntDualGrndInp { get; set; }
}

public interface ItestPrntCnstPrntDualGrndInpObject
  : ItestGrndCnstPrntDualGrndInpObject
{
}

public interface ItestAltCnstPrntDualGrndInp
  : ItestPrntCnstPrntDualGrndInp
{
  public ItestAltCnstPrntDualGrndInpObject AsAltCnstPrntDualGrndInp { get; set; }
}

public interface ItestAltCnstPrntDualGrndInpObject
  : ItestPrntCnstPrntDualGrndInpObject
{
  public decimal Alt { get; set; }
}
