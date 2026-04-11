//HintName: test_generic-parent-string-dom+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Dual;

public interface ItestGnrcPrntStrDomDual
  : ItestFieldGnrcPrntStrDomDual<ItestDomGnrcPrntStrDomDual>
{
  ItestGnrcPrntStrDomDualObject? As_GnrcPrntStrDomDual { get; }
}

public interface ItestGnrcPrntStrDomDualObject
  : ItestFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual>
{
}

public interface ItestFieldGnrcPrntStrDomDual<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntStrDomDualObject<TRef>? As_FieldGnrcPrntStrDomDual { get; }
}

public interface ItestFieldGnrcPrntStrDomDualObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestDomGnrcPrntStrDomDual
  : IGqlpDomainString
{
}
