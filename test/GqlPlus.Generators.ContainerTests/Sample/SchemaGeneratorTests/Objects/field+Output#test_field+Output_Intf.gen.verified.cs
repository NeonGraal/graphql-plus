//HintName: test_field+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Output;

public interface ItestFieldOutp
  : IGqlpInterfaceBase
{
  ItestFieldOutpObject? As_FieldOutp { get; }
}

public interface ItestFieldOutpObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}
