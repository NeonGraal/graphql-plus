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
  ItestRefCnstDomEnumDual<testEnumCnstDomEnumDual>? AsEnumCnstDomEnumDualcnstDomEnumDual { get; }
  ItestCnstDomEnumDualObject? As_CnstDomEnumDual { get; }
}

public interface ItestCnstDomEnumDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefCnstDomEnumDual<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstDomEnumDualObject<TType>? As_RefCnstDomEnumDual { get; }
}

public interface ItestRefCnstDomEnumDualObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}

public enum testEnumCnstDomEnumDual
{
  cnstDomEnumDual,
  other,
}

public interface ItestJustCnstDomEnumDual
  : IGqlpDomainEnum
{
}
