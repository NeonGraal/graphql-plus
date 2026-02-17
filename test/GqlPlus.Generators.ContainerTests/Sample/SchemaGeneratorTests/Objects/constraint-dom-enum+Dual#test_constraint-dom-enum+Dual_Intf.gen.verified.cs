//HintName: test_constraint-dom-enum+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

public interface ItestCnstDomEnumDual
  : IGqlpModelImplementationBase
{
  ItestRefCnstDomEnumDual<testEnumCnstDomEnumDual> AsEnumCnstDomEnumDualcnstDomEnumDual { get; }
  ItestCnstDomEnumDualObject AsCnstDomEnumDual { get; }
}

public interface ItestCnstDomEnumDualObject
{
}

public interface ItestRefCnstDomEnumDual<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstDomEnumDualObject<TType> AsRefCnstDomEnumDual { get; }
}

public interface ItestRefCnstDomEnumDualObject<TType>
{
  TType Field { get; }
}

public interface ItestJustCnstDomEnumDual
  : IGqlpDomainEnum
{
}
