//HintName: test_generic-field-dual+Input_Intf.gen.cs
// Generated from generic-field-dual+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

public interface ItestGnrcFieldDualInp
{
  public testGnrcFieldDualInp GnrcFieldDualInp { get; set; }
}

public interface ItestGnrcFieldDualInpField
{
  public testRefGnrcFieldDualInp<testAltGnrcFieldDualInp> field { get; set; }
}

public interface ItestRefGnrcFieldDualInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldDualInp RefGnrcFieldDualInp { get; set; }
}

public interface ItestRefGnrcFieldDualInpField<Tref>
{
}

public interface ItestAltGnrcFieldDualInp
{
  public testString AsString { get; set; }
  public testAltGnrcFieldDualInp AltGnrcFieldDualInp { get; set; }
}

public interface ItestAltGnrcFieldDualInpField
{
  public testNumber alt { get; set; }
}
