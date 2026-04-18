//HintName: test_object-field-alias+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Dual;

public interface ItestObjFieldAliasDual
  : IGqlpInterfaceBase
{
  ItestObjFieldAliasDualObject? As_ObjFieldAliasDual { get; }
}

public interface ItestObjFieldAliasDualObject
  : IGqlpInterfaceBase
{
  ItestFldObjFieldAliasDual Field { get; }
}

public interface ItestFldObjFieldAliasDual
  : IGqlpInterfaceBase
{
  ItestFldObjFieldAliasDualObject? As_FldObjFieldAliasDual { get; }
}

public interface ItestFldObjFieldAliasDualObject
  : IGqlpInterfaceBase
{
}
