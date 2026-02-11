//HintName: test_generic-field-dual+Input_Intf.gen.cs
// Generated from generic-field-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

public interface ItestGnrcFieldDualInp
{
  ItestGnrcFieldDualInpObject AsGnrcFieldDualInp { get; }
}

public interface ItestGnrcFieldDualInpObject
{
  ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> Field { get; }
}

public interface ItestRefGnrcFieldDualInp<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcFieldDualInpObject AsRefGnrcFieldDualInp { get; }
}

public interface ItestRefGnrcFieldDualInpObject<Tref>
{
}

public interface ItestAltGnrcFieldDualInp
{
  string AsString { get; }
  ItestAltGnrcFieldDualInpObject AsAltGnrcFieldDualInp { get; }
}

public interface ItestAltGnrcFieldDualInpObject
{
  decimal Alt { get; }
}
