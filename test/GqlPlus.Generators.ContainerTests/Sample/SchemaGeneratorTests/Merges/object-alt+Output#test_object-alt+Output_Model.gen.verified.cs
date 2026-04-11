//HintName: test_object-alt+Output_Model.gen.cs
// Generated from {CurrentDirectory}object-alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Output;

public class testObjAltOutp
  : GqlpModelBase
  , ItestObjAltOutp
{
  public ItestObjAltOutpType? AsObjAltOutpType { get; set; }
  public ItestObjAltOutpObject? As_ObjAltOutp { get; set; }
}

public class testObjAltOutpObject
  : GqlpModelBase
  , ItestObjAltOutpObject
{

  public testObjAltOutpObject
    ()
  {
  }
}

public class testObjAltOutpType
  : GqlpModelBase
  , ItestObjAltOutpType
{
  public ItestObjAltOutpTypeObject? As_ObjAltOutpType { get; set; }
}

public class testObjAltOutpTypeObject
  : GqlpModelBase
  , ItestObjAltOutpTypeObject
{

  public testObjAltOutpTypeObject
    ()
  {
  }
}
