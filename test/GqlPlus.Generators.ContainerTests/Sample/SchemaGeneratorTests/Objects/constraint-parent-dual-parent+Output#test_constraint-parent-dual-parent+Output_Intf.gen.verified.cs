//HintName: test_constraint-parent-dual-parent+Output_Intf.gen.cs
// Generated from constraint-parent-dual-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Output;

public interface ItestCnstPrntDualPrntOutp
  : ItestRefCnstPrntDualPrntOutp<ItestAltCnstPrntDualPrntOutp>
{
  ItestCnstPrntDualPrntOutpObject AsCnstPrntDualPrntOutp { get; }
}

public interface ItestCnstPrntDualPrntOutpObject
  : ItestRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp>
{
}

public interface ItestRefCnstPrntDualPrntOutp<TRef>
  : Itestref
{
  ItestRefCnstPrntDualPrntOutpObject<TRef> AsRefCnstPrntDualPrntOutp { get; }
}

public interface ItestRefCnstPrntDualPrntOutpObject<TRef>
  : ItestrefObject
{
}

public interface ItestPrntCnstPrntDualPrntOutp
{
  string AsString { get; }
  ItestPrntCnstPrntDualPrntOutpObject AsPrntCnstPrntDualPrntOutp { get; }
}

public interface ItestPrntCnstPrntDualPrntOutpObject
{
}

public interface ItestAltCnstPrntDualPrntOutp
  : ItestPrntCnstPrntDualPrntOutp
{
  ItestAltCnstPrntDualPrntOutpObject AsAltCnstPrntDualPrntOutp { get; }
}

public interface ItestAltCnstPrntDualPrntOutpObject
  : ItestPrntCnstPrntDualPrntOutpObject
{
  decimal Alt { get; }
}
