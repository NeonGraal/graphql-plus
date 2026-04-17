//HintName: test_constraint-alt+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_Dual;

public interface ItestCnstAltDual<TType>
  : IGqlpInterfaceBase
{
  TType? Astype { get; }
  ItestCnstAltDualObject<TType>? As_CnstAltDual { get; }
}

public interface ItestCnstAltDualObject<TType>
  : IGqlpInterfaceBase
{
}
