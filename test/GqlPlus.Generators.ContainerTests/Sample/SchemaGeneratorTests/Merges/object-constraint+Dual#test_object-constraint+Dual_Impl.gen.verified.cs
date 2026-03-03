//HintName: test_object-constraint+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}object-constraint+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Dual;

public class testObjCnstDual<TType>
  : GqlpModelImplementationBase
  , ItestObjCnstDual<TType>
{
  public ItestObjCnstDualObject<TType>? As_ObjCnstDual { get; set; }
}

public class testObjCnstDualObject<TType>
  : GqlpModelImplementationBase
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
