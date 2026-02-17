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
  ItestRefCnstEnumDual<testEnumCnstEnumDual> AsEnumCnstEnumDualcnstEnumDual { get; }
  ItestCnstEnumDualObject AsCnstEnumDual { get; }
}

public interface ItestCnstEnumDualObject
{
}

public interface ItestRefCnstEnumDual<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumDualObject<TType> AsRefCnstEnumDual { get; }
}

public interface ItestRefCnstEnumDualObject<TType>
{
  TType Field { get; }
}
