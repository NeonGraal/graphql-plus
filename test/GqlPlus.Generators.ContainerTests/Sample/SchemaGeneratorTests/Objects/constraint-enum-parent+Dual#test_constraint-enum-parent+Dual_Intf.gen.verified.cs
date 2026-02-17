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
  ItestRefCnstEnumPrntDual<testEnumCnstEnumPrntDual> AsEnumCnstEnumPrntDualcnstEnumPrntDual { get; }
  ItestCnstEnumPrntDualObject AsCnstEnumPrntDual { get; }
}

public interface ItestCnstEnumPrntDualObject
{
}

public interface ItestRefCnstEnumPrntDual<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumPrntDualObject<TType> AsRefCnstEnumPrntDual { get; }
}

public interface ItestRefCnstEnumPrntDualObject<TType>
{
  TType Field { get; }
}
