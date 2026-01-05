//HintName: test_generic-parent-string-dom+Output_Intf.gen.cs
// Generated from generic-parent-string-dom+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Output;

public interface ItestGnrcPrntStrDomOutp
  : ItestFieldGnrcPrntStrDomOutp
{
  public testGnrcPrntStrDomOutp GnrcPrntStrDomOutp { get; set; }
}

public interface ItestGnrcPrntStrDomOutpField
  : ItestFieldGnrcPrntStrDomOutpField
{
}

public interface ItestFieldGnrcPrntStrDomOutp<Tref>
{
  public testFieldGnrcPrntStrDomOutp FieldGnrcPrntStrDomOutp { get; set; }
}

public interface ItestFieldGnrcPrntStrDomOutpField<Tref>
{
  public Tref field { get; set; }
}

public interface ItestDomGnrcPrntStrDomOutp
  : IDomainString
{
}
