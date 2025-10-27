//HintName: test_generic-alt-dual+Input_Intf.gen.cs
// Generated from generic-alt-dual+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

public interface ItestGnrcAltDualInp
{
  RefGnrcAltDualInp<AltGnrcAltDualInp> AsRefGnrcAltDualInp { get; }
}

public interface ItestRefGnrcAltDualInp<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcAltDualInp
{
  Number alt { get; }
  String AsString { get; }
}
