//HintName: test_constraint-parent-dual-parent+Input_Intf.gen.cs
// Generated from constraint-parent-dual-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

public interface ItestCnstPrntDualPrntInp
  : ItestRefCnstPrntDualPrntInp
{
  public ItestCnstPrntDualPrntInpObject AsCnstPrntDualPrntInp { get; set; }
}

public interface ItestCnstPrntDualPrntInpObject
  : ItestRefCnstPrntDualPrntInpObject
{
}

public interface ItestRefCnstPrntDualPrntInp<Tref>
  : Itestref
{
  public ItestRefCnstPrntDualPrntInpObject AsRefCnstPrntDualPrntInp { get; set; }
}

public interface ItestRefCnstPrntDualPrntInpObject<Tref>
  : ItestrefObject
{
}

public interface ItestPrntCnstPrntDualPrntInp
{
  public ItestString AsString { get; set; }
  public ItestPrntCnstPrntDualPrntInpObject AsPrntCnstPrntDualPrntInp { get; set; }
}

public interface ItestPrntCnstPrntDualPrntInpObject
{
}

public interface ItestAltCnstPrntDualPrntInp
  : ItestPrntCnstPrntDualPrntInp
{
  public ItestAltCnstPrntDualPrntInpObject AsAltCnstPrntDualPrntInp { get; set; }
}

public interface ItestAltCnstPrntDualPrntInpObject
  : ItestPrntCnstPrntDualPrntInpObject
{
  public ItestNumber Alt { get; set; }
}
