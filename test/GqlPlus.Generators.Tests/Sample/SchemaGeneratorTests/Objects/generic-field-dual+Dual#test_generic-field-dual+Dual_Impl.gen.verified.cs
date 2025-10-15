//HintName: test_generic-field-dual+Dual_Impl.gen.cs
// Generated from generic-field-dual+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

public class DualtestGnrcFieldDualDual
  : ItestGnrcFieldDualDual
{
  public RefGnrcFieldDualDual<AltGnrcFieldDualDual> field { get; set; }
}

public class DualtestRefGnrcFieldDualDual<Tref>
  : ItestRefGnrcFieldDualDual<Tref>
{
  public Tref Asref { get; set; }
}

public class DualtestAltGnrcFieldDualDual
  : ItestAltGnrcFieldDualDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
