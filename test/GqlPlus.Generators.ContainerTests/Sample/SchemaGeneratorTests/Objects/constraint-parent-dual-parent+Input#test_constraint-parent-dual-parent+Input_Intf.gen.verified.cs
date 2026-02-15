//HintName: test_constraint-parent-dual-parent+Input_Intf.gen.cs
// Generated from constraint-parent-dual-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

public interface ItestCnstPrntDualPrntInp
  : ItestRefCnstPrntDualPrntInp<ItestAltCnstPrntDualPrntInp>
{
  ItestCnstPrntDualPrntInpObject AsCnstPrntDualPrntInp { get; }
}

public interface ItestCnstPrntDualPrntInpObject
  : ItestRefCnstPrntDualPrntInpObject<ItestAltCnstPrntDualPrntInp>
{
}

public interface ItestRefCnstPrntDualPrntInp<TRef>
{
  TRef AsParent { get; }
  ItestRefCnstPrntDualPrntInpObject<TRef> AsRefCnstPrntDualPrntInp { get; }
}

public interface ItestRefCnstPrntDualPrntInpObject<TRef>
{
}

public interface ItestPrntCnstPrntDualPrntInp
{
  string AsString { get; }
  ItestPrntCnstPrntDualPrntInpObject AsPrntCnstPrntDualPrntInp { get; }
}

public interface ItestPrntCnstPrntDualPrntInpObject
{
}

public interface ItestAltCnstPrntDualPrntInp
  : ItestPrntCnstPrntDualPrntInp
{
  ItestAltCnstPrntDualPrntInpObject AsAltCnstPrntDualPrntInp { get; }
}

public interface ItestAltCnstPrntDualPrntInpObject
  : ItestPrntCnstPrntDualPrntInpObject
{
  decimal Alt { get; }
}
