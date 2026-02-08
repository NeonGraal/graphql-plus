//HintName: test_generic-field-dual+Input_Intf.gen.cs
// Generated from generic-field-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

public interface ItestGnrcFieldDualInp
{
  public ItestGnrcFieldDualInpObject AsGnrcFieldDualInp { get; set; }
}

public interface ItestGnrcFieldDualInpObject
{
  public ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> Field { get; set; }
}

public interface ItestRefGnrcFieldDualInp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcFieldDualInpObject AsRefGnrcFieldDualInp { get; set; }
}

public interface ItestRefGnrcFieldDualInpObject<Tref>
{
}

public interface ItestAltGnrcFieldDualInp
{
  public ItestString AsString { get; set; }
  public ItestAltGnrcFieldDualInpObject AsAltGnrcFieldDualInp { get; set; }
}

public interface ItestAltGnrcFieldDualInpObject
{
  public ItestNumber Alt { get; set; }
}
