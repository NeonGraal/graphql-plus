//HintName: test_object-field+Output_Model.gen.cs
// Generated from {CurrentDirectory}object-field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Output;

public class testObjFieldOutp
  : GqlpModelBase
  , ItestObjFieldOutp
{
  public ItestObjFieldOutpObject? As_ObjFieldOutp { get; set; }
}

public class testObjFieldOutpObject
  : GqlpModelBase
  , ItestObjFieldOutpObject
{
  public ItestFldObjFieldOutp Field { get; set; }

  public testObjFieldOutpObject
    ( ItestFldObjFieldOutp pfield
    )
  {
    Field = pfield;
  }
}

public class testFldObjFieldOutp
  : GqlpModelBase
  , ItestFldObjFieldOutp
{
  public ItestFldObjFieldOutpObject? As_FldObjFieldOutp { get; set; }
}

public class testFldObjFieldOutpObject
  : GqlpModelBase
  , ItestFldObjFieldOutpObject
{

  public testFldObjFieldOutpObject
    ()
  {
  }
}
