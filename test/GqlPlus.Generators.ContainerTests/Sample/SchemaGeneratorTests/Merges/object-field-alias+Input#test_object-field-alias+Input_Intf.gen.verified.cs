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
  ItestObjFieldAliasInpObject AsObjFieldAliasInp { get; }
}

public interface ItestObjFieldAliasInpObject
{
  ItestFldObjFieldAliasInp Field { get; }
}

public interface ItestFldObjFieldAliasInp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasInpObject AsFldObjFieldAliasInp { get; }
}

public interface ItestFldObjFieldAliasInpObject
{
}
