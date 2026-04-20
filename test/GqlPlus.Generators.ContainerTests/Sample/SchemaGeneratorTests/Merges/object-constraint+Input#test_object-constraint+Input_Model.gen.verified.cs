//HintName: test_object-constraint+Input_Model.gen.cs
// Generated from {CurrentDirectory}object-constraint+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Input;

public class testObjCnstInp<TType>
  : GqlpModelBase
  , ItestObjCnstInp<TType>
{
  public ItestObjCnstInpObject<TType>? As_ObjCnstInp { get; set; }
}

public class testObjCnstInpObject<TType>
  : GqlpModelBase
  , ItestObjCnstInpObject<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }

  public testObjCnstInpObject
    ( TType pfield
    , TType pstr
    )
  {
    Field = pfield;
    Str = pstr;
  }
}
