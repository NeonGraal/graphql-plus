//HintName: test_generic-field-dual+Input_Impl.gen.cs
// Generated from generic-field-dual+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

public class testGnrcFieldDualInp
  : ItestGnrcFieldDualInp
{
  public testRefGnrcFieldDualInp<testAltGnrcFieldDualInp> field { get; set; }
  public testGnrcFieldDualInp GnrcFieldDualInp { get; set; }
}

public class testRefGnrcFieldDualInp<Tref>
  : ItestRefGnrcFieldDualInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldDualInp RefGnrcFieldDualInp { get; set; }
}

public class testAltGnrcFieldDualInp
  : ItestAltGnrcFieldDualInp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcFieldDualInp AltGnrcFieldDualInp { get; set; }
}
