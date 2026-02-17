//HintName: test_generic-parent-enum-dom+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Dual;

public interface ItestGnrcPrntEnumDomDual
  : ItestFieldGnrcPrntEnumDomDual<ItestDomGnrcPrntEnumDomDual>
{
  ItestGnrcPrntEnumDomDualObject? As_GnrcPrntEnumDomDual { get; }
}

public interface ItestGnrcPrntEnumDomDualObject
  : ItestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>
{
}

public interface ItestFieldGnrcPrntEnumDomDual<TRef>
  : IGqlpModelImplementationBase
{
  ItestFieldGnrcPrntEnumDomDualObject<TRef>? As_FieldGnrcPrntEnumDomDual { get; }
}

public interface ItestFieldGnrcPrntEnumDomDualObject<TRef>
  : IGqlpModelImplementationBase
{
  TRef Field { get; }
}

public interface ItestDomGnrcPrntEnumDomDual
  : IGqlpDomainEnum
{
}
