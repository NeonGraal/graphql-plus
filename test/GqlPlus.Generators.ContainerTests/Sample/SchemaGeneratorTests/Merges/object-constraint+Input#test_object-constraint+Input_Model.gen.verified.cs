//HintName: test_object-constraint+Input_Model.gen.cs
// Generated from {CurrentDirectory}object-constraint+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Input;

public class testObjCnstInp<TType>
  : GqlpModelImplementationBase
  , ItestObjCnstInp<TType>
{
  public ItestObjCnstInpObject<TType>? As_ObjCnstInp { get; set; }
}

public class testObjCnstInpObject<TType>
  : GqlpModelImplementationBase
  , ItestObjCnstInpObject<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }

  public testObjCnstInpObject
    ( TType field
    , TType str
    )
  {
    Field = field;
    Str = str;
  }
}
