//HintName: test_object-constraint+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-constraint+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Dual;

public class testObjCnstDual<TType>
  : GqlpModelBase
  , ItestObjCnstDual<TType>
{
  public ItestObjCnstDualObject<TType>? As_ObjCnstDual { get; set; }
}

public class testObjCnstDualObject<TType>
  : GqlpModelBase
  , ItestObjCnstDualObject<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }

  public testObjCnstDualObject
    ( TType field
    , TType str
    )
  {
    Field = field;
    Str = str;
  }
}
