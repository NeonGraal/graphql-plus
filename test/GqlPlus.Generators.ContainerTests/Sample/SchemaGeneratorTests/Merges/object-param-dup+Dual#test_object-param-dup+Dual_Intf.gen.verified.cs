//HintName: test_object-param-dup+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Dual;

public interface ItestObjParamDupDual<TTest>
  : IGqlpModelImplementationBase
{
  ItestObjParamDupDualObject<TTest> AsObjParamDupDual { get; }
}

public interface ItestObjParamDupDualObject<TTest>
{
  TTest Test { get; }
  TTest Type { get; }
}
