//HintName: test_constraint-enum-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

public interface ItestCnstEnumPrntDual
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumPrntDual<testEnumCnstEnumPrntDual>? AsEnumCnstEnumPrntDualcnstEnumPrntDual { get; }
  ItestCnstEnumPrntDualObject? As_CnstEnumPrntDual { get; }
}

public interface ItestCnstEnumPrntDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefCnstEnumPrntDual<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumPrntDualObject<TType>? As_RefCnstEnumPrntDual { get; }
}

public interface ItestRefCnstEnumPrntDualObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}
