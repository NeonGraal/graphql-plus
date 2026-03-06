//HintName: test_object-param+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-param+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Dual;

public interface ItestObjParamDual<TTest,TType>
  : IGqlpModelImplementationBase
{
  ItestObjParamDualObject<TTest,TType>? As_ObjParamDual { get; }
}

public interface ItestObjParamDualObject<TTest,TType>
  : IGqlpModelImplementationBase
{
  TTest Test { get; }
  TType Type { get; }
}
