//HintName: test_generic-parent-string-dom+Input_Intf.gen.cs
// Generated from generic-parent-string-dom+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Input;

public interface ItestGnrcPrntStrDomInp
  : ItestFieldGnrcPrntStrDomInp
{
  public ItestGnrcPrntStrDomInpObject AsGnrcPrntStrDomInp { get; set; }
}

public interface ItestGnrcPrntStrDomInpObject
  : ItestFieldGnrcPrntStrDomInpObject
{
}

public interface ItestFieldGnrcPrntStrDomInp<Tref>
{
  public ItestFieldGnrcPrntStrDomInpObject AsFieldGnrcPrntStrDomInp { get; set; }
}

public interface ItestFieldGnrcPrntStrDomInpObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestDomGnrcPrntStrDomInp
  : IDomainString
{
}
