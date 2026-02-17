//HintName: test_generic-parent-enum-child+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Dual;

public interface ItestGnrcPrntEnumChildDual
  : ItestFieldGnrcPrntEnumChildDual<testParentGnrcPrntEnumChildDual>
{
  ItestGnrcPrntEnumChildDualObject AsGnrcPrntEnumChildDual { get; }
}

public interface ItestGnrcPrntEnumChildDualObject
  : ItestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>
{
}

public interface ItestFieldGnrcPrntEnumChildDual<TRef>
  : IGqlpModelImplementationBase
{
  ItestFieldGnrcPrntEnumChildDualObject<TRef> AsFieldGnrcPrntEnumChildDual { get; }
}

public interface ItestFieldGnrcPrntEnumChildDualObject<TRef>
{
  TRef Field { get; }
}
