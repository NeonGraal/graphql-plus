//HintName: test_generic-parent-enum-child+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Dual;

public interface ItestGnrcPrntEnumChildDual
  : ItestFieldGnrcPrntEnumChildDual<testParentGnrcPrntEnumChildDual>
{
  ItestGnrcPrntEnumChildDualObject? As_GnrcPrntEnumChildDual { get; }
}

public interface ItestGnrcPrntEnumChildDualObject
  : ItestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>
{
}

public interface ItestFieldGnrcPrntEnumChildDual<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntEnumChildDualObject<TRef>? As_FieldGnrcPrntEnumChildDual { get; }
}

public interface ItestFieldGnrcPrntEnumChildDualObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumChildDual
{
  gnrcPrntEnumChildDualParent = testParentGnrcPrntEnumChildDual.gnrcPrntEnumChildDualParent,
  gnrcPrntEnumChildDualLabel,
}

public enum testParentGnrcPrntEnumChildDual
{
  gnrcPrntEnumChildDualParent,
}
