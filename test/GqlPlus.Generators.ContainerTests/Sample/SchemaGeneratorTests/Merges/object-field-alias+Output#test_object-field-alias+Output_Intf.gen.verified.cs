//HintName: test_object-field-alias+Output_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Output;

public interface ItestObjFieldAliasOutp
  : IGqlpModelImplementationBase
{
  ItestObjFieldAliasOutpObject? As_ObjFieldAliasOutp { get; }
}

public interface ItestObjFieldAliasOutpObject
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasOutp Field { get; }
}

public interface ItestFldObjFieldAliasOutp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasOutpObject? As_FldObjFieldAliasOutp { get; }
}

public interface ItestFldObjFieldAliasOutpObject
  : IGqlpModelImplementationBase
{
}
