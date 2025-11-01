//HintName: test_generic-field-dual+Dual_Impl.gen.cs
// Generated from generic-field-dual+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

public class testGnrcFieldDualDual
  : ItestGnrcFieldDualDual
{
  public testRefGnrcFieldDualDual<testAltGnrcFieldDualDual> field { get; set; }
  public testGnrcFieldDualDual GnrcFieldDualDual { get; set; }
}

public class testRefGnrcFieldDualDual<Tref>
  : ItestRefGnrcFieldDualDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldDualDual RefGnrcFieldDualDual { get; set; }
}

public class testAltGnrcFieldDualDual
  : ItestAltGnrcFieldDualDual
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcFieldDualDual AltGnrcFieldDualDual { get; set; }
}
