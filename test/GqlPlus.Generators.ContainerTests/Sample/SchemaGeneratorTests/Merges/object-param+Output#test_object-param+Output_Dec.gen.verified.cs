//HintName: test_object-param+Output_Dec.gen.cs
// Generated from {CurrentDirectory}object-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Output;

public interface ItestObjParamOutp<TTest,TType>
  // No Base because it's Class
{
  ItestObjParamOutpObject<TTest,TType>? As_ObjParamOutp { get; }
}

public interface ItestObjParamOutpObject<TTest,TType>
  // No Base because it's Class
{
  TTest Test { get; }
  TType Type { get; }
}
