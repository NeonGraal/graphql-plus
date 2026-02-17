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
  ItestObjFieldAliasOutpObject AsObjFieldAliasOutp { get; }
}

public interface ItestObjFieldAliasOutpObject
{
  ItestFldObjFieldAliasOutp Field { get; }
}

public interface ItestFldObjFieldAliasOutp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasOutpObject AsFldObjFieldAliasOutp { get; }
}

public interface ItestFldObjFieldAliasOutpObject
{
}
