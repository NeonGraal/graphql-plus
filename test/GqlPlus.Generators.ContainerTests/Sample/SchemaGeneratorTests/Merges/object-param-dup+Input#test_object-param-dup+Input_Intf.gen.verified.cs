//HintName: test_object-param-dup+Input_Intf.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Input;

public interface ItestObjParamDupInp<TTest>
  : IGqlpModelImplementationBase
{
  ItestObjParamDupInpObject<TTest>? As_ObjParamDupInp { get; }
}

public interface ItestObjParamDupInpObject<TTest>
  : IGqlpModelImplementationBase
{
  TTest Test { get; }
  TTest Type { get; }
}
