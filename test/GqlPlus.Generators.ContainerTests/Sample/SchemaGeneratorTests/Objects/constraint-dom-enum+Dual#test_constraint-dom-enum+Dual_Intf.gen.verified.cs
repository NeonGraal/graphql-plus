//HintName: test_constraint-dom-enum+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

public interface ItestCnstDomEnumDual
  : IGqlpInterfaceBase
{
  ItestRefCnstDomEnumDual<testEnumCnstDomEnumDual>? AsEnumCnstDomEnumDualcnstDomEnumDual { get; }
  ItestCnstDomEnumDualObject? As_CnstDomEnumDual { get; }
}

public interface ItestCnstDomEnumDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstDomEnumDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstDomEnumDualObject<TType>? As_RefCnstDomEnumDual { get; }
}

public interface ItestRefCnstDomEnumDualObject<TType>
  : IGqlpInterfaceBase
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
  new testEnumCnstDomEnumDual? Value { get; }
}
