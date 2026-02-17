//HintName: test_object-field+Input_Intf.gen.cs
// Generated from {CurrentDirectory}object-field+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Input;

public interface ItestObjFieldInp
  : IGqlpModelImplementationBase
{
  ItestObjFieldInpObject? As_ObjFieldInp { get; }
}

public interface ItestObjFieldInpObject
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldInp Field { get; }
}

public interface ItestFldObjFieldInp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldInpObject? As_FldObjFieldInp { get; }
}

public interface ItestFldObjFieldInpObject
  : IGqlpModelImplementationBase
{
}
