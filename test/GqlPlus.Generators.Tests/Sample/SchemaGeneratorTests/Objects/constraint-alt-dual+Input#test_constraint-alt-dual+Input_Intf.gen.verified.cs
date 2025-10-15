//HintName: test_constraint-alt-dual+Input_Intf.gen.cs
// Generated from constraint-alt-dual+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

public interface ItestCnstAltDualInp
{
  RefCnstAltDualInp<AltCnstAltDualInp> AsRefCnstAltDualInp { get; }
}

public interface ItestRefCnstAltDualInp<Tref>
{
  Tref Asref { get; }
}

public interface ItestPrntCnstAltDualInp
{
  String AsString { get; }
}

public interface ItestAltCnstAltDualInp
  : ItestPrntCnstAltDualInp
{
  Number alt { get; }
}
