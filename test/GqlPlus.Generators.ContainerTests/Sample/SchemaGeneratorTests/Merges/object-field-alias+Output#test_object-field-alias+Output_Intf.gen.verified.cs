//HintName: test_object-field-alias+Output_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Output;

public interface ItestObjFieldAliasOutp
  : IGqlpInterfaceBase
{
  ItestObjFieldAliasOutpObject? As_ObjFieldAliasOutp { get; }
}

public interface ItestObjFieldAliasOutpObject
  : IGqlpInterfaceBase
{
  ItestFldObjFieldAliasOutp Field { get; }
}

public interface ItestFldObjFieldAliasOutp
  : IGqlpInterfaceBase
{
  ItestFldObjFieldAliasOutpObject? As_FldObjFieldAliasOutp { get; }
}

public interface ItestFldObjFieldAliasOutpObject
  : IGqlpInterfaceBase
{
}
