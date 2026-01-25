//HintName: test_generic-parent-string-dom+Dual_Intf.gen.cs
// Generated from generic-parent-string-dom+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Dual;

public interface ItestGnrcPrntStrDomDual
  : ItestFieldGnrcPrntStrDomDual
{
  public testGnrcPrntStrDomDual GnrcPrntStrDomDual { get; set; }
}

public interface ItestGnrcPrntStrDomDualObject
  : ItestFieldGnrcPrntStrDomDualObject
{
}

public interface ItestFieldGnrcPrntStrDomDual<Tref>
{
  public testFieldGnrcPrntStrDomDual FieldGnrcPrntStrDomDual { get; set; }
}

public interface ItestFieldGnrcPrntStrDomDualObject<Tref>
{
  public Tref field { get; set; }
}

public interface ItestDomGnrcPrntStrDomDual
  : IDomainString
{
}
