//HintName: test_object-param-dup+Output_Dec.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Output;

public interface ItestObjParamDupOutp<TTest>
  // No Base because it's Class
{
  ItestObjParamDupOutpObject<TTest>? As_ObjParamDupOutp { get; }
}

public interface ItestObjParamDupOutpObject<TTest>
  // No Base because it's Class
{
  TTest Test { get; }
  TTest Type { get; }
}
