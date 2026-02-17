//HintName: test_field+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Dual;

public interface ItestFieldDual
  : IGqlpModelImplementationBase
{
  ItestFieldDualObject AsFieldDual { get; }
}

public interface ItestFieldDualObject
{
  string Field { get; }
}
