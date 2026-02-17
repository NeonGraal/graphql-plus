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
  ItestObjFieldInpObject AsObjFieldInp { get; }
}

public interface ItestObjFieldInpObject
{
  ItestFldObjFieldInp Field { get; }
}

public interface ItestFldObjFieldInp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldInpObject AsFldObjFieldInp { get; }
}

public interface ItestFldObjFieldInpObject
{
}
