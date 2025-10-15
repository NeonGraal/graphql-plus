//HintName: test_generic-field-dual+Output_Intf.gen.cs
// Generated from generic-field-dual+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

public interface ItestGnrcFieldDualOutp
{
  RefGnrcFieldDualOutp<AltGnrcFieldDualOutp> field { get; }
}

public interface ItestRefGnrcFieldDualOutp<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcFieldDualOutp
{
  Number alt { get; }
  String AsString { get; }
}
