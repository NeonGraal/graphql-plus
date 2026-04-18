//HintName: test_object-param-dup+Output_Intf.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Output;

public interface ItestObjParamDupOutp<TTest>
  : IGqlpInterfaceBase
{
  ItestObjParamDupOutpObject<TTest>? As_ObjParamDupOutp { get; }
}

public interface ItestObjParamDupOutpObject<TTest>
  : IGqlpInterfaceBase
{
  TTest Test { get; }
  TTest Type { get; }
}
