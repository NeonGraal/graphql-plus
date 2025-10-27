//HintName: test_generic-field-dual+Input_Impl.gen.cs
// Generated from generic-field-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

public class testGnrcFieldDualInp
  : ItestGnrcFieldDualInp
{
  public RefGnrcFieldDualInp<AltGnrcFieldDualInp> field { get; set; }
}

public class testRefGnrcFieldDualInp<Tref>
  : ItestRefGnrcFieldDualInp<Tref>
{
  public Tref Asref { get; set; }
}

public class testAltGnrcFieldDualInp
  : ItestAltGnrcFieldDualInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
