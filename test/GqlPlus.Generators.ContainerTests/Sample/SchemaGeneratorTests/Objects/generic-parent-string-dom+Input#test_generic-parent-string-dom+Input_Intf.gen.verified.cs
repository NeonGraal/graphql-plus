//HintName: test_generic-parent-string-dom+Input_Intf.gen.cs
// Generated from generic-parent-string-dom+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Input;

public interface ItestGnrcPrntStrDomInp
  : ItestFieldGnrcPrntStrDomInp
{
  public testGnrcPrntStrDomInp GnrcPrntStrDomInp { get; set; }
}

public interface ItestGnrcPrntStrDomInpObject
  : ItestFieldGnrcPrntStrDomInpObject
{
}

public interface ItestFieldGnrcPrntStrDomInp<Tref>
{
  public testFieldGnrcPrntStrDomInp FieldGnrcPrntStrDomInp { get; set; }
}

public interface ItestFieldGnrcPrntStrDomInpObject<Tref>
{
  public Tref field { get; set; }
}

public interface ItestDomGnrcPrntStrDomInp
  : IDomainString
{
}
