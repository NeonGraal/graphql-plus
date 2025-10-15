//HintName: test_generic-field-dual+Input_Impl.gen.cs
// Generated from generic-field-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

public class InputtestGnrcFieldDualInp
  : ItestGnrcFieldDualInp
{
  public RefGnrcFieldDualInp<AltGnrcFieldDualInp> field { get; set; }
}

public class InputtestRefGnrcFieldDualInp<Tref>
  : ItestRefGnrcFieldDualInp<Tref>
{
  public Tref Asref { get; set; }
}

public class DualtestAltGnrcFieldDualInp
  : ItestAltGnrcFieldDualInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
