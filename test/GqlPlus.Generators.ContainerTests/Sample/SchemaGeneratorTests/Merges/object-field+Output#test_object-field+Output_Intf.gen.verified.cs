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
  ItestObjFieldOutpObject? As_ObjFieldOutp { get; }
}

public interface ItestObjFieldOutpObject
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldOutp Field { get; }
}

public interface ItestFldObjFieldOutp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldOutpObject? As_FldObjFieldOutp { get; }
}

public interface ItestFldObjFieldOutpObject
  : IGqlpModelImplementationBase
{
}
