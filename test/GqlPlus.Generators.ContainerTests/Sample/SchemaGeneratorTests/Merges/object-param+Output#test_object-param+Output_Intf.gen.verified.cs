//HintName: test_object-param+Output_Intf.gen.cs
// Generated from {CurrentDirectory}object-param+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Output;

public interface ItestObjParamOutp<TTest,TType>
  : IGqlpInterfaceBase
{
  ItestObjParamOutpObject<TTest,TType>? As_ObjParamOutp { get; }
}

public interface ItestObjParamOutpObject<TTest,TType>
  : IGqlpInterfaceBase
{
  TTest Test { get; }
  TType Type { get; }
}
