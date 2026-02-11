//HintName: test_generic-field-dual+Input_Impl.gen.cs
// Generated from generic-field-dual+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

public class testGnrcFieldDualInp
  : ItestGnrcFieldDualInp
{
  public ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> Field { get; set; }
  public ItestGnrcFieldDualInpObject AsGnrcFieldDualInp { get; set; }
}

public class testRefGnrcFieldDualInp<TRef>
  : ItestRefGnrcFieldDualInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcFieldDualInpObject AsRefGnrcFieldDualInp { get; set; }
}

public class testAltGnrcFieldDualInp
  : ItestAltGnrcFieldDualInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcFieldDualInpObject AsAltGnrcFieldDualInp { get; set; }
}
