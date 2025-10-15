//HintName: test_generic-parent-string-dom+Dual_Impl.gen.cs
// Generated from generic-parent-string-dom+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Dual;

public class DualtestGnrcPrntStrDomDual
  : DualtestFieldGnrcPrntStrDomDual
  , ItestGnrcPrntStrDomDual
{
}

public class DualtestFieldGnrcPrntStrDomDual<Tref>
  : ItestFieldGnrcPrntStrDomDual<Tref>
{
  public Tref field { get; set; }
}

public class DomaintestDomGnrcPrntStrDomDual
  : ItestDomGnrcPrntStrDomDual
{
}
