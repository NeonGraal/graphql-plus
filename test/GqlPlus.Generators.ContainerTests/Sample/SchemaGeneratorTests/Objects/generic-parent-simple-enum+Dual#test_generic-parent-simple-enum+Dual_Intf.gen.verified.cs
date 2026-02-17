//HintName: test_generic-parent-simple-enum+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Dual;

public interface ItestGnrcPrntSmplEnumDual
  : ItestFieldGnrcPrntSmplEnumDual<testEnumGnrcPrntSmplEnumDual>
{
  ItestGnrcPrntSmplEnumDualObject AsGnrcPrntSmplEnumDual { get; }
}

public interface ItestGnrcPrntSmplEnumDualObject
  : ItestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>
{
}

public interface ItestFieldGnrcPrntSmplEnumDual<TRef>
  : IGqlpModelImplementationBase
{
  ItestFieldGnrcPrntSmplEnumDualObject<TRef> AsFieldGnrcPrntSmplEnumDual { get; }
}

public interface ItestFieldGnrcPrntSmplEnumDualObject<TRef>
{
  TRef Field { get; }
}
