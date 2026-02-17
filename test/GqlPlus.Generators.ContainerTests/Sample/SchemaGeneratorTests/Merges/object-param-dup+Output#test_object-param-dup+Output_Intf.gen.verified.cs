//HintName: test_object-param-dup+Output_Intf.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Output;

public interface ItestObjParamDupOutp<TTest>
  : IGqlpModelImplementationBase
{
  ItestObjParamDupOutpObject<TTest> AsObjParamDupOutp { get; }
}

public interface ItestObjParamDupOutpObject<TTest>
{
  TTest Test { get; }
  TTest Type { get; }
}
