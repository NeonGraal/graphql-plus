//HintName: test_object-field-alias+Input_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Input;

public interface ItestObjFieldAliasInp
  : IGqlpModelImplementationBase
{
  ItestObjFieldAliasInpObject? As_ObjFieldAliasInp { get; }
}

public interface ItestObjFieldAliasInpObject
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasInp Field { get; }
}

public interface ItestFldObjFieldAliasInp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasInpObject? As_FldObjFieldAliasInp { get; }
}

public interface ItestFldObjFieldAliasInpObject
  : IGqlpModelImplementationBase
{
}
