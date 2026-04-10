//HintName: test_constraint-enum-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

public interface ItestCnstEnumPrntDual
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumPrntDual<testEnumCnstEnumPrntDual>? AsEnumCnstEnumPrntDualcnstEnumPrntDual { get; }
  ItestCnstEnumPrntDualObject? As_CnstEnumPrntDual { get; }
}

public interface ItestCnstEnumPrntDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstEnumPrntDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumPrntDualObject<TType>? As_RefCnstEnumPrntDual { get; }
}

public interface ItestRefCnstEnumPrntDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstEnumPrntDual
{
  parentCnstEnumPrntDual = testParentCnstEnumPrntDual.parentCnstEnumPrntDual,
  cnstEnumPrntDual,
}

public enum testParentCnstEnumPrntDual
{
  parentCnstEnumPrntDual,
}
