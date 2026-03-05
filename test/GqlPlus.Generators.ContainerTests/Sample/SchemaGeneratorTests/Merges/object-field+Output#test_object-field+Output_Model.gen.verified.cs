//HintName: test_object-field+Output_Model.gen.cs
// Generated from {CurrentDirectory}object-field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Output;

public class testObjFieldOutp
  : GqlpModelImplementationBase
  , ItestObjFieldOutp
{
  public ItestObjFieldOutpObject? As_ObjFieldOutp { get; set; }
}

public class testObjFieldOutpObject
  : GqlpModelImplementationBase
  , ItestObjFieldOutpObject
{
  public ItestFldObjFieldOutp Field { get; set; }

  public testObjFieldOutpObject
    ( ItestFldObjFieldOutp field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldOutp
  : GqlpModelImplementationBase
  , ItestFldObjFieldOutp
{
  public ItestFldObjFieldOutpObject? As_FldObjFieldOutp { get; set; }
}

public class testFldObjFieldOutpObject
  : GqlpModelImplementationBase
  , ItestFldObjFieldOutpObject
{

  public testFldObjFieldOutpObject
    ()
  {
  }
}
