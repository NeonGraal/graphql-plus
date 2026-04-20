//HintName: test_object-field+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Dual;

public class testObjFieldDual
  : GqlpModelBase
  , ItestObjFieldDual
{
  public ItestObjFieldDualObject? As_ObjFieldDual { get; set; }
}

public class testObjFieldDualObject
  : GqlpModelBase
  , ItestObjFieldDualObject
{
  public ItestFldObjFieldDual Field { get; set; }

  public testObjFieldDualObject
    ( ItestFldObjFieldDual pfield
    )
  {
    Field = pfield;
  }
}

public class testFldObjFieldDual
  : GqlpModelBase
  , ItestFldObjFieldDual
{
  public ItestFldObjFieldDualObject? As_FldObjFieldDual { get; set; }
}

public class testFldObjFieldDualObject
  : GqlpModelBase
  , ItestFldObjFieldDualObject
{

  public testFldObjFieldDualObject
    ()
  {
  }
}
