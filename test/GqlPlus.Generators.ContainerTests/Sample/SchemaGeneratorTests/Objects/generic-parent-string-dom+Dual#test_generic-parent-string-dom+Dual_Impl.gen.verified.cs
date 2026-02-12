//HintName: test_generic-parent-string-dom+Dual_Impl.gen.cs
// Generated from generic-parent-string-dom+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Dual;

public class testGnrcPrntStrDomDual
  : testFieldGnrcPrntStrDomDual<ItestDomGnrcPrntStrDomDual>
  , ItestGnrcPrntStrDomDual
{
  public ItestGnrcPrntStrDomDualObject AsGnrcPrntStrDomDual { get; set; }
}

public class testFieldGnrcPrntStrDomDual<TRef>
  : ItestFieldGnrcPrntStrDomDual<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntStrDomDualObject<TRef> AsFieldGnrcPrntStrDomDual { get; set; }
}

public class testDomGnrcPrntStrDomDual
  : DomainString
  , ItestDomGnrcPrntStrDomDual
{
}
