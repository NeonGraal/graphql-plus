//HintName: test_object-param+Output_Intf.gen.cs
// Generated from {CurrentDirectory}object-param+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Output;

public interface ItestObjParamOutp<TTest,TType>
  : IGqlpModelImplementationBase
{
  ItestObjParamOutpObject<TTest,TType>? As_ObjParamOutp { get; }
}

public interface ItestObjParamOutpObject<TTest,TType>
  : IGqlpModelImplementationBase
{
  TTest Test { get; }
  TType Type { get; }
}
