//HintName: test_generic-field-dual+Input_Intf.gen.cs
// Generated from generic-field-dual+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

public interface ItestGnrcFieldDualInp
{
  RefGnrcFieldDualInp<AltGnrcFieldDualInp> field { get; }
}

public interface ItestRefGnrcFieldDualInp<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcFieldDualInp
{
  Number alt { get; }
  String AsString { get; }
}
