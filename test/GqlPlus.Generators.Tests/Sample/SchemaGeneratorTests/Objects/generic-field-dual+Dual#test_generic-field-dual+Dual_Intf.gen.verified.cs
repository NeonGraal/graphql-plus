//HintName: test_generic-field-dual+Dual_Intf.gen.cs
// Generated from generic-field-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

public interface ItestGnrcFieldDualDual
{
  public testGnrcFieldDualDual GnrcFieldDualDual { get; set; }
}

public interface ItestGnrcFieldDualDualObject
{
  public testRefGnrcFieldDualDual<testAltGnrcFieldDualDual> field { get; set; }
}

public interface ItestRefGnrcFieldDualDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldDualDual RefGnrcFieldDualDual { get; set; }
}

public interface ItestRefGnrcFieldDualDualObject<Tref>
{
}

public interface ItestAltGnrcFieldDualDual
{
  public testString AsString { get; set; }
  public testAltGnrcFieldDualDual AltGnrcFieldDualDual { get; set; }
}

public interface ItestAltGnrcFieldDualDualObject
{
  public testNumber alt { get; set; }
}
