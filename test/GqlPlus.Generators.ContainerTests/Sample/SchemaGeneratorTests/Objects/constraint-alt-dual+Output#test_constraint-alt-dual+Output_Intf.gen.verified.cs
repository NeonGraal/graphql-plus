//HintName: test_constraint-alt-dual+Output_Intf.gen.cs
// Generated from constraint-alt-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

public interface ItestCnstAltDualOutp
{
  ItestRefCnstAltDualOutp<ItestAltCnstAltDualOutp> AsRefCnstAltDualOutp { get; }
  ItestCnstAltDualOutpObject AsCnstAltDualOutp { get; }
}

public interface ItestCnstAltDualOutpObject
{
}

public interface ItestRefCnstAltDualOutp<TRef>
{
  TRef Asref { get; }
  ItestRefCnstAltDualOutpObject<TRef> AsRefCnstAltDualOutp { get; }
}

public interface ItestRefCnstAltDualOutpObject<TRef>
{
}

public interface ItestPrntCnstAltDualOutp
{
  string AsString { get; }
  ItestPrntCnstAltDualOutpObject AsPrntCnstAltDualOutp { get; }
}

public interface ItestPrntCnstAltDualOutpObject
{
}

public interface ItestAltCnstAltDualOutp
  : ItestPrntCnstAltDualOutp
{
  ItestAltCnstAltDualOutpObject AsAltCnstAltDualOutp { get; }
}

public interface ItestAltCnstAltDualOutpObject
  : ItestPrntCnstAltDualOutpObject
{
  decimal Alt { get; }
}
