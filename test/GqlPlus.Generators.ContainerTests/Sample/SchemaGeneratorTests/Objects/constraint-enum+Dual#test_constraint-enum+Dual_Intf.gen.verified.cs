//HintName: test_constraint-enum+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

public interface ItestCnstEnumDual
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumDual<testEnumCnstEnumDual>? AsEnumCnstEnumDualcnstEnumDual { get; }
  ItestCnstEnumDualObject? As_CnstEnumDual { get; }
}

public interface ItestCnstEnumDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefCnstEnumDual<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumDualObject<TType>? As_RefCnstEnumDual { get; }
}

public interface ItestRefCnstEnumDualObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}
