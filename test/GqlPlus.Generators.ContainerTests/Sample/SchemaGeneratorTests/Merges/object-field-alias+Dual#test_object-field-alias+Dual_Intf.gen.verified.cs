//HintName: test_object-field-alias+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Dual;

public interface ItestObjFieldAliasDual
  : IGqlpModelImplementationBase
{
  ItestObjFieldAliasDualObject? As_ObjFieldAliasDual { get; }
}

public interface ItestObjFieldAliasDualObject
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasDual Field { get; }
}

public interface ItestFldObjFieldAliasDual
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasDualObject? As_FldObjFieldAliasDual { get; }
}

public interface ItestFldObjFieldAliasDualObject
  : IGqlpModelImplementationBase
{
}
