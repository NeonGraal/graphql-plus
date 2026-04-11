//HintName: test_object-field+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-field+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Dual;

public interface ItestObjFieldDual
  : IGqlpInterfaceBase
{
  ItestObjFieldDualObject? As_ObjFieldDual { get; }
}

public interface ItestObjFieldDualObject
  : IGqlpInterfaceBase
{
  ItestFldObjFieldDual Field { get; }
}

public interface ItestFldObjFieldDual
  : IGqlpInterfaceBase
{
  ItestFldObjFieldDualObject? As_FldObjFieldDual { get; }
}

public interface ItestFldObjFieldDualObject
  : IGqlpInterfaceBase
{
}
