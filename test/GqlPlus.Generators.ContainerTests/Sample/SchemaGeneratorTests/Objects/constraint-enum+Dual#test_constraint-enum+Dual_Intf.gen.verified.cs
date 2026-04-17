//HintName: test_constraint-enum+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

public interface ItestCnstEnumDual
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumDual<testEnumCnstEnumDual>? AsEnumCnstEnumDualcnstEnumDual { get; }
  ItestCnstEnumDualObject? As_CnstEnumDual { get; }
}

public interface ItestCnstEnumDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstEnumDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumDualObject<TType>? As_RefCnstEnumDual { get; }
}

public interface ItestRefCnstEnumDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstEnumDual
{
  cnstEnumDual,
}
