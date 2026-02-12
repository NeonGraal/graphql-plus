//HintName: test_generic-parent-string-dom+Dual_Intf.gen.cs
// Generated from generic-parent-string-dom+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Dual;

public interface ItestGnrcPrntStrDomDual
  : ItestFieldGnrcPrntStrDomDual<ItestDomGnrcPrntStrDomDual>
{
  ItestGnrcPrntStrDomDualObject AsGnrcPrntStrDomDual { get; }
}

public interface ItestGnrcPrntStrDomDualObject
  : ItestFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual>
{
}

public interface ItestFieldGnrcPrntStrDomDual<TRef>
{
  ItestFieldGnrcPrntStrDomDualObject<TRef> AsFieldGnrcPrntStrDomDual { get; }
}

public interface ItestFieldGnrcPrntStrDomDualObject<TRef>
{
  TRef Field { get; }
}

public interface ItestDomGnrcPrntStrDomDual
  : IDomainString
{
}
