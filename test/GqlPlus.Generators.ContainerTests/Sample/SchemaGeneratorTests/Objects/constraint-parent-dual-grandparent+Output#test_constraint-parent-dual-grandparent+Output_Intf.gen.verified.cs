//HintName: test_constraint-parent-dual-grandparent+Output_Intf.gen.cs
// Generated from constraint-parent-dual-grandparent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Output;

public interface ItestCnstPrntDualGrndOutp
  : ItestRefCnstPrntDualGrndOutp
{
  ItestCnstPrntDualGrndOutpObject AsCnstPrntDualGrndOutp { get; }
}

public interface ItestCnstPrntDualGrndOutpObject
  : ItestRefCnstPrntDualGrndOutpObject
{
}

public interface ItestRefCnstPrntDualGrndOutp<Tref>
  : Itestref
{
  ItestRefCnstPrntDualGrndOutpObject AsRefCnstPrntDualGrndOutp { get; }
}

public interface ItestRefCnstPrntDualGrndOutpObject<Tref>
  : ItestrefObject
{
}

public interface ItestGrndCnstPrntDualGrndOutp
{
  string AsString { get; }
  ItestGrndCnstPrntDualGrndOutpObject AsGrndCnstPrntDualGrndOutp { get; }
}

public interface ItestGrndCnstPrntDualGrndOutpObject
{
}

public interface ItestPrntCnstPrntDualGrndOutp
  : ItestGrndCnstPrntDualGrndOutp
{
  ItestPrntCnstPrntDualGrndOutpObject AsPrntCnstPrntDualGrndOutp { get; }
}

public interface ItestPrntCnstPrntDualGrndOutpObject
  : ItestGrndCnstPrntDualGrndOutpObject
{
}

public interface ItestAltCnstPrntDualGrndOutp
  : ItestPrntCnstPrntDualGrndOutp
{
  ItestAltCnstPrntDualGrndOutpObject AsAltCnstPrntDualGrndOutp { get; }
}

public interface ItestAltCnstPrntDualGrndOutpObject
  : ItestPrntCnstPrntDualGrndOutpObject
{
  decimal Alt { get; }
}
