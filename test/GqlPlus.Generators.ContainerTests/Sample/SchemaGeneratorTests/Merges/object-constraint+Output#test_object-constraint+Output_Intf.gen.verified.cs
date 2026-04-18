//HintName: test_object-constraint+Output_Intf.gen.cs
// Generated from {CurrentDirectory}object-constraint+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Output;

public interface ItestObjCnstOutp<TType>
  : IGqlpInterfaceBase
{
  ItestObjCnstOutpObject<TType>? As_ObjCnstOutp { get; }
}

public interface ItestObjCnstOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
  TType Str { get; }
}
