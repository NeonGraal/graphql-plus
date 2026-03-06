//HintName: test_object-field+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-field+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Dual;

public interface ItestObjFieldDual
  : IGqlpModelImplementationBase
{
  ItestObjFieldDualObject? As_ObjFieldDual { get; }
}

public interface ItestObjFieldDualObject
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldDual Field { get; }
}

public interface ItestFldObjFieldDual
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldDualObject? As_FldObjFieldDual { get; }
}

public interface ItestFldObjFieldDualObject
  : IGqlpModelImplementationBase
{
}
