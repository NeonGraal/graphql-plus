//HintName: test_generic-parent-enum-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Dual;

public interface ItestGnrcPrntEnumPrntDual
  : ItestFieldGnrcPrntEnumPrntDual<testEnumGnrcPrntEnumPrntDual>
{
  ItestGnrcPrntEnumPrntDualObject? As_GnrcPrntEnumPrntDual { get; }
}

public interface ItestGnrcPrntEnumPrntDualObject
  : ItestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>
{
}

public interface ItestFieldGnrcPrntEnumPrntDual<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntEnumPrntDualObject<TRef>? As_FieldGnrcPrntEnumPrntDual { get; }
}

public interface ItestFieldGnrcPrntEnumPrntDualObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumPrntDual
{
  gnrcPrntEnumPrntDualParent = testParentGnrcPrntEnumPrntDual.gnrcPrntEnumPrntDualParent,
  gnrcPrntEnumPrntDualLabel,
}

public enum testParentGnrcPrntEnumPrntDual
{
  gnrcPrntEnumPrntDualParent,
}
