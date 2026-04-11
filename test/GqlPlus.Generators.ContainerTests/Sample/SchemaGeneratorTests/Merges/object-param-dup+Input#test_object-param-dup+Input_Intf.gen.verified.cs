//HintName: test_object-param-dup+Input_Intf.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Input;

public interface ItestObjParamDupInp<TTest>
  : IGqlpInterfaceBase
{
  ItestObjParamDupInpObject<TTest>? As_ObjParamDupInp { get; }
}

public interface ItestObjParamDupInpObject<TTest>
  : IGqlpInterfaceBase
{
  TTest Test { get; }
  TTest Type { get; }
}
