//HintName: test_generic-field-dual+Output_Intf.gen.cs
// Generated from generic-field-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

public interface ItestGnrcFieldDualOutp
{
  ItestGnrcFieldDualOutpObject AsGnrcFieldDualOutp { get; }
}

public interface ItestGnrcFieldDualOutpObject
{
  ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> Field { get; }
}

public interface ItestRefGnrcFieldDualOutp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcFieldDualOutpObject<TRef> AsRefGnrcFieldDualOutp { get; }
}

public interface ItestRefGnrcFieldDualOutpObject<TRef>
{
}

public interface ItestAltGnrcFieldDualOutp
{
  string AsString { get; }
  ItestAltGnrcFieldDualOutpObject AsAltGnrcFieldDualOutp { get; }
}

public interface ItestAltGnrcFieldDualOutpObject
{
  decimal Alt { get; }
}
