//HintName: test_constraint-alt-dual+Output_Intf.gen.cs
// Generated from constraint-alt-dual+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

public interface ItestCnstAltDualOutp
{
  RefCnstAltDualOutp<AltCnstAltDualOutp> AsRefCnstAltDualOutp { get; }
}

public interface ItestRefCnstAltDualOutp<Tref>
{
  Tref Asref { get; }
}

public interface ItestPrntCnstAltDualOutp
{
  String AsString { get; }
}

public interface ItestAltCnstAltDualOutp
  : ItestPrntCnstAltDualOutp
{
  Number alt { get; }
}
