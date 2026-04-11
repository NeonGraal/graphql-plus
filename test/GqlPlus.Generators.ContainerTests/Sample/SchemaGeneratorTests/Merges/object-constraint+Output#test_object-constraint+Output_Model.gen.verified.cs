//HintName: test_object-constraint+Output_Model.gen.cs
// Generated from {CurrentDirectory}object-constraint+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Output;

public class testObjCnstOutp<TType>
  : GqlpModelBase
  , ItestObjCnstOutp<TType>
{
  public ItestObjCnstOutpObject<TType>? As_ObjCnstOutp { get; set; }
}

public class testObjCnstOutpObject<TType>
  : GqlpModelBase
  , ItestObjCnstOutpObject<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }

  public testObjCnstOutpObject
    ( TType field
    , TType str
    )
  {
    Field = field;
    Str = str;
  }
}
