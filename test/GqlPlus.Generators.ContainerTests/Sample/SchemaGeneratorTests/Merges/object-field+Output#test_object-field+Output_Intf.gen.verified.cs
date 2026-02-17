//HintName: test_object-field+Output_Intf.gen.cs
// Generated from {CurrentDirectory}object-field+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Output;

public interface ItestObjFieldOutp
  : IGqlpModelImplementationBase
{
  ItestObjFieldOutpObject AsObjFieldOutp { get; }
}

public interface ItestObjFieldOutpObject
{
  ItestFldObjFieldOutp Field { get; }
}

public interface ItestFldObjFieldOutp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldOutpObject AsFldObjFieldOutp { get; }
}

public interface ItestFldObjFieldOutpObject
{
}
